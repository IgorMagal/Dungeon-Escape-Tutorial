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
		if (other.tag == "Player")		
		{					
			Player player = other.GetComponent<Player>();
			if (player != null)
			{
				UIManager.Instance.OpenShop(player.loot);
				player.shopping = true;				
			}
			shopMenu.gameObject.SetActive(true);			
		}		
	}

	private void OnTriggerExit2D(Collider2D other) 
	{
		if (other.tag == "Player")
		{
			Player player = other.GetComponent<Player>();										
			shopMenu.gameObject.SetActive(false);
			player.shopping = false;
		}	
	}

	public void SelectItem(int itemNumber)
	{
		Debug.Log("You've selected " + itemNumber);
		
	
	}
	
}
