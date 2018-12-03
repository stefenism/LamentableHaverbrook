using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertChurch : MonoBehaviour {

	public void convertChurch()
	{
		EventManager.eventMomma.getStoryEvents().triggerConvertChurch();
	}
}
