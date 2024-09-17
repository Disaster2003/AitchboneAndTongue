using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        // null�`�F�b�N
        if (enemy == null)
        {
            Debug.Log("�G�̃I�u�W�F�N�g�����ݒ�ł�");
            return;
        }

        // 1.5�b���Ƃɐ�������
        InvokeRepeating(nameof(Spawn), 0, 1.5f);
    }

    /// <summary>
    /// �G�𐶐�����
    /// </summary>
    private void Spawn()
    {
        Instantiate(enemy);
    }
}
