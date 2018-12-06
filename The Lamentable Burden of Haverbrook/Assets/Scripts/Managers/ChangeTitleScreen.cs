using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeTitleScreen : MonoBehaviour {


	public Image fadeImage;
	public float timeToFade;
	// Use this for initialization
	void Start () {
		StartCoroutine(openGameScene());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator openGameScene()
	{
		Debug.Log("started");
		float currentTime = 0;
		Color imageColor = fadeImage.color;
		imageColor.a = 0;

		yield return new WaitForSeconds(3);

		while(currentTime < timeToFade)
		{
			currentTime += Time.deltaTime;
			imageColor.a = (currentTime / timeToFade);			
			fadeImage.color = imageColor;
			yield return null;
		}

		SceneManager.LoadScene("StefenTestScene", LoadSceneMode.Single);
	}
}
