using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth; //���� �����
    public SpriteRenderer playerRenderer;
    public bool isFlashing = false;
    public float flashDuration = 0.1f;
    public float flashTimer = 2f;

    public void Start()
    {

        currentHealth = maxHealth; // ���۽� ���� ������� �ִ� �ϰ�� �ʱ�ȭ
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
            currentHealth -= 1;//�÷��̾��� ������� 1 �����Ѵ�
            StartFlashingEffect();

        }
        if (currentHealth <= 0)
        {
            Die(); //������� 0���Ϸ� �������� �� ó���� �Լ� ȣ��
        }
    }
    public void Die()
    {
        Debug.Log("�÷��̾� ���");
    }
}

