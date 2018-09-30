using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour 
{
   	private bool damaged = false;
	[SerializeField] private int weaponDamage = 1;
 
	private void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log("You hit " + other.gameObject.name);
		IDamageable hit = other.GetComponent<IDamageable>();
		if (hit != null && damaged == false)
		{
			hit.Damage(weaponDamage);
			damaged = true;
			StartCoroutine("damageCooldown");
		}							
	}
	
	IEnumerator damageCooldown()
	{			
		yield return new WaitForSeconds(1f);
		damaged = false;
	}

}
