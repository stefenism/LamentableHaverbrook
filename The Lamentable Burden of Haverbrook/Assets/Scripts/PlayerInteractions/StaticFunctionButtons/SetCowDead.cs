using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCowDead : MonoBehaviour {

	public void setCowDead()
	{
		EventManager.eventMomma.getStoryEvents().triggerFeedCow();
	}
}
