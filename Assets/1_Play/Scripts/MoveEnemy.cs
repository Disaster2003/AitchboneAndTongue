using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private const float POSITION_MOVE_END = -10;

    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] blue;
    [SerializeField] Sprite[] gold;
    [SerializeField] Sprite[] white;
    private enum KIND_OF_COLOR
    {
        BLUE,
        GOLD,
        WHITE,
    }
    private KIND_OF_COLOR kind_of_color;
    private Dictionary<KIND_OF_COLOR, Sprite[]> whichDog = new Dictionary<KIND_OF_COLOR, Sprite[]>();
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        // 初期配置
        transform.position = new Vector3(10, -3.5f, 0);

        // 画像の初期化
        whichDog[KIND_OF_COLOR.BLUE] = blue;
        whichDog[KIND_OF_COLOR.GOLD] = gold;
        whichDog[KIND_OF_COLOR.WHITE] = white;
        kind_of_color = (KIND_OF_COLOR)Random.Range(0, System.Enum.GetValues(typeof(KIND_OF_COLOR)).Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = whichDog[kind_of_color][0];
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        EnemyAnimation();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // 敵襲
        transform.Translate(5 * -Time.deltaTime - Timer.timer * 0.001f, 0, 0);

        // 自身を破壊する
        if (transform.position.x <= POSITION_MOVE_END)
            Destroy(gameObject);
    }

    /// <summary>
    /// アニメーションを再生する
    /// </summary>
    private void EnemyAnimation()
    {
        if (timer <= 0)
        {
            timer = 0.3f;
            for (int i = 0; i < whichDog[kind_of_color].Length; i++)
                if (spriteRenderer.sprite == whichDog[kind_of_color][i])
                {
                    // 画像の最初へ
                    if (i == whichDog[kind_of_color].Length - 1)
                        spriteRenderer.sprite = whichDog[kind_of_color][0];
                    // 次の画像へ
                    else
                    {
                        spriteRenderer.sprite = whichDog[kind_of_color][i + 1];
                        break;
                    }
                }
        }
        timer += -Time.deltaTime;
    }
}
