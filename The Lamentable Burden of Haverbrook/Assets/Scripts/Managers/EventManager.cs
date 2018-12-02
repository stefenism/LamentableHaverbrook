﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public static EventManager eventMomma = null;

	public List<EventCard> storyEvents = new List<EventCard>();
	public List<EventCard> spentStoryEvents = new List<EventCard>();

	int drawCardChance = 5;
	int missedDraw = 0;

	void Awake()
	{
		if(eventMomma == null)
			eventMomma = this;

		else if (eventMomma == this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

		//shuffle deck
	}

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.E))
			drawCard(storyEvents, "1");

		if(Input.GetKeyDown(KeyCode.D))
			GameManager.gameDaddy.getCurrentDrawer().enableLevelTwoCards();
	}

	public void checkDraw()
	{
		int roll = Random.Range(0, 100);
		if(roll <= drawCardChance + missedDraw)
		{
			missedDraw = 0;
			drawCard(GameManager.gameDaddy.getCurrentDrawer().availableEvents);			
		}

		else
		{
			missedDraw++;
		}
	}

	public void drawCard(List<EventCard> events, string eventID = null)
	{
		if(eventID != null)
		{
			EventCard eventToSpawn = events.Find(x => (x.getID() == eventID));
			if(eventToSpawn == null)
				return;

			
			spawnEvent(eventToSpawn);
			storyEvents.Remove(eventToSpawn);
			spentStoryEvents.Add(eventToSpawn);

		}

		else
		{
			if(events.Count == 0)
				return;
			Debug.Log("events.count: " + events.Count);
			int i = Random.Range(0, events.Count -1);
			EventCard eventToSpawn = events[i];
			spawnEvent(eventToSpawn);
			GameManager.gameDaddy.getCurrentDrawer().availableEvents.Remove(eventToSpawn);
			GameManager.gameDaddy.getCurrentDrawer().spentEvents.Add(eventToSpawn);
		}
	}

	public void spawnEvent(EventCard newEvent)
	{
		if(newEvent == null)
			return;

		EventCard eventClone = Instantiate(newEvent) as EventCard;		
		eventClone.transform.parent = GameManager.gameDaddy.canvas.transform;
		eventClone.initialize();

	}	
}
