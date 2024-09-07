using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// �V�[���̏��
    /// </summary>
    private enum STATE_SCENE
    {
        TITLE = 0,  // �^�C�g�����
        PLAY = 1,   // �v���C���
        RANKING,    // ���ʉ��
    }
    private STATE_SCENE state_scene;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

        state_scene = STATE_SCENE.TITLE;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state_scene)
        {
            case STATE_SCENE.TITLE:
                OnButtonDownNextScene(STATE_SCENE.PLAY);
                break;
            case STATE_SCENE.PLAY:
                break;
            case STATE_SCENE.RANKING:
                OnButtonDownNextScene(STATE_SCENE.TITLE);
                break;
        }
    }

    /// <summary>
    /// ���̃V�[���ւ̑J�ڂ��s��
    /// </summary>
    /// <param name="_state_scene">���̃V�[��</param>
    private void OnButtonDownNextScene(STATE_SCENE _state_scene)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state_scene = _state_scene;
            SceneManager.LoadSceneAsync((int)state_scene);
        }
    }
}
