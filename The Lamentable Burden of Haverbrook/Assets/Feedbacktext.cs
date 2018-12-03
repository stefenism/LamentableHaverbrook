using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Feedbacktext : MonoBehaviour {

	// Use this for initialization
	float textAlpha = 1;
	Vector3 temp;
	public TextMeshProUGUI textObject;
	void Start () {
		temp = new Vector3(Random.Range(-0.4f,0.5f),Random.Range(0.4f,0.7f),0);

	}
	
	// Update is called once per frame
	void Update () {
		textObject.alpha=textAlpha;
		textAlpha-=0.01f;
		temp+=new Vector3(0,-0.02f,0);
		transform.position += temp;
	}
}
