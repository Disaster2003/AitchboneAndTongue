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
    /// �v���C���[�̏��
    /// </summary>
    private enum STATE_PLAYER
    {
        WALK,       // ���s
        JUMP_RISE,  // �W�����v
        JUMP_FALL,  // ���~
        DAMAGE,     // �_���[�W
    }
    [SerializeField] STATE_PLAYER state_player;
    private float intervalAnimation;

    private float invincibleTime;

    // Start is called before the first frame update
    void Start()
    {
        // ���̂̏�����
        varRigidbody2D = GetComponent<Rigidbody2D>();
        varRigidbody2D.gravityScale = 5;
        varRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;

        // �摜�̏�����
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = walk[0];
        state_player = STATE_PLAYER.WALK;
        intervalAnimation = 0;

        // ���G���Ԃ̏�����
        invincibleTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[���I��
        if(hp <= 0)
            Destroy(gameObject);

        switch (state_player)
        {
            case STATE_PLAYER.WALK:
                PlayerAnimation(walk);

                // �W�����v
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    state_player = STATE_PLAYER.JUMP_RISE;
                    varRigidbody2D.constraints = RigidbodyConstraints2D.None;
                    varRigidbody2D.AddForce(25 * Vector2.up, ForceMode2D.Impulse);
                }
                break;
            case STATE_PLAYER.JUMP_RISE:
                PlayerAnimation(jumpRise);

                // ���~
                if(varRigidbody2D.velocity.y <= 0)
                    state_player = STATE_PLAYER.JUMP_FALL;
                break;
            case STATE_PLAYER.JUMP_FALL:
                PlayerAnimation(jumpFall);

                // ���n
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
    /// �A�j���[�V�������Đ�����
    /// </summary>
    /// <param name="animationSpriteArray">�A�j���[�V�����摜</param>
    private void PlayerAnimation(Sprite[] animationSpriteArray)
    {
        if (intervalAnimation <= 0)
        {
            intervalAnimation = 0.1f;
            for (int i = 0; i < animationSpriteArray.Length; i++)
            {
                if (spriteRenderer.sprite == animationSpriteArray[i])
                {
                    // �A�j���[�V�����̍ŏ���
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
                                // �u���s�v��
                                state_player = STATE_PLAYER.WALK;
                                break;
                        }
                    }
                    else
                    {
                        // ���̉摜��
                        spriteRenderer.sprite = animationSpriteArray[i + 1];
                        break;
                    }
                }
                // ������
                else if (i == animationSpriteArray.Length - 1)
                    spriteRenderer.sprite = animationSpriteArray[0];
            }
        }
        // ���Ԍv��
        intervalAnimation += -Time.deltaTime;
        invincibleTime += -Time.deltaTime;

        // ������
        if (0 < invincibleTime)
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        else
            spriteRenderer.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���G��
        if (invincibleTime > 0)
            return;

        // �_���[�W���󂯂�
        if (collision.name.Contains("Enemy"))
        {
            // �W�����v���Ń_���[�W���󂯂����̓��ʏ���
            if (state_player == STATE_PLAYER.JUMP_RISE || state_player == STATE_PLAYER.JUMP_FALL)
            {
                transform.position = positionGround;
                varRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
            }

            state_player = STATE_PLAYER.DAMAGE;
            invincibleTime = 1;
            hp--;
        }

        // �񕜂���
        if (collision.name.Contains("Meat"))
        {
            if (hp < 3)
                hp++;
            Destroy(collision.gameObject);
        }
    }

    /// <summary>
    /// �̗͂̎擾
    /// </summary>
    /// <returns>Hp</returns>
    public int GetHp() { return hp; }

    private void OnDestroy()
    {
        // ���̃V�[����
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(buildIndex + 1);
    }
}
