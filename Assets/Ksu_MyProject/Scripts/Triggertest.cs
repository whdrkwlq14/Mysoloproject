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
        Debug.Log("충돌한 오브젝트 : " + collision.name);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("해당 오브젝트 콜린더이름: " + collision.collider.name);
    }
}
