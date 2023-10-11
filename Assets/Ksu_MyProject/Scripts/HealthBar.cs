using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // 스크롤바
    public Text healthText; // 체력 텍스트 표시

    public float maxHealth = 100;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); // 최소값과 최대값 설정

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // 플레이어가 사망할 때 할 작업을 여기에 추가 (애니메이션 다이 실행후 오브젝트 파괴후 재생성)
        }
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
        healthText.text = "Health: " + currentHealth.ToString("0") + " / " + maxHealth;
    }

}