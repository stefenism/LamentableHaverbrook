﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceCard : MonoBehaviour {

	public enum CardLevel
	{
		ONE,
		TWO,
		THREE,
	}

	public CardLevel cardLevel = CardLevel.ONE;
	public ChoiceButton[] defaultChoices;
	public ChoiceButton[] advancedChoices;

	
	List<ChoiceButton> buttons = new List<ChoiceButton>();
	// Use this for initialization
	void Awake () 
	{		
		ChoiceButton[] c_buttons = GetComponentsInChildren<ChoiceButton>();
		foreach(ChoiceButton c in c_buttons)
		{
			buttons.Add(c);
			c.Initialize(this);
		}
	}
	
	public virtual void buttonPressed(float timeValue, ChoiceButton clickedButton)
	{
		foreach(ChoiceButton c in buttons)
		{
			if(c == clickedButton)
				continue;
			c.interactable = false;
			c.Invoke("reEnableButton", timeValue);
		}
	}
}
