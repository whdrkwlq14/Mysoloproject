using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                        // �÷��̾ ������ �� �߰��Ǵ� ��.
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;  // �������� �ε巴�� �ϴ� ����.
    [SerializeField] private bool m_AirControl = true;                        // �÷��̾ ���� �߿��� ������ �� �ִ��� ����.
    [SerializeField] private LayerMask m_WhatIsGround;                        // ĳ���Ϳ��� ������ �ƴ����� �����ϴ� ����ũ.
    [SerializeField] private Transform m_GroundCheck;                         // �÷��̾ ���� �ִ��� Ȯ���ϴ� ��ġ.
    [SerializeField] private Transform m_WallCheck;                           // �÷��̾ ���� ����� Ȯ���ϴ� ��ġ

    const float k_GroundedRadius = .2f; // ���� ��Ҵ��� Ȯ���ϱ� ���� ������ ���� ������.
    private bool m_Grounded;            // �÷��̾ ���� �ִ��� ����.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // ���� �÷��̾ ��� ������ ���� �ִ��� ����.
    private Vector3 velocity = Vector3.zero;
    private float limitFallSpeed = 25f; // ���� �ӵ� ����

    public bool canDoubleJump = true;  // �÷��̾ �� �� ������ �� �ִ��� ����
    [SerializeField] private float m_DashForce = 25f;
    private bool canDash = true;
    private bool isDashing = false;   // �÷��̾ ��� ������ ����
    private bool m_IsWall = false;    // �÷��̾� �տ� ���� �ִ��� ����
    private bool isWallSliding = false;  // �÷��̾ ������ �̲��������� ����
    private bool oldWallSlidding = false;  // ���� �����ӿ��� ������ �̲��������� ����
    private float prevVelocityX = 0f;
    private bool canCheck = false;     // �÷��̾ ������ �̲��������� Ȯ���ϱ� ���� �÷���

    public float life = 10f;             // �÷��̾��� �����
    public bool invincible = false;     // �÷��̾ �������� ����
    private bool canMove = true;         // �÷��̾ ������ �� �ִ��� ����

    private Animator animator;
    public ParticleSystem particleJumpUp;   // ���� �� �����Ǵ� ���� ȿ��
    public ParticleSystem particleJumpDown;  // ������ �� �����Ǵ� ���� ȿ��

    private float jumpWallStartX = 0;
    private float jumpWallDistX = 0;       // �÷��̾�� �� ������ �Ÿ�
    private bool limitVelOnWallJump = false;  // ���� FPS���� �� ���� �Ÿ��� �����ϱ� ���� �÷���

    [Header("�̺�Ʈ")]
    [Space]

    public UnityEvent OnFallEvent;
    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent < Animator>();

        if (OnFallEvent == null)
            OnFallEvent = new UnityEvent();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }


    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

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
                OnLandEvent.Invoke();
                if (!m_IsWall && !isDashing)
                    particleJumpDown.Play();
                canDoubleJump = true;
                if (m_Rigidbody2D.velocity.y < 0f)
                    limitVelOnWallJump = false;
            }
        }

        m_IsWall = false;

        if (!m_Grounded)
        {
            OnFallEvent.Invoke();
            Collider2D[] collidersWall = Physics2D.OverlapCircleAll(m_WallCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < collidersWall.Length; i++)
            {
                if (collidersWall[i].gameObject != null)
                {
                    isDashing = false;
                    m_IsWall = true;
                }
            }
            prevVelocityX = m_Rigidbody2D.velocity.x;
        }

        if (limitVelOnWallJump)
        {
            if (m_Rigidbody2D.velocity.y < -0.5f)
                limitVelOnWallJump = false;
            jumpWallDistX = (jumpWallStartX - transform.position.x) * transform.localScale.x;
            if (jumpWallDistX < -0.5f && jumpWallDistX > -1f)
            {
                canMove = true;
            }
            else if (jumpWallDistX < -1f && jumpWallDistX >= -2f)
            {
                canMove = true;
                m_Rigidbody2D.velocity = new Vector2(10f * transform.localScale.x, m_Rigidbody2D.velocity.y);
            }
            else if (jumpWallDistX < -2f)
            {
                limitVelOnWallJump = false;
                m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
            }
            else if (jumpWallDistX > 0)
            {
                limitVelOnWallJump = false;
                m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
            }
        }
    }


    public void Move(float move, bool jump, bool dash)
    {
        if (canMove)
        {
            if (dash && canDash && !isWallSliding)
            {
                //��� �����ϸ� �� �����̵����� �ƴҶ� �÷��̾ ����ϰ� �����.
                StartCoroutine(DashCooldown());
            }
            // ��� ���� �ƴҶ��� �÷��̾ ����.
            if (isDashing)
            {
                m_Rigidbody2D.velocity = new Vector2(transform.localScale.x * m_DashForce, 0);
            }
           // ������� �ƴҶ��� �÷��̾ �����Ѵ�.
            else if (m_Grounded || m_AirControl)
            {
                if (m_Rigidbody2D.velocity.y < -limitFallSpeed)
                    m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, -limitFallSpeed);
                // ��ǥ �ӵ��� ã�� �÷��̾ �̵�
                Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
                // ��ǥ �ӵ��� �ε巴���ϰ� ĳ���Ϳ� ����
                m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

                //�Է��� �÷��̾ ���������� �̵��ϰ� �ϰ� �÷��̾ ������ ����������
                if (move > 0 && !m_FacingRight && !isWallSliding)
                {
                    // ��¤��
                    Flip();
                }
                // �ݴ�� �Է��� �÷��̾ �������� �̵��ϰ� �ϰ� �÷��̾ �������� ���� ���� ��...
                else if (move < 0 && m_FacingRight && !isWallSliding)
                {
                    // ��¤��
                    Flip();
                }
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
            else if (!m_Grounded && jump && canDoubleJump && !isWallSliding)
            {
                // ���� ���� �����ϰ� �� �����̵� ���� �ƴ� ��
                canDoubleJump = false;
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 0);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce / 1.2f));
                animator.SetBool("IsDoubleJumping", true);
            }

            else if (m_IsWall && !m_Grounded)
            {
                if (!oldWallSlidding && m_Rigidbody2D.velocity.y < 0 || isDashing)
                {
                    isWallSliding = true;
                    // �� �����̵� ���̶�� �÷��̾� ��ġ�� �����մϴ�.
                    m_WallCheck.localPosition = new Vector3(-m_WallCheck.localPosition.x, m_WallCheck.localPosition.y, 0);
                    Flip();
                    // üũ ���� �� �� ���� �����ϰ� �ϰ� �ִϸ��̼��� �����մϴ�.
                    StartCoroutine(WaitToCheck(0.1f));
                    canDoubleJump = true;
                    animator.SetBool("IsWallSliding", true);
                }
                isDashing = false;

                if (isWallSliding)
                {
                    if (move * transform.localScale.x > 0.1f)
                    {
                        StartCoroutine(WaitToEndSliding());
                    }
                    else
                    {
                        oldWallSlidding = true;
                        m_Rigidbody2D.velocity = new Vector2(-transform.localScale.x * 2, -5);
                    }
                }

                if (jump && isWallSliding)
                {
                    animator.SetBool("IsJumping", true);
                    animator.SetBool("JumpUp", true);
                    m_Rigidbody2D.velocity = new Vector2(0f, 0f);
                    m_Rigidbody2D.AddForce(new Vector2(transform.localScale.x * m_JumpForce * 1.2f, m_JumpForce));
                    jumpWallStartX = transform.position.x;
                    limitVelOnWallJump = true;
                    canDoubleJump = true;
                    isWallSliding = false;
                    animator.SetBool("IsWallSliding", false);
                    oldWallSlidding = false;
                    m_WallCheck.localPosition = new Vector3(Mathf.Abs(m_WallCheck.localPosition.x), m_WallCheck.localPosition.y, 0);
                    canMove = false;
                }
                else if (dash && canDash)
                {
                    isWallSliding = false;
                    animator.SetBool("IsWallSliding", false);
                    oldWallSlidding = false;
                    m_WallCheck.localPosition = new Vector3(Mathf.Abs(m_WallCheck.localPosition.x), m_WallCheck.localPosition.y, 0);
                    canDoubleJump = true;
                    StartCoroutine(DashCooldown());
                }
            }
            else if (isWallSliding && !m_IsWall && canCheck)
            {
                isWallSliding = false;
                animator.SetBool("IsWallSliding", false);
                oldWallSlidding = false;
                m_WallCheck.localPosition = new Vector3(Mathf.Abs(m_WallCheck.localPosition.x), m_WallCheck.localPosition.y, 0);
                canDoubleJump = true;
            }
        }
    }


    private void Flip()
    {
        // �÷��̾��� ������ ��¤��
        m_FacingRight = !m_FacingRight;

        // �÷��̾��� x ���� �����Ͽ� -1�� ���Ѵ�
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void ApplyDamage(float damage, Vector3 position)
    {
        if (!invincible)
        {
            animator.SetBool("Hit", true);
            life -= damage;
            Vector2 damageDir = Vector3.Normalize(transform.position - position) * 40f;
            m_Rigidbody2D.velocity = Vector2.zero;
            m_Rigidbody2D.AddForce(damageDir * 10);
            if (life <= 0)
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

    IEnumerator DashCooldown()
    {
        animator.SetBool("IsDashing", true);
        isDashing = true;
        canDash = false;
        yield return new WaitForSeconds(0.1f);
        isDashing = false;
        yield return new WaitForSeconds(0.5f);
        canDash = true;
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

    IEnumerator WaitToEndSliding()
    {
        yield return new WaitForSeconds(0.1f);
        canDoubleJump = true;
        isWallSliding = false;
        animator.SetBool("IsWallSliding", false);
        oldWallSlidding = false;
        m_WallCheck.localPosition = new Vector3(Mathf.Abs(m_WallCheck.localPosition.x), m_WallCheck.localPosition.y, 0);
    }

    IEnumerator WaitToDead()
    {
        animator.SetBool("IsDead", true);
        canMove = false;
        invincible = true;
        GetComponent<Attack>().enabled = false;
        yield return new WaitForSeconds(0.4f);
        m_Rigidbody2D.velocity = new Vector2(0, m_Rigidbody2D.velocity.y);
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
