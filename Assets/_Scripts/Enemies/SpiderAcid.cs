using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAcid : MonoBehaviour 
{
	[SerializeField] private float speed;
	[SerializeField] private int weaponDamage;
	[SerializeField] private float destroyDelay;
	private Vector3 direction;
	
	private Transform player;	

	private void Awake() 
	{
		Destroy(gameObject,destroyDelay);
		player = GameObject.FindGameObjectWithTag("Player").transform;			
	}

	private void Start() 
	{
		CheckDirection();
	}
	private void Update() 
	{		
		transform.Translate(direction * speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player")
		{
			Debug.Log("You hit " + other.gameObject.name);
			IDamageable hit = other.GetComponent<IDamageable>();	
			hit.Damage(weaponDamage);
			Destroy(this.gameObject,0f);
		}
						
	}

	protected void CheckDirection()
	{
		float distance = player.transform.position.x - this.gameObject.transform.position.x;		
		if (distance > 0)		
			direction = Vector3.right;
		else if (distance < 0)
			direction = Vector3.left;
	}


	
}
