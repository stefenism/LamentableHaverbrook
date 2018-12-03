using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunOffice : MonoBehaviour {

	public void runForOffice()
	{
		EventManager.eventMomma.getStoryEvents().triggerCityTwo();
	}
}
