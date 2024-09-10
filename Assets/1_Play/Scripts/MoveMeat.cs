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
        AITCHBONE,  // �C�`�{
        TONGUE,     // �^��
    }
    private STATE_MEAT state_meat;
    private Dictionary<STATE_MEAT, Sprite> whichMeat = new Dictionary<STATE_MEAT, Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        // �����z�u
        transform.position = new Vector3(10, 0, 0);

        // �摜�̏�����
        spriteRenderer = GetComponent<SpriteRenderer>();
        whichMeat[STATE_MEAT.AITCHBONE] = meat[0];
        whichMeat[STATE_MEAT.TONGUE] = meat[1];
        state_meat = (STATE_MEAT)Random.Range(0, System.Enum.GetValues(typeof(STATE_MEAT)).Length);
        spriteRenderer.sprite = whichMeat[state_meat];

        // �ړ����x�̒�`
        speedMove = (state_meat == STATE_MEAT.AITCHBONE) ? 10 : 8;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// �ړ�
    /// </summary>
    private void Move()
    {
        // �G�P
        transform.Translate(speedMove * -Time.deltaTime, 0, 0);

        // ���g��j�󂷂�
        if (transform.position.x <= POSITION_MOVE_END)
            Destroy(gameObject);
    }
}
