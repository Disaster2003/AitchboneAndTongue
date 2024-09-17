using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpHeart : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int number;
    
    // Update is called once per frame
    void Update()
    {
        // nullチェック
        if (player == null)
        {
            Debug.Log("プレイヤーが未設定です");
            return;
        }
        if (number == 0)
        {
            Debug.Log("画像番号が振り分けられていません");
            return;
        }

        // 画像を表示
        if (number <= player.GetComponent<PlayerComponent>().GetHp())
        {
            GetComponent<Image>().color = Color.white;
        }
        // 画像を非表示
        else
        {
            GetComponent<Image>().color = Color.clear;
        }
    }
}
