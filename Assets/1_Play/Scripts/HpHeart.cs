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
        // �摜��\��
        if(number <= player.GetComponent<PlayerComponent>().GetHp())
            GetComponent<Image>().color = Color.white;
        // �摜���\��
        else
            GetComponent<Image>().color = Color.clear;
    }
}
