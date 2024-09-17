using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundComponent : MonoBehaviour
{
    private const float POSITION_MOVE_END = -19.2f;

    private SpriteRenderer spriteRenderer;
    /// <summary>
    /// �i�F�̏��
    /// </summary>
    private enum STATE_VIEW
    {
        NOON,       // ����
        AFTERNOON,  // �ߌ�
        EVENING,    // �[��
        NIGHT,      // ��
        LATENIGHT,  // ��X��
    }
    private STATE_VIEW state_view;
    private Dictionary<STATE_VIEW, Color> colorBakcground = new Dictionary<STATE_VIEW, Color>();

    // Start is called before the first frame update
    void Start()
    {
        // �����z�u
        if (transform.childCount != 0)
        {
            transform.position = Vector3.zero;
        }
        else
        {
            transform.position = new Vector3(POSITION_MOVE_END * -1, 0, 0);
        }

        // �����F
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;

        state_view = STATE_VIEW.NOON;
        colorBakcground[STATE_VIEW.NOON] = Color.white;
        colorBakcground[STATE_VIEW.AFTERNOON] = Color.yellow;
        colorBakcground[STATE_VIEW.EVENING] = Color.red;
        colorBakcground[STATE_VIEW.NIGHT] = Color.blue;
        colorBakcground[STATE_VIEW.LATENIGHT] = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        // �e�I�u�W�F�N�g�Ȃ瓮����
        if (transform.childCount != 0)
        {
            MoveBackground();
        }

        switch (state_view)
        {
            case STATE_VIEW.NOON:
                ChangeView(STATE_VIEW.AFTERNOON);
                break;
            case STATE_VIEW.AFTERNOON:
                ChangeView(STATE_VIEW.EVENING);
                break;
            case STATE_VIEW.EVENING:
                ChangeView(STATE_VIEW.NIGHT);
                break;
            case STATE_VIEW.NIGHT:
                ChangeView(STATE_VIEW.LATENIGHT);
                break;
            case STATE_VIEW.LATENIGHT:
                ChangeView(STATE_VIEW.NOON);
                break;
        }
    }

    /// <summary>
    /// �w�i�J�ڂ��s��
    /// </summary>
    private void MoveBackground()
    {
        // ���ֈړ�
        transform.Translate(-Time.deltaTime, 0, 0);

        // �����ʒu�ɖ߂�
        if (transform.position.x <= POSITION_MOVE_END)
        {
            transform.position = Vector3.zero;
        }
    }

    /// <summary>
    /// �i�F�̈ڂ�ς��
    /// </summary>
    /// <param name="_state_view">���̌i�F</param>
    private void ChangeView(STATE_VIEW _state_view)
    {
        // ���̌i�F��
        if (spriteRenderer.color == colorBakcground[_state_view])
        {
            state_view = _state_view;
        }

        // ���������X�ɉ��Z����
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, colorBakcground[_state_view], 0.5f * Time.deltaTime);
    }
}
