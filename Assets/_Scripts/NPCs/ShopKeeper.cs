using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeper : MonoBehaviour 
{

	[SerializeField] private GameObject shopMenu;
	
	private void OnTriggerEnter2D(Collider2D other) 
	{
		// Detect when the player is near
		if (other.tag == "Player")		{
			//Debug.Log("Player detected by ShopKeeper");
			Player player = other.GetComponent<Player>();
			if (player != null)
			{
				UIManager.Instance = OpenShop(player.loot); 
			}

			shopMenu.gameObject.SetActive(true);			
		}
		//Activate Shop
	}

	private void OnTriggerExit2D(Collider2D other) 
	{
		if (other.tag == "Player")
		{
			//Debug.Log("Player detected by ShopKeeper");			
			shopMenu.gameObject.SetActive(false);
		}

		// Detect when the player leaves
		// Disable Shop		
	}
	
}
