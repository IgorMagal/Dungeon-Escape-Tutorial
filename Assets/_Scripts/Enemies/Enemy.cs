using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour 
{
	[SerializeField]protected int health;
	[SerializeField]protected int speed;
	[SerializeField]protected int loot;
	[SerializeField]protected Transform pointA,pointB;
	protected Transform destination;
	protected SpriteRenderer monsterSprite;
	protected Animator anim;


	protected virtual void Start()
    {
        destination = pointB;
        InitialiseComponents();
    }

    private void InitialiseComponents()
    {
        monsterSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    protected virtual void Attack()
	{
		Debug.Log("Base Attack being called from " + this.gameObject.name);
	}

	public abstract void Update();

	protected virtual void Roam()
	{
		if (CheckForIdle() == true)		
			return;
		else
		{
			CheckForDestination();
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position,destination.position,step);	
		}			
			
	}

	private void CheckForDestination()
	{				
		if (transform.position.x == pointA.position.x)
		{
			anim.SetTrigger("Idle");
			Invoke("CheckFacing",0.8f);			
			destination = pointB;			
		}		
						
		else if (transform.position.x == pointB.position.x)
		{
			anim.SetTrigger("Idle");
			Invoke("CheckFacing",0.8f);
			destination = pointA;			
		}			
	}
	private void CheckFacing()
	{
		if (monsterSprite.flipX == false)		
			monsterSprite.flipX = true;
		else monsterSprite.flipX = false; 
	}

	private bool CheckForIdle()
	{
		if(anim.GetCurrentAnimatorStateInfo(0).IsTag("idle"))
		return true;
		else return false;
	}	
}
