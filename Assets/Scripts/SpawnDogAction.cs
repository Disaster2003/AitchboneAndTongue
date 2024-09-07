using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDogAction : MonoBehaviour
{
    [SerializeField] GameObject[] dog;
    [SerializeField] float interval;

    // Start is called before the first frame update
    private void Start()
    {
        interval = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        interval -= Time.deltaTime;
        if (interval <= 0)
        {
            interval = Random.Range(0.7f, 1.5f);
            Instantiate(dog[Random.Range(0, dog.Length)], transform.position, transform.rotation);
        }
    }
}
