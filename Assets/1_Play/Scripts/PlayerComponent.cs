using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerComponent : MonoBehaviour
{
    [SerializeField] int hp;

    private Rigidbody2D varRigidbody2D;
    private readonly Vector3 positionGround = new Vector3(-7, -3.5f, 0);

    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] walk;
    [SerializeField] Sprite[] jumpRise;
    [SerializeField] Sprite[] jumpFall;
    [SerializeField] Sprite[] damage;
    /// <summary>
    /// プレイヤーの状態
    /// </summary>
    private enum STATE_PLAYER
    {
        WALK,       // 歩行
        JUMP_RISE,  // ジャンプ
        JUMP_FALL,  // 下降
        DAMAGE,     // ダメージ
    }
    [SerializeField] STATE_PLAYER state_player;
    private float intervalAnimation;

    private float invincibleTime;

    // Start is called before the first frame update
    void Start()
    {
        // 剛体の初期化
        varRigidbody2D = GetComponent<Rigidbody2D>();
        varRigidbody2D.gravityScale = 5;
        varRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;

        // 画像の初期化
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = walk[0];
        state_player = STATE_PLAYER.WALK;
        intervalAnimation = 0;

        // 無敵時間の初期化
        invincibleTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // ゲーム終了
        if(hp <= 0)
            Destroy(gameObject);

        switch (state_player)
        {
            case STATE_PLAYER.WALK:
                PlayerAnimation(walk);

                // ジャンプ
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    state_player = STATE_PLAYER.JUMP_RISE;
                    varRigidbody2D.constraints = RigidbodyConstraints2D.None;
                    varRigidbody2D.AddForce(25 * Vector2.up, ForceMode2D.Impulse);
                }
                break;
            case STATE_PLAYER.JUMP_RISE:
                PlayerAnimation(jumpRise);

                // 下降
                if(varRigidbody2D.velocity.y <= 0)
                    state_player = STATE_PLAYER.JUMP_FALL;
                break;
            case STATE_PLAYER.JUMP_FALL:
                PlayerAnimation(jumpFall);

                // 着地
                if(transform.position.y <= positionGround.y)
                {
                    state_player = STATE_PLAYER.WALK;
                    transform.position = positionGround;
                    varRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
                }
                break;
            case STATE_PLAYER.DAMAGE:
                PlayerAnimation(damage);
                break;
        }
    }

    /// <summary>
    /// アニメーションを再生する
    /// </summary>
    /// <param name="animationSpriteArray">アニメーション画像</param>
    private void PlayerAnimation(Sprite[] animationSpriteArray)
    {
        if (intervalAnimation <= 0)
        {
            intervalAnimation = 0.1f;
            for (int i = 0; i < animationSpriteArray.Length; i++)
            {
                if (spriteRenderer.sprite == animationSpriteArray[i])
                {
                    // アニメーションの最初へ
                    if (i == animationSpriteArray.Length - 1)
                    {
                        switch (state_player)
                        {
                            case STATE_PLAYER.WALK:
                                spriteRenderer.sprite = animationSpriteArray[0];
                                break;
                            case STATE_PLAYER.JUMP_RISE:
                                spriteRenderer.sprite = animationSpriteArray[2];
                                break;
                            case STATE_PLAYER.JUMP_FALL:
                                spriteRenderer.sprite = animationSpriteArray[0];
                                break;
                            case STATE_PLAYER.DAMAGE:
                                // 「歩行」に
                                state_player = STATE_PLAYER.WALK;
                                break;
                        }
                    }
                    else
                    {
                        // 次の画像へ
                        spriteRenderer.sprite = animationSpriteArray[i + 1];
                        break;
                    }
                }
                // 初期化
                else if (i == animationSpriteArray.Length - 1)
                    spriteRenderer.sprite = animationSpriteArray[0];
            }
        }
        // 時間計測
        intervalAnimation += -Time.deltaTime;
        invincibleTime += -Time.deltaTime;

        // 半透明
        if (0 < invincibleTime)
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        else
            spriteRenderer.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 無敵中
        if (invincibleTime > 0)
            return;

        // ダメージを受ける
        if (collision.name.Contains("Enemy"))
        {
            // ジャンプ中でダメージを受けた時の特別処理
            if (state_player == STATE_PLAYER.JUMP_RISE || state_player == STATE_PLAYER.JUMP_FALL)
            {
                transform.position = positionGround;
                varRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
            }

            state_player = STATE_PLAYER.DAMAGE;
            invincibleTime = 1;
            hp--;
        }

        // 回復する
        if (collision.name.Contains("Meat"))
        {
            if (hp < 3)
                hp++;
            Destroy(collision.gameObject);
        }
    }

    /// <summary>
    /// 体力の取得
    /// </summary>
    /// <returns>Hp</returns>
    public int GetHp() { return hp; }

    private void OnDestroy()
    {
        // 次のシーンへ
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(buildIndex + 1);
    }
}
