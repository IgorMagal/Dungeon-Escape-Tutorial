using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	private Rigidbody2D rb2d;
	[SerializeField]private float moveSpeed = 3f;
	[SerializeField]private float jumpForce = 5f;
	private PlayerAnimation playerAnim;
	private SpriteRenderer playerSprite;
	
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();
		playerAnim = GetComponent<PlayerAnimation>();
		playerSprite = GetComponentInChildren<SpriteRenderer>();
	}

    private void FixedUpdate() 
	{		
		Movement();	
	}
    private void Movement()
    {	
        MoveHorizontal();
		Jump();		
    }
    private void MoveHorizontal()
    {
		float hInput = Input.GetAxisRaw("Horizontal");
		rb2d.velocity = new Vector2(hInput * moveSpeed,rb2d.velocity.y);
		CheckFacing(hInput);
		playerAnim.Move(hInput);
    }
	private void Jump()
	{
		if(Input.GetAxisRaw("Jump") > 0 && IsGrounded())
		{
			rb2d.velocity = new Vector2(rb2d.velocity.x,jumpForce);
			playerAnim.Jump(IsGrounded());
		}	
			
								
	}
    private bool IsGrounded()
    {
		RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,0.8f,1 << 8);
		//Debug.DrawRay(transform.position,Vector2.down,Color.red);
		if(hit.collider != null)
		return true;
		else return false;		
    }

	private void CheckFacing(float move)
	{
		if (move > 0)		
			playerSprite.flipX = false;		
		else if (move < 0)
			playerSprite.flipX = true;
	}
}
