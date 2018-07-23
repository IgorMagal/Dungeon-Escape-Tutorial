using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour 
{
	Animator playerAnim;

	void Start () 
	{
		playerAnim = GetComponentInChildren<Animator>();
	}
	
	public void Move(float speed)
	{
		playerAnim.SetFloat("moveSpeed",Mathf.Abs(speed));
	}

	public void Jump(bool jump)
	{
		playerAnim.SetBool("isJumping",jump);
	}

}
