using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurchEnableButtonButton : EnableButtonButton {

	public override void enableButton()
	{
		base.enableButton();
		this.gameObject.SetActive(false);
	}
}
