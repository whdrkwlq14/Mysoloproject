using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; // ��ũ�ѹ�
    public Text healthText; // ü�� �ؽ�Ʈ ǥ��

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
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth); // �ּҰ��� �ִ밪 ����

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // �÷��̾ ����� �� �� �۾��� ���⿡ �߰� (�ִϸ��̼� ���� ������ ������Ʈ �ı��� �����)
        }
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth;
        healthText.text = "Health: " + currentHealth.ToString("0") + " / " + maxHealth;
    }

}