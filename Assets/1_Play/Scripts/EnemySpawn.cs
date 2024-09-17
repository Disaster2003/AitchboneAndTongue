using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        // nullチェック
        if (enemy == null)
        {
            Debug.Log("敵のオブジェクトが未設定です");
            return;
        }

        // 1.5秒ごとに生成する
        InvokeRepeating(nameof(Spawn), 0, 1.5f);
    }

    /// <summary>
    /// 敵を生成する
    /// </summary>
    private void Spawn()
    {
        Instantiate(enemy);
    }
}
