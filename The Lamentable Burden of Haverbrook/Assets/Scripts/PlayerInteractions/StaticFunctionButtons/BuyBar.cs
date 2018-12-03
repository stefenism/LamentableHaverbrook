using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBar : MonoBehaviour {

	public void buyBar()
	{
		EventManager.eventMomma.getStoryEvents().triggerBarTwo();
	}
}
