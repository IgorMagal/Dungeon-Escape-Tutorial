using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour 
{
	private Animator playerAnim;
	private Animator swordArc;

	void Start () 
	{
		playerAnim = transform.GetChild(0).GetComponent<Animator>();
		swordArc = transform.GetChild(1).GetComponent<Animator>();
	}
	
	public void Move(float speed)
	{
		playerAnim.SetFloat("moveSpeed",Mathf.Abs(speed));
	}

	public void Jump(bool jump)
	{
		playerAnim.SetBool("isJumping",jump);
	}

	public void Attack()
	{
		playerAnim.SetTrigger("Attack");
		swordArc.SetTrigger("Swing");
	}

}
