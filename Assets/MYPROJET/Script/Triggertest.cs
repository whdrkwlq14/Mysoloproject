using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggertest : MonoBehaviour
{
    Rigidbody rigid;
    void start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�浹�� ������Ʈ : " + collision.name);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�ش� ������Ʈ �ݸ����̸�: " + collision.collider.name);
    }
}
