using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRanking : MonoBehaviour
{
    private Text txtRank;
    private float[] rank = new float[6]; // ��ƃG���A

    // Start is called before the first frame update
    void Start()
    {
        txtRank = GetComponent<Text>();
        txtRank.text = "\n";

        // �����L���O
        InitializeRankArray();
        Ranking();
        Debug.Log(gameObject.name);
    }

    /// <summary>
    /// rank�̏�����
    /// </summary>
    private void InitializeRankArray()
    {
        // �A�v���̃f�[�^�̈悪���݂��邩
        if (PlayerPrefs.HasKey("R1"))
        {
            for (int idx = 1; idx <= 5; idx++)
                rank[idx] = PlayerPrefs.GetFloat("R" + idx); // �f�[�^�̈�ǂݍ���

            Debug.Log("�f�[�^�̈��ǂݍ��݂܂����B");
        }
        else
        {
            for (int idx = 1; idx <= 5; idx++)
            {
                rank[idx] = 0; // �[���ŏ�����
                PlayerPrefs.SetFloat("R" + idx, rank[idx]); // �[�����i�[����
            }
            Debug.Log("�f�[�^�̈�����������܂����B");
        }
    }

    /// <summary>
    /// �����L���O����
    /// </summary>
    private void Ranking()
    {
        float ELAPSED = PlayerPrefs.GetFloat("R6");
        int newRank = 0; // �܂�����̃X�R�A��0�ʂƉ��肷��

        for (int idx = 5; idx > 0; idx--)
            // �t�� 5...1
            if (rank[idx] < ELAPSED)
                newRank = idx; // �V���������N�Ƃ��Ĕ��肷��

        // 0�ʂ̂܂܂łȂ������烉���N�C���m��
        if (newRank != 0)
        { 
            for (int idx = 5; idx > newRank; idx--)
                rank[idx] = rank[idx - 1]; // �J�艺������
            rank[newRank] = ELAPSED;       // �V�����N�ɓo�^

            for (int idx = 1; idx <= 5; idx++)
                PlayerPrefs.SetFloat("R" + idx, rank[idx]); // �f�[�^�̈�ɕۑ�
        }

        // ���ꂼ��̃����N�̒l��ݒ肷��
        for (int idx = 1; idx <= 5; idx++)
        {
            txtRank.text += idx +  "." + rank[idx].ToString("f1") + "s"; // �����N����
            txtRank.text += System.Environment.NewLine; // ���s���������Ă���
        }
    }
}
