using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth; //현재 생명력
    public SpriteRenderer playerRenderer;
    public bool isFlashing = false;
    public float flashDuration = 0.1f;
    public float flashTimer = 2f;

    public void Start()
    {

        currentHealth = maxHealth; // 시작시 현재 생명력이 최대 일경우 초기화
        playerRenderer = GetComponent <SpriteRenderer>();
    }
    public void Update()
    {
        if (isFlashing)
        {
            flashTimer += Time.deltaTime;

            if(flashTimer >= flashDuration)
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
    public void StartFlashingEffect()
    {
        isFlashing = true;
        flashTimer = 0f;
    }

    public void TakeDamge(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= 1;//플레이어의 생명력이 1 감소한다
            StartFlashingEffect();

        }
        if (currentHealth <= 0)
        {
            Die(); //생명력이 0이하로 떨어졌을 때 처리할 함수 호출
        }
    }
    public void Die()
    {
        Debug.Log("플레이어 사망");
    }
}

