using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public int nextMove;

    // Update is called once per frame
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        Invoke("Think", 1f);
    }
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        //ÇÃ·§ÆûÃ¼Å© 
        Vector2 frontVec = new Vector2(rigid.position.x, rigid.position.y);
        Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
        //RaycastHit2D rayHit = physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
       // if(rayHit.collider != null)
        //{
        //    if (rayHit.distance < 0.5f)
        //    {
                
       //     }
       // }
    }
    void Think()
    {
        nextMove = Random.Range(-5,5);
        Invoke("Think", 1f);

    }
}
