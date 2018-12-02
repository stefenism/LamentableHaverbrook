using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Status : MonoBehaviour {

	private string status = null;
	private string statusType = null;
	private TextMeshProUGUI statusText;

	public void initialize(string stat)
	{
		statusText = GetComponent<TextMeshProUGUI>();
		statusType = stat;
	}


	public void setStatus(string newStatus, string message)
	{
		status = newStatus;
		statusText.text = message + " " + status;
	}
}
