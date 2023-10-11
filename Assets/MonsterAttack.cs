using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public GameObject rockPrefab; // ���� ������
    public Transform throwPoint; // ������ ��ȯ�� ��ġ
    public float throwInterval = 3.0f; // ���� ��ȯ �ֱ� (��)
    public float rockSpeed = 1.0f; // ���� �ӵ�
    public int rockDamage = 10; // ������ ���� ����

    private Transform player;
    private float nextThrowTime;

    private void Start()
    {
        // �÷��̾ ã�Ƽ� ������� ����
        player = GameObject.FindWithTag("Player").transform;

        // �ʱ� ���� ��ȯ ��� �ð� ����
        nextThrowTime = Time.time + throwInterval;
    }

    private void Update()
    {
        if (Time.time >= nextThrowTime)
        {
            // ���� ��ȯ
            ThrowRock();

            // ���� ���� ��ȯ �ð� ����
            nextThrowTime = Time.time + throwInterval;
        }
    }

    private void ThrowRock()
    {
        if (player == null)
        {
            return; // �÷��̾ ã�� �� ������ ������ ������ ����
        }

        // ������ ����
        GameObject rock = Instantiate(rockPrefab, throwPoint.position, Quaternion.identity);

        // ���� ���� ���� (�÷��̾ ���ϵ���)
        Vector2 throwDirection = (player.position - throwPoint.position).normalized;
        rock.GetComponent<Rigidbody2D>().velocity = throwDirection * rockSpeed;

    }
}
