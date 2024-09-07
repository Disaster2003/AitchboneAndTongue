using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    [NonSerialized] Rigidbody2D rb;
    [NonSerialized] SpriteRenderer sr;
    enum STATE
    {
        WALK,
        JUMP,
        DROP,
        DAMAGE,
    }STATE state;
    [SerializeField] int hp;
    [SerializeField] Sprite[] walk;
    [SerializeField] Sprite[] jump;
    [SerializeField] Sprite[] drop;
    [SerializeField] Sprite[] damage;
    [SerializeField] int animeIndex;
    [SerializeField] float animeInterval;
    [NonSerialized] const int intervalTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        state=STATE.WALK;
        rb.gravityScale = 10;
        hp = 3;
        animeIndex = 0;
        animeInterval = intervalTime;
        sr.sprite = walk[animeIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (state==STATE.WALK)
        {
            if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                rb.AddForce(Vector3.up * 33, ForceMode2D.Impulse);
                AnimeChange(STATE.JUMP);
            }
        }
        if (state == STATE.JUMP && rb.velocity.y <= 0)
        {
            AnimeChange(STATE.DROP);
        }

        animeInterval -= Time.deltaTime * 50;
        if (animeInterval < 0)
        {
            animeInterval = intervalTime;
            animeIndex++;
            switch (state)
            {
                case STATE.WALK:
                    AnimeInitialize(walk);
                    break;
                case STATE.JUMP:
                    AnimeInitialize(jump);
                    break;
                case STATE.DROP:
                    AnimeInitialize(drop);
                    break;
                case STATE.DAMAGE:
                    AnimeInitialize(damage);
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.GetComponent<EnemyAction>())
        {
            AnimeChange(STATE.WALK);
        }
    }

    public int GetHP()
    {
        return hp;
    }

    public void SetHp()
    {
        AnimeChange(STATE.DAMAGE);
        hp--;
    }

    public void Heal()
    {
        if (hp < 3)
            hp++;
    }

    void AnimeInitialize(Sprite[] sprite)
    {
        if (animeIndex >= sprite.Length)
        {
            animeIndex = 0;
            if (sprite == damage)
            {
                AnimeChange(STATE.WALK);
            }
        }
        sr.sprite = sprite[animeIndex];
    }

    void AnimeChange(STATE state)
    {
        this.state = state;
        animeIndex = 0;
    }
}
