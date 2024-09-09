using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        // 2秒ごとに生成する
        InvokeRepeating(nameof(EnemySpawn), 0, 1.5f);
    }

    /// <summary>
    /// 敵を生成する
    /// </summary>
    private void EnemySpawn()
    {
        Instantiate(enemy);
    }
}
