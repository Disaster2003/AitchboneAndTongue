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
        // null�`�F�b�N
        if (player == null)
        {
            Debug.Log("�v���C���[�����ݒ�ł�");
            return;
        }
        if (number == 0)
        {
            Debug.Log("�摜�ԍ����U�蕪�����Ă��܂���");
            return;
        }

        // �摜��\��
        if (number <= player.GetComponent<PlayerComponent>().GetHp())
        {
            GetComponent<Image>().color = Color.white;
        }
        // �摜���\��
        else
        {
            GetComponent<Image>().color = Color.clear;
        }
    }
}
