using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeatAction : MonoBehaviour
{
    [SerializeField] GameObject[] meat;
    [SerializeField] float interval;

    // Start is called before the first frame update
    void Start()
    {
        interval = 5;
    }

    // Update is called once per frame
    void Update()
    {
        interval -= Time.deltaTime;
        if (interval <= 0)
        {
            interval = 5;
            Instantiate(meat[Random.Range(0, meat.Length)], transform.position, transform.rotation);
        }
    }
}
