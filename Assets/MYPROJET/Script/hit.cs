using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }
    void onCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            OnDamaged(collision.transform.position);
        }
    }
    void OnDamaged(Vector2 targetPos)
    {
        gameObject.layer = 9;
    }
}
