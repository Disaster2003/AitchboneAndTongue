using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeat : MonoBehaviour
{
    private const float POSITION_MOVE_END = -10;
    private float speedMove;

    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] meat;
    private enum STATE_MEAT
    {
        AITCHBONE,  // イチボ
        TONGUE,     // タン
    }
    private STATE_MEAT state_meat;
    private Dictionary<STATE_MEAT, Sprite> whichMeat = new Dictionary<STATE_MEAT, Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        // 初期配置
        transform.position = new Vector3(10, 0, 0);

        // 画像の初期化
        spriteRenderer = GetComponent<SpriteRenderer>();
        whichMeat[STATE_MEAT.AITCHBONE] = meat[0];
        whichMeat[STATE_MEAT.TONGUE] = meat[1];
        state_meat = (STATE_MEAT)Random.Range(0, System.Enum.GetValues(typeof(STATE_MEAT)).Length);
        spriteRenderer.sprite = whichMeat[state_meat];

        // 移動速度の定義
        speedMove = (state_meat == STATE_MEAT.AITCHBONE) ? 10 : 8;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        // 敵襲
        transform.Translate(speedMove * -Time.deltaTime, 0, 0);

        // 自身を破壊する
        if (transform.position.x <= POSITION_MOVE_END)
            Destroy(gameObject);
    }
}
