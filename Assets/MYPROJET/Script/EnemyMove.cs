using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    Rigidbody2D rigid;

    public int nextMove;



    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();


        Invoke("Think", 0.5f);
    }
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        //
        Vector2 Vec2 = new Vector2(rigid.position.x, rigid.position.y);
    }
    void Think()
    {
        nextMove = Random.Range(-3,3);
        Invoke("Think", 0.5f);

    }
}
