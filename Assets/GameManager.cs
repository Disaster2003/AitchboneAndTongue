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
        RESULT,     // ���ʉ��
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
