using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggertest : MonoBehaviour
{
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�浹�� ������Ʈ : " + collision.name);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�ش� ������Ʈ �ݸ����̸�: " + collision.collider.name);
    }
}
