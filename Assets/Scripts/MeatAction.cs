using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatAction : MonoBehaviour
{
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
                new Vector3(transform.position.x - Time.deltaTime * 15, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerAction>())
        {
            FindObjectOfType<PlayerAction>().Heal();
            Destroy(gameObject);
        }
    }
}
