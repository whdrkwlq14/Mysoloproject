using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAttack: MonoBehaviour
{
    public int damageAmount = 1; // ������ ���ݷ�
    private HealthBar playerHealthBar; // HealthBar �ʱ�ȭ

    private void Start()
    {
        // HealthBar ��ũ��Ʈ�� ���� ������ ������
        playerHealthBar = GetComponent<HealthBar>();
        if (playerHealthBar == null)
        {
            Debug.Log("�ӽ������ ��ŸƮ�α�");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // �浹�� ���� ������Ʈ�� "Player" �±׸� ������ �ִٸ�
        {
            // �÷��̾��� ü���� ���ҽ�Ŵ (���� ����)
            Debug.Log("�ӽ��� �����浹��");
            //playerHealthBar.TakeDamage(damageAmount);
        }
    }
}