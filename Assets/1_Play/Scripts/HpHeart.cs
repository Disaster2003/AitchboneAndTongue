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
        // ‰æ‘œ‚ð•\Ž¦
        if(number <= player.GetComponent<PlayerComponent>().GetHp())
            GetComponent<Image>().color = Color.white;
        // ‰æ‘œ‚ð”ñ•\Ž¦
        else
            GetComponent<Image>().color = Color.clear;
    }
}
