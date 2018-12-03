using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SacrificeTown : MonoBehaviour {

	public void sacrificeTown()
	{
		EventManager.eventMomma.getStoryEvents().triggerSacrificeTown();
	}
}
