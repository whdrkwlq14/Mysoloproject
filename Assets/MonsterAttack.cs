using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    public GameObject rockPrefab; // 바위 프리팹
    public Transform throwPoint; // 바위가 소환될 위치
    public float throwInterval = 3.0f; // 바위 소환 주기 (초)
    public float rockSpeed = 1.0f; // 바위 속도
    public int rockDamage = 10; // 바위로 인한 피해

    private Transform player;
    private float nextThrowTime;

    private void Start()
    {
        // 플레이어를 찾아서 대상으로 설정
        player = GameObject.FindWithTag("Player").transform;

        // 초기 바위 소환 대기 시간 설정
        nextThrowTime = Time.time + throwInterval;
    }

    private void Update()
    {
        if (Time.time >= nextThrowTime)
        {
            // 바위 소환
            ThrowRock();

            // 다음 바위 소환 시간 설정
            nextThrowTime = Time.time + throwInterval;
        }
    }

    private void ThrowRock()
    {
        if (player == null)
        {
            return; // 플레이어를 찾을 수 없으면 바위를 던지지 않음
        }

        // 바위를 생성
        GameObject rock = Instantiate(rockPrefab, throwPoint.position, Quaternion.identity);

        // 바위 방향 설정 (플레이어를 향하도록)
        Vector2 throwDirection = (player.position - throwPoint.position).normalized;
        rock.GetComponent<Rigidbody2D>().velocity = throwDirection * rockSpeed;

    }
}
