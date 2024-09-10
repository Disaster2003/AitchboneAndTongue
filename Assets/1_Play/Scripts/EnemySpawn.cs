using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        // 2�b���Ƃɐ�������
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
