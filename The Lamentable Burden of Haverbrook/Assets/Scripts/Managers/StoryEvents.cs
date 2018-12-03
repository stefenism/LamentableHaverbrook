using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEvents : MonoBehaviour {
	
	public List<EventCard> storyEvents = new List<EventCard>();
	public List<EventCard> spentStoryEvents = new List<EventCard>();

	public float fadeOutTime = 5;

	bool cowDead = false;
	bool townQuired = false;
	bool barQuired = false;
	bool barQuired2 = false;
	bool churchQuired = false;
	bool churchQuired2 = false;
	bool cityQuired = false;
	bool cityQuired2 = false;
	bool policeQuired = false;
	bool policeQuired2 = false;
	bool allBuildings = false;

	bool barLevelTwo = false;
	bool cityLevelTwo = false;
	bool policeLevelTwo = false;
	bool churchLevelTwo = false;
	bool churchLevelThree = false;

	const string COWDIED_EVENT_NAME = "CowDied";
	const string TOWN_EVENT_NAME = "Town";
	const string BAR1_EVENT_NAME = "Bar1";
	const string BAR2_EVENT_NAME = "Bar2";
	const string POLICE1_EVENT_NAME = "Police1";
	const string POLICE2_EVENT_NAME = "Police2";
	const string CITY_HALL1_EVENT_NAME = "City1";
	const string CITY2_EVENT_NAME = "City2";
	const string CHURCH1_EVENT_NAME = "Church1";
	const string CHURCH_CONVERSION_EVENT_NAME = "Church2";
	const string WIN_GAME_EVENT_NAME = "Win";
	const string ENDING1_NAME = "Ending1-1";
	const string ENDING21_NAME = "Ending2-1";
	const string ENDING22_NAME = "Ending2-2";
	const string ENDING23_NAME = "Ending2-3";
	const string ENDINGSUS1_NAME = "EndingSuspicion1";
	const string ENDINGSUS2_NAME = "EndingSuspicion2";
	const string ENDINGSUS3_NAME = "EndingSuspicion3";

	void Awake()
	{		
	}
	public void CheckEvents()
	{
		CheckField();
		CheckBar();
		CheckChurch();
		CheckCityHall();
		CheckPolice();
		CheckEnding1();
		CheckEnding2();
		CheckEndingSuspicion();

		CheckAllBuildings();
	}

	void CheckField()
	{
		if(GameManager.gameDaddy.getBlood() >= 3 && !cowDead)
		{
			EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, COWDIED_EVENT_NAME);
			cowDead = true;
		}			

		if(GameManager.gameDaddy.getCowDead() >= 3 && !townQuired)
		{
			EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, TOWN_EVENT_NAME);
			townQuired = true;
			triggerBar();
		}			
	}
	void CheckBar()
	{
		if(barQuired && allBuildings && !barLevelTwo)
		{
			GameManager.gameDaddy.barBuilding.getDrawer().enableLevelTwoCards();
			barLevelTwo = true;
		}			
	}

	void CheckChurch()
	{
		if(GameManager.gameDaddy.getFanatacism() >= 10 && !churchQuired)
		{
			EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, CHURCH1_EVENT_NAME);
			churchQuired = true;
		}

		if(GameManager.gameDaddy.getFanatacism() >= 60 && churchQuired && !churchLevelTwo)
		{
			GameManager.gameDaddy.churchBuilding.getDrawer().enableLevelTwoCards();
			churchLevelTwo = true;
		}

		if(GameManager.gameDaddy.getFanatacism() >= 100 && churchQuired && churchLevelTwo)
		{
			GameManager.gameDaddy.churchBuilding.getDrawer().enableLevelThreeCards();
			churchLevelThree = true;
		}
	}

	void CheckCityHall()
	{
		if((GameManager.gameDaddy.getHappiness() < 50 || GameManager.gameDaddy.getHappiness() > 70) && !cityQuired)
		{
			EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, CITY_HALL1_EVENT_NAME);
			cityQuired = true;
		}

		if(GameManager.gameDaddy.getPopulation() >= 40 && !cityLevelTwo)
		{
			GameManager.gameDaddy.cityBuilding.getDrawer().enableLevelTwoCards();
			cityLevelTwo = true;
		}	
	}

	void CheckPolice()
	{
		if(GameManager.gameDaddy.getSuspicion() >= 10 && !policeQuired)
		{
			EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, POLICE1_EVENT_NAME);
			policeQuired = true;
		}			

		if(GameManager.gameDaddy.getFanatacism() >= 30 && !policeLevelTwo && policeQuired)
		{
			GameManager.gameDaddy.policeBuilding.getDrawer().enableLevelTwoCards();
			policeLevelTwo = true;
		}
	}

	void CheckEnding1()
	{
		if(!churchQuired)
			if(GameManager.gameDaddy.getHunger() >= 30)
			{
				EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, ENDING1_NAME);
				StartCoroutine(triggerFadeOut(fadeOutTime));
			}				
	}

	void CheckEnding2()
	{
		if(churchQuired && GameManager.gameDaddy.getHunger() >= 100)
		{
			EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, ENDING21_NAME);
			StartCoroutine(triggerHungerEnding(5));
		}
	}

	void CheckEndingSuspicion()
	{
		if(GameManager.gameDaddy.getSuspicion() >= 100)
		{
			EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, ENDINGSUS1_NAME);
			StartCoroutine(triggerSusEnding(10));
		}
	}

	public void triggerTown()
	{
		EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, TOWN_EVENT_NAME);
		StartCoroutine(triggerTownEvent(30));
	}
	public void triggerBar()
	{
		StartCoroutine(triggerBarEvent(30));
	}

	public void triggerStart()
	{
		Debug.Log("game has started officially");
		GameManager.gameDaddy.setHungerTime(5);
		GameManager.gameDaddy.setPopulation(20);
		GameManager.gameDaddy.setSuspicion(0);
		GameManager.gameDaddy.setFanaticism(0);

		EventManager.eventMomma.startGame();
	}

	public void triggerBarTwo()
	{
		StartCoroutine(triggerBarEventTwo(10));
	}

	public void triggerCityTwo()
	{
		StartCoroutine(triggerCityEventTwo(25));
	}
	
	public void triggerPoliceTwo()
	{
		StartCoroutine(triggerPoliceEventTwo(20));
	}

	public void triggerConvertChurch()
	{
		StartCoroutine(triggerChurchConvertEvent(20));
	}

	public void triggerResearchEndTimes()
	{
		StartCoroutine(triggerResearchEndTimesEvent(20));
	}

	public void triggerGatherCultists()
	{
		StartCoroutine(triggerGatherCultistsEvent(20));
	}

	public void triggerSacrificeTown()
	{
		StartCoroutine(triggerSacrificeTownEvent(20));
	}

	public void Update()
	{
		/* if(Input.GetKeyDown(KeyCode.E))
		{
			Debug.Log("pressed key");
			triggerBuyBar();
		} */
	}
	public void triggerBuyBar()
	{		
		List<ChoiceCard> choiceCards = GameManager.gameDaddy.barBuilding.getDrawer().choiceCards;
		ChoiceButton buyBarButton = choiceCards.Find(x => x.isLevelTwo()).gameObject.GetComponent<SpecialButton>().specialButton;
		Debug.Log("buy bar button: " + buyBarButton);
		buyBarButton.gameObject.SetActive(true);
		
	}

	public void triggerRunOffice()
	{
		List<ChoiceCard> choiceCards = GameManager.gameDaddy.cityBuilding.getDrawer().choiceCards;
		ChoiceButton runOfficeButton = choiceCards.Find(x => x.isLevelTwo()).gameObject.GetComponent<SpecialButton>().specialButton;
		Debug.Log("buy bar button: " + runOfficeButton);
		runOfficeButton.gameObject.SetActive(true);
	}

	public void CheckAllBuildings()
	{
		if(barQuired && cityQuired && churchQuired && policeQuired && !allBuildings)
		{
			allBuildings = true;
			triggerBuyBar();
		}			
	}

	IEnumerator triggerTownEvent(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, BAR1_EVENT_NAME);
		barQuired = true;
	}
	IEnumerator triggerBarEvent(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, BAR1_EVENT_NAME);
		barQuired = true;

		//make bar visible activated
		//play nw building sound
		GameManager.gameDaddy.barBuilding.gameObject.SetActive(true);
		AudioManager.PlaySound(AudioManager.instance.sfxSource, AudioManager.instance.newBuilding, 50);
		
		//lose town todo
		//GameManager.gameDaddy.loseTown();

	}

	IEnumerator triggerBarEventTwo(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, BAR2_EVENT_NAME);
		barQuired2 = true;
	}

	IEnumerator triggerCityEventTwo(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, CITY2_EVENT_NAME);
		cityQuired2 = true;
	}

	IEnumerator	triggerPoliceEventTwo(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, POLICE2_EVENT_NAME);
		policeQuired2 = true;
	}

	IEnumerator triggerChurchConvertEvent(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, CHURCH_CONVERSION_EVENT_NAME);
		churchQuired2 = true;
	}

	IEnumerator triggerResearchEndTimesEvent(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		//trigger change button to gather cultists
	}

	IEnumerator triggerGatherCultistsEvent(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		//trigger change button to sacrifice the town
	}

	IEnumerator triggerSacrificeTownEvent(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, WIN_GAME_EVENT_NAME);
		StartCoroutine(triggerFadeOut(fadeOutTime));
	}

	IEnumerator triggerFadeOut(float seconds)
	{
		yield return null;
		//write a fade out section here
	}

	IEnumerator triggerHungerEnding(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, ENDING22_NAME);
		yield return new WaitForSeconds(7);
		EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, ENDING23_NAME);
		StartCoroutine(triggerFadeOut(fadeOutTime));
	}

	IEnumerator triggerSusEnding(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, ENDINGSUS2_NAME);
		yield return new WaitForSeconds(10);
		EventManager.eventMomma.drawCard(EventManager.eventMomma.storyEvents, ENDINGSUS3_NAME);
		StartCoroutine(triggerFadeOut(fadeOutTime));
	}
}
