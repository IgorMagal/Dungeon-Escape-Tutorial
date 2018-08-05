using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour {

	public int value;



	private void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Player")
		{
			
			Debug.Log (value + " diamonds collected.");
			Destroy(this.gameObject);
		}
		
	}

}
