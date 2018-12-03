using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Status : MonoBehaviour {

	public string status = "null";
	public string status2 = "null";
	private string statusType = null;
	public TextMeshProUGUI statusText;
	Drawer.PrimaryStat statSaved;
	

	public void initialize(Drawer.PrimaryStat stat)
	{
		statusText = GetComponentInChildren<TextMeshProUGUI>();
		//statusText.text = getStatus(stat);
		statSaved= stat;
	}
	void Update()
    {
        statusText.text = getStatus(statSaved);
    }

	public string getStatus(Drawer.PrimaryStat stat)
	{
		switch(stat)
		{
			case Drawer.PrimaryStat.HUNGER:
			{
				return status + GameManager.gameDaddy.getDescriptors().getHungerDescriptor() + "\n" + 
				status2 +": " +GameManager.gameDaddy.getCow();				
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
