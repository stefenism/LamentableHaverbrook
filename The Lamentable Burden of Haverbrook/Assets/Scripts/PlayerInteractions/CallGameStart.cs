using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallGameStart : MonoBehaviour {

	public void callGameStart()
	{
		EventManager.eventMomma.getStoryEvents().triggerStart();
	}
}
