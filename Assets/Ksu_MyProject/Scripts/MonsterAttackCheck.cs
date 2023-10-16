using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttackCheck : MonoBehaviour
{
    public int damageAmount = 10; // 투사체의 공격력

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("박쥐 바위공격 플레이어에게 충돌 확인");
            // 투사체를 제거합니다.
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("박쥐 바위공격이 다른 오브젝트와 충돌 확인");
            // 다른 오브젝트와 충돌한 경우 투사체를 제거합니다.
            Destroy(gameObject);
        }
    }
}

