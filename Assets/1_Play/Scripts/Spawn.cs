using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        // 2ïbÇ≤Ç∆Ç…ê∂ê¨Ç∑ÇÈ
        InvokeRepeating(nameof(EnemySpawn), 0, 1.5f);
    }

    /// <summary>
    /// ìGÇê∂ê¨Ç∑ÇÈ
    /// </summary>
    private void EnemySpawn()
    {
        Instantiate(enemy);
    }
}
