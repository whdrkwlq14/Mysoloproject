using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigPlayer;
    [SerializeField] float _speed;
   
    Transform _monster;

    float _jumpConut;
    bool _isGround = false;


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
        if (Input.GetKeyDown(KeyCode.Space) == true && (_jumpConut < 2 || _isGround == true))
        {
            _jumpConut++;
            _rigPlayer.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            _isGround = false;

        }

    }
     void OnCollisionExit2D(Collision2D collision) //Exit,엔터,스테이
    {       
        //if(collision.collider.name == "Ground")
        if (collision.collider.CompareTag("Jumping"))
        {
            _isGround = true;
            _jumpConut = 0;
        }


    }
}
