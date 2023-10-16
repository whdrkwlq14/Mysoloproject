using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                        // 플레이어가 점프할 때 추가되는 힘.
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = 0.5f;  // 움직임을 부드럽게 하는 정도.
    [SerializeField] private bool m_AirControl = true;                        // 플레이어가 점프 중에도 조종할 수 있는지 여부.
    [SerializeField] private LayerMask m_WhatIsGround;                        // 캐릭터에게 땅인지 아닌지를 결정하는 마스크.
    [SerializeField] private Transform m_GroundCheck;                         // 플레이어가 땅에 있는지 확인하는 위치.
    [SerializeField] private Transform m_WallCheck;                           // 플레이어가 벽에 닿는지 확인하는 위치

    const float k_GroundedRadius = 2f; // 땅에 닿았는지 확인하기 위한 오버랩 원의 반지름.
    private bool m_Grounded;            // 플레이어가 땅에 있는지 여부.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // 현재 플레이어가 어느 방향을 보고 있는지 결정.
    private Vector3 velocity = Vector3.zero;
    private float limitFallSpeed = 20f; // 낙하 속도 제한

    public bool canDoubleJump = true;  // 플레이어가 두 번 점프할 수 있는지 여부
    [SerializeField] private float m_DashForce = 25f;

    private float prevVelocityX = 0f;
    private bool canCheck = false;     // 플레이어가 벽에서 미끄러지는지 확인하기 위한 플래그

    public float life = 10f;             // 플레이어의 생명력
    public bool invincible = false;     // 플레이어가 무적인지 여부
    private bool canMove = true;         // 플레이어가 움직일 수 있는지 여부

    private Animator animator;
    public ParticleSystem particleJumpUp;   // 점프 시 생성되는 입자 효과
    public ParticleSystem particleJumpDown;  // 떨어질 때 생성되는 입자 효과

    private bool limitVelOnWallJump = false;  // 낮은 FPS에서 벽 점프 거리를 제한하기 위한 플래그

    [Header("이벤트")]
    [Space]

    public UnityEvent OnFallEvent;
    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (OnFallEvent == null)
            OnFallEvent = new UnityEvent();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }


    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false; // 그라운드가 아닐때(점프 중이
        // 플레이어가 땅에 붙어 있는지 확인
        // 그라운드체크 위치에서 원 모양 캐스틀 사용하여 땅으로 지정된 아무거나와 충돌하면 땅에 붙어있는걸로 체크됨,
        // 레이어를 통해 또다른 체크
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
            if (!wasGrounded)
            {
                //OnLandEvent.Invoke();
                //if (!m_IsWall && !isDashing)
                particleJumpDown.Play();
                canDoubleJump = true;
                if (m_Rigidbody2D.velocity.y < 0f)
                    limitVelOnWallJump = false;
            }
        }
    }
    public void Flip()
    {
        // 플레이어의 방향을 뒤짚기
        m_FacingRight = !m_FacingRight;

        // 플레이어의 x 로컬 스케일에 -1을 곱한다
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
    public void Move(float move, bool jump)
    {
        // 대시중이 아닐때만 플레이어를 제어한다.
        if (m_Grounded || m_AirControl)
        {
            if (m_Rigidbody2D.velocity.y < -limitFallSpeed)
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, -limitFallSpeed);
            // 목표 속도를 찾아 플레이어를 이동
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // 목표 속도를 부드럽게하고 캐릭터에 적용
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

            //입력이 플레이어를 오른쪽으로 이동하게 하고 플레이어가 왼쪽을 보고있을때
            if (move > 0 && !m_FacingRight)
            {
                // 뒤짚기
                Flip();
            }
            // 반대로 입력이 플레이어를 왼쪽으로 이동하게 하고 플레이어가 오른쪽을 보고 있을 때...
            else if (move < 0 && m_FacingRight)
            {
                // 뒤짚기
                Flip();
            }
            // 플레이어가 점프해야 하는 경우
            if (m_Grounded && jump)
            {
                // 플레이어에게 수직 값을 추가
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
                // 더블 점프 가능하고 벽 슬라이딩 중이 아닐 때
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
}
