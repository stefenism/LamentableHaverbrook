using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Descriptors : MonoBehaviour {

	public string getHungerDescriptor()
	{
		Debug.Log("made it here");
		float currentHunger = GameManager.gameDaddy.getHunger();
		
		if(currentHunger > 0 && currentHunger <= 1)
			return 	"Satisfied";
		else if(currentHunger >= 2 && currentHunger <= 7)
			return "Craving";
		else if(currentHunger >= 8 && currentHunger <= 19)
			return "Hungry";
		else if(currentHunger >= 20 && currentHunger <= 29)
			return "Ravenous";
		else if(currentHunger >= 30 && currentHunger <= 49)
			return "Starving";
		else if(currentHunger >= 50 && currentHunger <= 79)
			return "Violent";
		else if(currentHunger >= 80 && currentHunger <= 89)
			return "Rioting";
		else if(currentHunger >= 90 && currentHunger <= 98)
			return "Breaking Free";
		else if(currentHunger >= 99 && currentHunger <= 100)
			return "Uncontrollable";
		
		else
			return "wha!?";
	}

	public string getHappinessDescriptor()
	{
		float currentHunger = GameManager.gameDaddy.getHappiness();
		
		if(currentHunger >= 0 && currentHunger <= 9)
			return "Hopeless";
		else if(currentHunger >= 10 && currentHunger <= 29)
			return "Despairing";
		else if(currentHunger >= 30 && currentHunger <= 49)
			return "Sad";
		else if(currentHunger >= 50 && currentHunger <= 69)
			return "Joyous";
		else if(currentHunger >= 70 && currentHunger <= 89)
			return "Jubilant";
		else if(currentHunger >= 90 && currentHunger <= 100)
			return "Overjoyed";
		
		else
			return "wha!?";
	}

	public string getSuspicionDescriptor()
	{
		float currentHunger = GameManager.gameDaddy.getSuspicion();
		
		if(currentHunger >= 0 && currentHunger <= 9)
			return "Oblivious";
		else if(currentHunger >= 10 && currentHunger <= 20)
			return "Mistrustful";
		else if(currentHunger >= 21 && currentHunger <= 35)
			return "Suspecting";
		else if(currentHunger >= 36 && currentHunger <= 60)
			return "Investigating ";
		else if(currentHunger >= 61 && currentHunger <= 79)
			return "Gathering Evidence";
		else if(currentHunger >= 80 && currentHunger <= 100)
			return "Fighting Back";
		
		else
			return "wha!?";
	}

	public string getFanatacismDescriptor()
	{
		float currentHunger = GameManager.gameDaddy.getFanatacism();
		
		if(currentHunger >= 0 && currentHunger <= 15)
			return "Disinterested";
		else if(currentHunger >= 16 && currentHunger <= 30)
			return "Sceptical";
		else if(currentHunger >= 31 && currentHunger <= 50)
			return "Passionate";
		else if(currentHunger >= 51 && currentHunger <= 70)
			return "Obsessive ";
		else if(currentHunger >= 71 && currentHunger <= 85)
			return "Devout";
		else if(currentHunger >= 86 && currentHunger <= 90)
			return "Zealous";
		else if(currentHunger >= 100)
			return "True Believers";
		
		else
			return "wha!?";
	}

	public string getPopulationDescriptor()
	{
		float currentHunger = GameManager.gameDaddy.getPopulation();

		if(currentHunger >= 0 && currentHunger <= 15)
			return "dispersed";
		else if(currentHunger >= 16 && currentHunger <= 30)
			return "sparse";
		else if(currentHunger >= 31 && currentHunger <= 50)
			return "Growing";
		else if(currentHunger >= 51 && currentHunger <= 70)
			return "Organized ";
		else if(currentHunger >= 71 && currentHunger <= 85)
			return "Lively";
		else if(currentHunger >= 86 && currentHunger <= 90)
			return "Bustling";
		else if(currentHunger >= 100)
			return "Thriving";
		
		else
			return "wha!?";
	}
}
