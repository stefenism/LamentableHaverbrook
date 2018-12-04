using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Feedbacktext : MonoBehaviour {

	// Use this for initialization

	public bool dontDestroy;
	float textAlpha = 1;

	public string text;
	Vector3 temp;
	public TextMeshProUGUI textObject;
	void Start () {
		temp = new Vector3(Random.Range(-0.4f,0.5f),Random.Range(0.4f,0.7f),0);
		textObject.text =text;
	}

	public void initialize(string newText)
	{
		text = newText;
		temp = new Vector3(Random.Range(-0.4f,0.5f),Random.Range(0.4f,0.7f),0);
		textObject.text = text;
	}
	
	// Update is called once per frame
	public void Update () {
		if(dontDestroy)
			return;

		textObject.alpha=textAlpha;
		textAlpha-=0.01f;
		temp+=new Vector3(0,-0.02f,0);
		transform.position += temp;
		if(textAlpha<0){
			Destroy(this.gameObject);
		}
	}
}
