using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundComponent : MonoBehaviour
{
    private const float POSITION_MOVE_END = -19.2f;

    private SpriteRenderer spriteRenderer;
    /// <summary>
    /// 景色の状態
    /// </summary>
    private enum STATE_VIEW
    {
        NOON,       // 正午
        AFTERNOON,  // 午後
        EVENING,    // 夕方
        NIGHT,      // 夜
        LATENIGHT,  // 夜更け
    }
    private STATE_VIEW state_view;
    private Dictionary<STATE_VIEW, Color> colorBakcground = new Dictionary<STATE_VIEW, Color>();

    // Start is called before the first frame update
    void Start()
    {
        // 初期配置
        if (transform.childCount != 0)
        {
            transform.position = Vector3.zero;
        }
        else
        {
            transform.position = new Vector3(POSITION_MOVE_END * -1, 0, 0);
        }

        // 初期色
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
        // 親オブジェクトなら動かす
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
    /// 背景遷移を行う
    /// </summary>
    private void MoveBackground()
    {
        // 左へ移動
        transform.Translate(-Time.deltaTime, 0, 0);

        // 初期位置に戻す
        if (transform.position.x <= POSITION_MOVE_END)
        {
            transform.position = Vector3.zero;
        }
    }

    /// <summary>
    /// 景色の移り変わり
    /// </summary>
    /// <param name="_state_view">次の景色</param>
    private void ChangeView(STATE_VIEW _state_view)
    {
        // 次の景色へ
        if (spriteRenderer.color == colorBakcground[_state_view])
        {
            state_view = _state_view;
        }

        // 差分を徐々に加算する
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, colorBakcground[_state_view], 0.5f * Time.deltaTime);
    }
}
