using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        // 2ïbÇ≤Ç∆Ç…ê∂ê¨Ç∑ÇÈ
        InvokeRepeating(nameof(Spawn), 0, 1.5f);
    }

    /// <summary>
    /// ìGÇê∂ê¨Ç∑ÇÈ
    /// </summary>
    private void Spawn()
    {
        Instantiate(enemy);
    }
}
