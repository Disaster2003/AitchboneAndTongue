using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timer;

    // Start is called before the first frame update
    void Start()
    {
        // ������
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ���Ԍv��
        timer += Time.deltaTime;
        GetComponent<Text>().text = timer.ToString("f1") + "s";

        // �����I��
        if(timer >= 999)
        {
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadSceneAsync(buildIndex + 1);
        }
    }

    private void OnDestroy()
    {
        // �^�C�����L�^����
        PlayerPrefs.SetFloat("R6", timer);
    }
}
