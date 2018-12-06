using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealPolice : MonoBehaviour {

	public void triggerPoliceDeal()
	{
		EventManager.eventMomma.getStoryEvents().triggerPoliceTwo();
	}
}
