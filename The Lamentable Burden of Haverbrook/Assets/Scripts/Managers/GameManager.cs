using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager gameDaddy = null;
	public Canvas canvas;

	private Drawer currentDrawer;
	//STATS
	private float Suspicion = 50;
	private float Happiness = 50;
	private float Population = 50;
	private float Fanatacism = 50;
	private float Hunger = 50;

	// Use this for initialization
	void Awake () 
	{
		//check to see if there's a game daddy, if not, this is our gamedaddy
		if(gameDaddy == null)
			gameDaddy = this;	

		//otherwise...KILL IT DEAD!
		else if (gameDaddy == this)
			Destroy(gameObject);

		//Keep our GameDaddy 4 E-V-E-R
		DontDestroyOnLoad(gameObject);
		
	}

	public void freezeTime()
	{
		Time.timeScale = 0;
		Time.fixedDeltaTime = Time.timeScale * .02f;
	}

	public void restoreTime()
	{
		Time.timeScale = 1;
		Time.fixedDeltaTime = Time.timeScale * .02f;
	}

	public float getSuspicion(){return gameDaddy.Suspicion;}
	public float getHappiness(){return gameDaddy.Happiness;}
	public float getPopulation(){return gameDaddy.Population;}
	public float getFanatacism(){return gameDaddy.Fanatacism;}
	public float getHunger(){return gameDaddy.Hunger;}

	public void setSuspicion(float newSuspicion){Suspicion = Mathf.Clamp(Suspicion + newSuspicion, 0, 100);}
	public void setHappiness(float newHappiness){Happiness = Mathf.Clamp(Happiness + newHappiness, 0, 100);}
	public void setPopulation(float newPopulation){Population = Mathf.Clamp(Population + newPopulation, 0, 100);}
	public void setFanaticism(float newFanaticism){Fanatacism = Mathf.Clamp(Fanatacism + newFanaticism, 0, 100);}
	public void setHunger(float newHunger){Hunger = Mathf.Clamp(Hunger + newHunger, 0, 100);}

	public void setCurrentDrawer(Drawer newDrawer)
	{
		currentDrawer = newDrawer;
	}

	public Drawer getCurrentDrawer(){return currentDrawer;}

	public void closeCurrentDrawer(){gameDaddy.currentDrawer.closeDrawer();}

}
