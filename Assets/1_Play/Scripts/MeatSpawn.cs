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
        // ���𐶐�����
        if(timer <= 0)
        {
            timer = Random.Range(25, 40);
            Instantiate(meat);
        }
        timer += -Time.deltaTime;
    }
}
