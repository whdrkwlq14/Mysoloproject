using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigPlayer;
    [SerializeField] float _speed;
   
    Transform _monster;

    float _jumpConut;
    bool _isjump;


    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            float x = Input.GetAxis("Horizontal") * _speed;
            // float y = Input.GetAxis("Vertical") * _speed; 물속체험
            _rigPlayer.velocity = new Vector2(x, _rigPlayer.velocity.y);

        }
        if (Input.GetKey(KeyCode.A))
        {
            float x = Input.GetAxis("Horizontal") * _speed;
            // float y = Input.GetAxis("Vertical") * _speed; 물속체험
            _rigPlayer.velocity = new Vector2(x, _rigPlayer.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float x = Input.GetAxis("Horizontal") * _speed * 2;
            _rigPlayer.velocity = new Vector2(x, _rigPlayer.velocity.y);
        }
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //  _rigPlayer.AddForce(Vector2.up * 10, ForceMode2D.Impulse);

        // }
        if (Input.GetKeyDown(KeyCode.Space) && !_isjump)
        {          
            _rigPlayer.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            _isjump = true;

        }

    }
     void OnCollisionExit2D(Collision2D collision) //Exit,엔터,스테이
    {
        //if(collision.collider.name == "Ground")
        if (collision.gameObject.tag == "Ground")
        {
            _isjump = false;
        }
    }
}
