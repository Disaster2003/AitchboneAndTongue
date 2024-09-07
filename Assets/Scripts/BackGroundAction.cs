using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAction : MonoBehaviour
{
    enum STATE
    {
        NOON,           // 正午
        AFTERNOON,      // 午後
        EVENING,        // 夕方
        NIGHT,          // 夜
        LATENIGHT,      // 夜更け
    }
    STATE state;
    Color color;
    Dictionary<STATE, Color> backGroundColor = new Dictionary<STATE, Color>();
    const float positionEnd = 8.9f;

    // Start is called before the first frame update
    void Start()
    {
        state = STATE.NOON;

        backGroundColor[STATE.NOON] = Color.white;
        backGroundColor[STATE.AFTERNOON] = Color.yellow;
        backGroundColor[STATE.EVENING] = Color.red;
        backGroundColor[STATE.NIGHT] = Color.blue;
        backGroundColor[STATE.LATENIGHT] = new Color(0.2f, 0.2f, 0.2f, 0.99f);
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATE.NOON:
                SetState(STATE.AFTERNOON);
                break;
            case STATE.AFTERNOON:
                SetState(STATE.EVENING);
                break;
            case STATE.EVENING:
                SetState(STATE.NIGHT);
                break;
            case STATE.NIGHT:
                SetState(STATE.LATENIGHT);
                break;
            case STATE.LATENIGHT:
                SetState(STATE.NOON);
                break;
        }
        transform.Translate(-Time.deltaTime, 0, 0);
        if (transform.position.x < -positionEnd)
        {
            transform.position = new Vector3(positionEnd, 0, 0);
        }
    }

    void SetState(STATE state)
    {
        // 現在の色を取得する
        color = GetComponent<SpriteRenderer>().color;

        if (color == backGroundColor[state])
        {
            this.state = state;
        }

        // 差分を徐々に加算する
        GetComponent<SpriteRenderer>().color = Color.Lerp(color, backGroundColor[state], Time.deltaTime * 0.5f);
    }
}
