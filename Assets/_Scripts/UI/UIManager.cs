using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public Text gemCountText;

	public void OpenShop(int gemCount)
	{
		gemCountText.Text = (int)gemCount.ToString();
	}

	
	//Sigleton Code
	private static UIManager _instance;
	public static UIManager Instance
	{
		get
		{
			if (_instance == null)
			{
				Debug.LogError("Instance is null :(");
			}
			return _instance;
		}
	}	
	private void Awake() 
	{
		_instance = this;
	}

	


}
