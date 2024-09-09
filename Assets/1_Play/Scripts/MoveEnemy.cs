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
        // �����z�u
        transform.position = new Vector3(10, -3.5f, 0);

        // �摜�̏�����
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
    /// �ړ�
    /// </summary>
    private void Move()
    {
        // �G�P
        transform.Translate(5 * -Time.deltaTime - Timer.timer * 0.001f, 0, 0);

        // ���g��j�󂷂�
        if (transform.position.x <= POSITION_MOVE_END)
            Destroy(gameObject);
    }

    /// <summary>
    /// �A�j���[�V�������Đ�����
    /// </summary>
    private void EnemyAnimation()
    {
        if (timer <= 0)
        {
            timer = 0.3f;
            for (int i = 0; i < whichDog[kind_of_color].Length; i++)
                if (spriteRenderer.sprite == whichDog[kind_of_color][i])
                {
                    // �摜�̍ŏ���
                    if (i == whichDog[kind_of_color].Length - 1)
                        spriteRenderer.sprite = whichDog[kind_of_color][0];
                    // ���̉摜��
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
