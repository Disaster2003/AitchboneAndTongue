using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    [SerializeField] Sprite[] sprite;
    [SerializeField] int animeIndex;
    [SerializeField] float animeInterval;
    [NonSerialized] const int intervalTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        animeIndex = 0;
        GetComponent<SpriteRenderer>().sprite = sprite[animeIndex];
        animeInterval = intervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -50)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position =
                new Vector3(transform.position.x - Time.deltaTime * 10, transform.position.y, transform.position.z);
        }

        animeInterval -= Time.deltaTime * 50;
        if (animeInterval < 0)
        {
            animeInterval = intervalTime;
            animeIndex++;
            if (animeIndex >= sprite.Length)
            {
                animeIndex = 0;
            }
            GetComponent<SpriteRenderer>().sprite = sprite[animeIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerAction>())
        {
            FindObjectOfType<PlayerAction>().SetHp();
            Destroy(gameObject);
        }
    }
}
