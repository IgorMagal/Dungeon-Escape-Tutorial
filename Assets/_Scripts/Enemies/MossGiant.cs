using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy 
{
	

	protected override void Start() 
	{
		base.Start();					
	}

	public override void Update()
	{

		Roam();		
	}

	protected override void Roam()
	{		
		base.Roam();
	}

	protected override void Attack()
	{
		base.Attack();
		Debug.Log("Modified Attack being called from " + this.gameObject.name);
	}	
}
