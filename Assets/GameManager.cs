using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// シーンの状態
    /// </summary>
    private enum STATE_SCENE
    {
        TITLE = 0,  // タイトル画面
        PLAY = 1,   // プレイ画面
        RESULT,     // 結果画面
    }
    private STATE_SCENE state_scene;

    // Start is called before the first frame update
    void Start()
    {
        state_scene = STATE_SCENE.TITLE;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
