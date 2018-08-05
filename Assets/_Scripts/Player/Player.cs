using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable 
{
	private Rigidbody2D rb2d;
	[SerializeField] private float moveSpeed = 3f;
	[SerializeField] private float jumpForce = 6f;

	private PlayerAnimation playerAnim;
	private SpriteRenderer playerSprite;
	private SpriteRenderer swordArc;
	private bool grounded = false;

	int IDamageable.Health {get;set;}
	
	
	void Start ()
    {
        InitialiseComponents();		
    }

    private void InitialiseComponents()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
        playerSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
		swordArc = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() 
	{		
		Movement();	
		Attack();
		
	}
    private void Movement()
    {	
		grounded = IsGrounded(); // Check for grounded.

        float hInput = Input.GetAxisRaw("Horizontal"); // Run
		rb2d.velocity = new Vector2(hInput * moveSpeed,rb2d.velocity.y);
		CheckFacing(hInput);
		playerAnim.Move(hInput);

		if(Input.GetAxisRaw("Jump") > 0 && IsGrounded()) // Jump
		{
			rb2d.velocity = new Vector2(rb2d.velocity.x,jumpForce);
			playerAnim.Jump(true);			
		}
    }


	private void Attack()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0) && IsGrounded())	// Regular Attack.			
			playerAnim.Attack();					
	}
   
    private bool IsGrounded()
    {
		RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,0.8f,1 << 8);
		Debug.DrawRay(transform.position,Vector2.down,Color.red);
		if(hit.collider != null)
		{
			playerAnim.Jump(false);
			return true;
		}
		else return false;			
    }

	private void CheckFacing(float move)
	{
		if (move > 0)
		{
			playerSprite.flipX = false;
			swordArc.flipX = false;
			swordArc.flipY = false;
			Vector3 newPos = swordArc.transform.localPosition;
			newPos.x = 0.3f;
			swordArc.transform.localPosition = newPos;
			;	
		}				
		else if (move < 0)
		{
			playerSprite.flipX = true;
			swordArc.flipX = false;
			swordArc.flipY= true;			
			Vector3 newPos = swordArc.transform.localPosition;
			newPos.x = -0.3f;
			swordArc.transform.localPosition = newPos;
			
		}
			
	}

	void IDamageable.Damage(int damage)
	{
		Debug.Log(this.gameObject.name + " has been hit!");
	}
}
