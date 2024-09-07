using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartUI : MonoBehaviour
{
    [SerializeField] int num;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (num > FindObjectOfType<PlayerAction>().GetHP())
        {
            spriteRenderer.color = new Color(255, 255, 255, 0);
        }
        else
        {
            spriteRenderer.color = new Color(255, 255, 255, 255);
        }
    }
}
