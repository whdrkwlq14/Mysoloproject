using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigPlayer;
    [SerializeField] float power;
    [SerializeField] Transform pos;
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask islayer;

    bool isGround;

    void Start()
    {
        _rigPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGround = Physics2D.OverlapCircle(pos.position, checkRadius,islayer);
        if (isGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            _rigPlayer.AddForce(Vector2.up * 2, ForceMode2D.Impulse);       
        }

    }
    void OnCollisionExit2D(Collision2D collision) //Exit,엔터,스테이
    {
        if(collision.collider.name == "Ground")
        if (collision.gameObject.tag == "Ground")
        {
            //_isjump = false;
            
        }
    }
}

