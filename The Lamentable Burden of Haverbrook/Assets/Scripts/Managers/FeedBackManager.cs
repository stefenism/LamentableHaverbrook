using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedBackManager : MonoBehaviour {

	public static FeedBackManager feedDaddy = null;

	public Feedbacktext textSpawn;

	void Awake()
	{
		if(feedDaddy == null)
			feedDaddy = this;

		else if(feedDaddy == this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

	}

	public void spawnFeedbackText(Transform newTransform, string stat, float value)
	{
		Feedbacktext textClone = Instantiate(textSpawn) as Feedbacktext;
		Vector3 alteredPosition = newTransform.position;
		alteredPosition.x += 70;
		textClone.transform.parent = GameManager.gameDaddy.canvas.transform;
		textClone.transform.position = alteredPosition;		
		textClone.dontDestroy = false;
		if(Mathf.Sign(value) < 0)
		{
			textClone.initialize("-" + value + " " + stat);
		}
		else
			textClone.initialize("+" + value + " " + stat);
	}


}
