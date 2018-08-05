using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
	[SerializeField]protected int health;
	[SerializeField]protected int speed;
	[SerializeField]protected int loot;
	[SerializeField]protected Transform pointA,pointB;
	protected Vector3 destination;
	protected SpriteRenderer monsterSprite;
	protected Animator anim;

	protected Transform playerPos;

	[SerializeField]protected GameObject diamondPrefab;

	int IDamageable.Health {get;set;}


	protected virtual void Start()
    {
        destination = pointB.position;
        InitComponents();
		
    }
    private void InitComponents()
    {
        monsterSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        anim = transform.GetChild(0).GetComponent<Animator>();
		playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    protected virtual void Attack()
	{
		Debug.Log("Base Attack being called from " + this.gameObject.name);
	}
	public virtual void Update()
	{
		Roam();
		ScoutForPlayer();
	}
	protected virtual void Roam()
	{
		if (MoveDelay())		
			return;
		else
		{
			CheckForDestination();
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position,destination,step);	
		}			
	}
	private void CheckForDestination()
	{				
		if (transform.position.x == pointA.position.x)
		{
			anim.SetTrigger("Idle");
			destination = pointB.position;
			Invoke("TurnAround",0.8f);			
						
		}		
						
		else if (transform.position.x == pointB.position.x)
		{
			anim.SetTrigger("Idle");
			destination = pointA.position;
			Invoke("TurnAround",0.8f);
						
		}			
	}
	protected void TurnAround()
	{
		if(destination == pointA.position && monsterSprite.flipX == false)		
			monsterSprite.flipX = true;
		else if(destination == pointB.position && monsterSprite.flipX == true)
			monsterSprite.flipX = false; 
	}
	private bool MoveDelay()
	{
		if(anim.GetCurrentAnimatorStateInfo(0).IsTag("idle") 
			|| anim.GetCurrentAnimatorStateInfo(0).IsTag("hit") 
			|| anim.GetCurrentAnimatorStateInfo(0).IsTag("dead") 
			|| anim.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
		return true;
		else return false;
	}

	void IDamageable.Damage(int damage)
	{			
		health -= damage;
		
		if (health > 0)
		{
			anim.SetTrigger("Hit");
			anim.SetBool("InCombat",true);
		}		
		else if (health <= 0)
		{			
			anim.SetTrigger("Die");
			anim.SetBool("InCombat",true);
			Invoke("Die",1.5f);
			DropDiamond();		
		}
	}

	protected virtual void ScoutForPlayer()
	{
		if (Mathf.Abs(gameObject.transform.position.x - playerPos.position.x) > 2)
		{
		//	Debug.Log(this.gameObject.name + " resumes Roaming");
			anim.SetBool("InCombat",false);
			if (anim.GetCurrentAnimatorStateInfo(0).IsTag("attack") == false)			
				TurnAround();				
		}
		if (anim.GetBool("InCombat") == true)		
			CheckFacing();		
	}

	protected void CheckFacing()
	{
		float distance = playerPos.transform.position.x - this.gameObject.transform.position.x;		
		if (distance > 0 && monsterSprite.flipX == true)		
			monsterSprite.flipX = false;
		else if (distance < 0 && monsterSprite.flipX == false)
			monsterSprite.flipX = true;
	}

	private void Die()
	{		
		Destroy(this.gameObject);
				
	}

	private void DropDiamond()
	{
		Instantiate(diamondPrefab,this.transform.position,Quaternion.identity);
	}	
}
