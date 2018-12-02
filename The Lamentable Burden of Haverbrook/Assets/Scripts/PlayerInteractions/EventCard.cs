using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventCard : ChoiceCard {


	public Animator anim;
	public string ID = null;
	/* List<ChoiceButton> buttons = new List<ChoiceButton>();
	// Use this for initialization
	void Awake () 
	{		
		ChoiceButton[] c_buttons = GetComponentsInChildren<ChoiceButton>();
		foreach(ChoiceButton c in c_buttons)
		{
			buttons.Add(c);
			c.Initialize();
		}
	}
	
	public void buttonPressed(float timeValue, ChoiceButton clickedButton)
	{
		foreach(ChoiceButton c in buttons)
		{
			if(c == clickedButton)
				continue;
			c.interactable = false;
		}
	} */

	public void initialize()
	{
		List<ChoiceButton> choiceButtons = new List<ChoiceButton>();
		ChoiceButton[] c_buttons = GetComponentsInChildren<ChoiceButton>();
		foreach(ChoiceButton c in c_buttons)
		{
			choiceButtons.Add(c);
			c.Initialize(this);
		}

		RectTransform thisTransform = GetComponent<RectTransform>();
		thisTransform.anchoredPosition = new Vector2(0,0);

		anim = GetComponent<Animator>();
	}

	public override void buttonPressed(float timeValue, ChoiceButton clickedButton)
	{
		base.buttonPressed(timeValue, clickedButton);
		GameManager.gameDaddy.restoreTime();
		anim.SetBool("close", true);
		Debug.Log("pressed event");
		//Destroy(this.gameObject);
	}

	public void animClose()
	{		
		Destroy(this.gameObject);
	}

	public void eventSpawned()
	{
		GameManager.gameDaddy.freezeTime();
	}

	public string getID(){return ID;}
}
