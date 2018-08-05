using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpitEvent : MonoBehaviour
{

	private Spider spider;

	private void Start() 
	{
		spider = GetComponentInParent<Spider>();	
	}

	private void Fire()
	{	
		spider.Spit();				
	}	
}
