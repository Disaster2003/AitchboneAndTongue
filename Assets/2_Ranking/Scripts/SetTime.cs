using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // タイムアップ時のスコアを設定する
        GetComponent<Text>().text = "PlayerTime : " + PlayerPrefs.GetFloat("R6").ToString() + "s";
    }
}
