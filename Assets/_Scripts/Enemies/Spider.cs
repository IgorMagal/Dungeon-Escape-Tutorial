using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{
	[SerializeField] private GameObject acidPrefab;

	protected override void ScoutForPlayer()
	{
		if (Mathf.Abs(gameObject.transform.position.x - playerPos.position.x) > 5)
		{
		//	Debug.Log(this.gameObject.name + " resumes Roaming");
			anim.SetBool("InCombat",false);
			if (anim.GetCurrentAnimatorStateInfo(0).IsTag("attack") == false)			
				TurnAround();				
		}
		if (anim.GetBool("InCombat") == true)		
			CheckFacing();	
	}

	public void Spit()
	{
		Instantiate(acidPrefab,transform.position,Quaternion.identity);
	}


}
