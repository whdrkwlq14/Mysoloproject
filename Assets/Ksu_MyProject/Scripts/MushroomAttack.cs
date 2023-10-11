using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomAttack: MonoBehaviour
{
    public int damageAmount = 1; // 몬스터의 공격력
    private HealthBar playerHealthBar; // HealthBar 초기화

    private void Start()
    {
        // HealthBar 스크립트에 대한 참조를 가져옴
        playerHealthBar = GetComponent<HealthBar>();
        if (playerHealthBar == null)
        {
            Debug.Log("머쉬룸어택 스타트로그");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // 충돌한 게임 오브젝트가 "Player" 태그를 가지고 있다면
        {
            // 플레이어의 체력을 감소시킴 (피해 입힘)
            Debug.Log("머쉬룸 공격충돌됨");
            //playerHealthBar.TakeDamage(damageAmount);
        }
    }
}