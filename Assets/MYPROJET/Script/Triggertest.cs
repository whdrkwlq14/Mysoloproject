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
        Debug.Log("충돌한 오브젝트 : " + collision.name);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("해당 오브젝트 콜린더이름: " + collision.collider.name);
    }
}
