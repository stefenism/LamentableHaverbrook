using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour {

	const string OPEN_DRAWER_ANIM_STRING = "OpenDrawer";
	private Animator anim;	
	private Building building;

	// Use this for initialization
	void Awake () 
	{
		anim = this.gameObject.GetComponent<Animator>();
		building = transform.parent.GetComponent<Building>();
	}
	
	public void initialize()
	{
		GameManager.gameDaddy.setCurrentDrawer(this);

	}

	public void OpenDrawer()
	{
		anim.SetBool(OPEN_DRAWER_ANIM_STRING, true);
	}

	public void closeDrawer()
	{
		anim.SetBool(OPEN_DRAWER_ANIM_STRING, false);
		building.closeBuilding();
	}

	public void drawerClosed()
	{
		this.gameObject.SetActive(false);
	}
}
