using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                        // �÷��̾ ������ �� �߰��Ǵ� ��.
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = 0.5f;  // �������� �ε巴�� �ϴ� ����.
    [SerializeField] private bool m_AirControl = true;                        // �÷��̾ ���� �߿��� ������ �� �ִ��� ����.
    [SerializeField] private LayerMask m_WhatIsGround;                        // ĳ���Ϳ��� ������ �ƴ����� �����ϴ� ����ũ.
    [SerializeField] private Transform m_GroundCheck;                         // �÷��̾ ���� �ִ��� Ȯ���ϴ� ��ġ.
    [SerializeField] private Transform m_WallCheck;                           // �÷��̾ ���� ����� Ȯ���ϴ� ��ġ

    public float maxHealth = 5;
    public float currentHealth = 0f; //���� �����
    public SpriteRenderer playerRenderer;
    public bool isFlashing = false;
    public float flashDuration = 0.1f;
    public float flashTimer = 2f;

    public SpikeTrap spikeDamage;

    const float k_GroundedRadius = 2f; // ���� ��Ҵ��� Ȯ���ϱ� ���� ������ ���� ������.
    private bool m_Grounded;            // �÷��̾ ���� �ִ��� ����.
    public Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // ���� �÷��̾ ��� ������ ���� �ִ��� ����.
    private Vector3 velocity = Vector3.zero;
    private float limitFallSpeed = 20f; // ���� �ӵ� ����

    [SerializeField] SpriteRenderer _renderer;

    public bool canDoubleJump = true;  // �÷��̾ �� �� ������ �� �ִ��� ����

    private bool canCheck = false;     // �÷��̾ ������ �̲��������� Ȯ���ϱ� ���� �÷���

    public float life = 10f;             // �÷��̾��� �����
    public bool invincible = false;     // �÷��̾ �������� ����
    private bool canMove = true;         // �÷��̾ ������ �� �ִ��� ����

    public Animator animator;
    public ParticleSystem particleJumpUp;   // ���� �� �����Ǵ� ���� ȿ��
    public ParticleSystem particleJumpDown;  // ������ �� �����Ǵ� ���� ȿ��

    private bool limitVelOnWallJump = false;  // ���� FPS���� �� ���� �Ÿ��� �����ϱ� ���� �÷���

    public void Start()
    {

        currentHealth = maxHealth; // ���۽� ���� ������� �ִ� �ϰ�� �ʱ�ȭ
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    public void Update()
    {
        if (isFlashing)
        {
            flashTimer += Time.deltaTime;

            if (flashTimer >= flashDuration)
            {
                isFlashing = false;
                flashTimer = 0f;
                playerRenderer.color = new Color(1f, 1f, 1f, 0f);
            }
            else
            {
                float alphaValue = flashTimer / flashDuration;
                if (alphaValue % 0.5f < 0.25f)
                {
                    playerRenderer.color = new Color(1f, 1f, 1f, 0f);
                }
                else
                {
                    playerRenderer.color = new Color(1f, 1f, 1f, 1f);
                }
            }

        }
    }


    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false; // �׶��尡 �ƴҶ�(���� ����
        // �÷��̾ ���� �پ� �ִ��� Ȯ��
        // �׶���üũ ��ġ���� �� ��� ĳ��Ʋ ����Ͽ� ������ ������ �ƹ��ų��� �浹�ϸ� ���� �پ��ִ°ɷ� üũ��,
        // ���̾ ���� �Ǵٸ� üũ
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
            if (!wasGrounded)
            {
                particleJumpDown.Play();
                canDoubleJump = true;
                if (m_Rigidbody2D.velocity.y < 0f)
                    limitVelOnWallJump = false;
            }
        }
    }
    public void Flip()
    {
        // �÷��̾��� ������ ��¤��
        m_FacingRight = !m_FacingRight;

        // �÷��̾��� x ���� �����Ͽ� -1�� ���Ѵ�
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void ApplyDamage(float damage/* Vector3 position*/)
    {
        if (!invincible)
        {
            Debug.Log("����� Ȯ�ο�");
            maxHealth -= damage;

            animator.SetBool("Hit", true);
            Vector2 damageDir = Vector3.Normalize(transform.position - transform.position) * 100f;

            m_Rigidbody2D.velocity = Vector2.zero;
            m_Rigidbody2D.AddForce(damageDir * 10);
            if (currentHealth <= 0)
            {
                StartCoroutine(WaitToDead());
            }
            else
            {
                StartCoroutine(Stun(0.25f));
                StartCoroutine(MakeInvincible(1f));
            }
        }
    }
    public void Move(float move, bool jump)
    {
        // ������� �ƴҶ��� �÷��̾ �����Ѵ�.
        if (m_Grounded || m_AirControl)
        {
            if (m_Rigidbody2D.velocity.y < -limitFallSpeed)
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, -limitFallSpeed);
            // ��ǥ �ӵ��� ã�� �÷��̾ �̵�
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // ��ǥ �ӵ��� �ε巴���ϰ� ĳ���Ϳ� ����
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

            //�Է��� �÷��̾ ���������� �̵��ϰ� �ϰ� �÷��̾ ������ ����������
            if (move > 0 && !m_FacingRight)
            {
                // ��¤��
                Flip();
            }
            // �ݴ�� �Է��� �÷��̾ �������� �̵��ϰ� �ϰ� �÷��̾ �������� ���� ���� ��...
            else if (move < 0 && m_FacingRight)
            {
                // ��¤��
                Flip();
            }
            // �÷��̾ �����ؾ� �ϴ� ���
            if (m_Grounded && jump)
            {
                // �÷��̾�� ���� ���� �߰�
                animator.SetBool("IsJumping", true);
                animator.SetBool("JumpUp", true);
                m_Grounded = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                canDoubleJump = true;
                particleJumpDown.Play();
                particleJumpUp.Play();
            }
            else if (!m_Grounded && jump && canDoubleJump)
            {
                // ���� ���� �����ϰ� �� �����̵� ���� �ƴ� ��
                canDoubleJump = false;
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce / 1.2f));
                animator.SetBool("IsDoubleJumping", true);
            }
        }
    }
    IEnumerator Stun(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
    IEnumerator MakeInvincible(float time)
    {
        invincible = true;
        yield return new WaitForSeconds(time);
        invincible = false;
    }
    IEnumerator WaitToMove(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    IEnumerator WaitToCheck(float time)
    {
        canCheck = false;
        yield return new WaitForSeconds(time);
        canCheck = true;
    }
    IEnumerator WaitToDead()
    {
        animator.SetBool("IsDead", true);
        canMove = false;
        invincible = true;
        yield return new WaitForSeconds(0.4f);
        m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }





    public void StartFlashingEffect()
    {
        isFlashing = true;
        flashTimer = 0f;
    }

 
}


