using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour 
{
	#region SingletonCode	
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
	#endregion 
	
	public Text gemCountText;
	public Image selectionImg;
	
	public void OpenShop(int gemCount)
	{
		gemCountText.text = gemCount.ToString() + "G";
	}
	
	public void UpdateSelectionPos(int yPos)
	{
		selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x,yPos);		
	}


}
