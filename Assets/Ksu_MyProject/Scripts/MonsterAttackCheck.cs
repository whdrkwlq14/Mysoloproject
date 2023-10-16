using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackCheck : MonoBehaviour
{
    public int damageAmount = 10; // ����ü�� ���ݷ�
    private HealthBar playerHealthBar;

    private void Start()
    {
        // HealthBar ��ũ��Ʈ�� ���� ������ ������
        playerHealthBar = GetComponent<HealthBar>();
        if (playerHealthBar == null)
        {
            Debug.Log("������� ����");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("���� �������� �÷��̾�� �浹 Ȯ��");
            // ����ü�� �����մϴ�.
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("���� ���������� �ٸ� ������Ʈ�� �浹 Ȯ��");
            // �ٸ� ������Ʈ�� �浹�� ��� ����ü�� �����մϴ�.
            Destroy(gameObject);
        }
    }
}

