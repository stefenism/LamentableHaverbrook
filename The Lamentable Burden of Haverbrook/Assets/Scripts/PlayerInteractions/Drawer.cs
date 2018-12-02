﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour {

	public enum PrimaryStat
	{
		SUSPICION,
		HAPPINESS,
		POPULATION,
		FANATICISM,
		HUNGER,
	}

	public PrimaryStat primaryStat = PrimaryStat.SUSPICION;
	const string OPEN_DRAWER_ANIM_STRING = "OpenDrawer";
	private Animator anim;	
	private Building building;
	private Status status;

	public List<EventCard> availableEvents = new List<EventCard>();
	public List<EventCard> spentEvents = new List<EventCard>();
	// Use this for initialization
	void Awake () 
	{
		anim = this.gameObject.GetComponent<Animator>();
		building = transform.parent.GetComponent<Building>();
		status = GetComponentInChildren<Status>();
	}
	
	public void initialize()
	{
		GameManager.gameDaddy.setCurrentDrawer(this);
		//OpenDrawer();
		status = GetComponentInChildren<Status>();
		status.initialize("boogidy");

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