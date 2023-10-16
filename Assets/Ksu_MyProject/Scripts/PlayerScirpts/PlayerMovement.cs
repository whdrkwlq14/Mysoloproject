using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

    public Animator animator;
    [SerializeField] Transform _light;



    public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	
	void Update () 
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;
		}
	}

	public void OnFall()
	{
		animator.SetBool("IsJumping", true);
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime,jump);
		jump = false;
    }

}
