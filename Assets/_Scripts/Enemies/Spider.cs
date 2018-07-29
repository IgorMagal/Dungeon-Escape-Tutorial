using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy 
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

}
