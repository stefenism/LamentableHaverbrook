using System.Collections;
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

	public List<ChoiceCard> choiceCards = new List<ChoiceCard>();
		
	// Use this for initialization
	void Awake () 
	{
		anim = this.gameObject.GetComponent<Animator>();
		building = transform.parent.GetComponent<Building>();
		status = GetComponentInChildren<Status>();

		enableLevelOneCards();
	}
	
	public void initialize()
	{
		GameManager.gameDaddy.setCurrentDrawer(this);
		//OpenDrawer();
		status = GetComponentInChildren<Status>();
		status.initialize(primaryStat);

		AudioManager.PlaySound(AudioManager.instance.sfxSource, AudioManager.instance.menuOpen, 1);

	}

	public void OpenDrawer()
	{
		anim.SetBool(OPEN_DRAWER_ANIM_STRING, true);

	}

	public void closeDrawer()
	{
		anim.SetBool(OPEN_DRAWER_ANIM_STRING, false);
		building.closeBuilding();

		AudioManager.PlaySound(AudioManager.instance.sfxSource, AudioManager.instance.menuClose, 1);
	}

	public void drawerClosed()
	{
		this.gameObject.SetActive(false);
	}

	public void enableLevelOneCards()
	{
		foreach(ChoiceCard c in choiceCards)
		{
			if(!c.isLevelOne())
				c.gameObject.SetActive(false);						
		}
	}	

	public void enableLevelTwoCards()
	{
		foreach(ChoiceCard c in choiceCards)
		{
			if(c.isLevelTwo())
			{
				c.gameObject.SetActive(true);				
			}				
		}
	}

	public void enableLevelThreeCards()
	{
		foreach(ChoiceCard c in choiceCards)
		{
			if(c.isLevelThree())
			{
				c.gameObject.SetActive(true);
			}
		}
	}

	public Animator getAnimator()
	{
		return anim;
	}
}
