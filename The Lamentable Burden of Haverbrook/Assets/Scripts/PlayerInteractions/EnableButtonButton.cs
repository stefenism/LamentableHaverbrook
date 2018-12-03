using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableButtonButton : MonoBehaviour {

	public ChoiceButton buttonToEnable;
	public ChoiceCard parentCard;
	public float secondsToEnable;
	
	public void enableButton()
	{
		if(buttonToEnable.gameObject.activeSelf)
			return;

		buttonToEnable.gameObject.SetActive(true);
		buttonToEnable.interactable = false;
		parentCard.updateButtons(buttonToEnable);
		buttonToEnable.Initialize(parentCard);
		Invoke("setReady", secondsToEnable);
	}

	public void setReady()
	{
		buttonToEnable.interactable = true;
	}
}
