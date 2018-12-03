using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Status : MonoBehaviour {

	public string status = "null";
	private string statusType = null;
	public TextMeshProUGUI statusText;

	public void initialize(Drawer.PrimaryStat stat)
	{
		statusText = GetComponentInChildren<TextMeshProUGUI>();
		Debug.Log("stat: " + stat);
		Debug.Log("status text: " + statusText);
		statusText.text = getStatus(stat);
	}


	public string getStatus(Drawer.PrimaryStat stat)
	{
		switch(stat)
		{
			case Drawer.PrimaryStat.HUNGER:
			{
				Debug.Log("stat2: " + stat);
				Debug.Log("status: " + status);
				return status + GameManager.gameDaddy.getDescriptors().getHungerDescriptor() + "";				
			}
			case Drawer.PrimaryStat.HAPPINESS:
				return status + GameManager.gameDaddy.getDescriptors().getHappinessDescriptor();
			case Drawer.PrimaryStat.FANATICISM:
				return status + GameManager.gameDaddy.getDescriptors().getFanatacismDescriptor();
			case Drawer.PrimaryStat.POPULATION:
				return status + GameManager.gameDaddy.getDescriptors().getPopulationDescriptor();
			case Drawer.PrimaryStat.SUSPICION:
				return status + GameManager.gameDaddy.getDescriptors().getSuspicionDescriptor();

			default:
				return "wha!?";

		}
	}
}
