using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigPlayer;
    [SerializeField] float _speed;
    [SerializeField] Transform _light;


    
    SpriteRenderer _renderer;
    bool _isjump;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rigPlayer = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * _speed;
        if (Input.GetKey(KeyCode.D))
        {

            _rigPlayer.velocity = new Vector2(x, _rigPlayer.velocity.y);

        }
        if (Input.GetKey(KeyCode.A))
        {

            _rigPlayer.velocity = new Vector2(x, _rigPlayer.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            x *= 3;
            _rigPlayer.velocity = new Vector2(x, _rigPlayer.velocity.y);
        }


        if (x > 0)
        {
            _renderer.flipX = false;
            _light.rotation = Quaternion.Euler(0,0,-90);
        }
        else if(x < 0)
        {
            _renderer.flipX = true;
            _light.rotation = Quaternion.Euler(0,0,90);
        }
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
