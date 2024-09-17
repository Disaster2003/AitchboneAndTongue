using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatSpawn : MonoBehaviour
{
    [SerializeField] GameObject meat;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // null�`�F�b�N
        if(meat == null)
        {
            Debug.Log("���̃I�u�W�F�N�g�����ݒ�ł�");
            return;
        }

        // ���𐶐�����
        if(timer <= 0)
        {
            timer = Random.Range(25, 40);
            Instantiate(meat);
        }
        // �����̃C���^�[�o��
        timer += -Time.deltaTime;
    }
}
