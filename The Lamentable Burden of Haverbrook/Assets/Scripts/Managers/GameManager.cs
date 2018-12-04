using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager gameDaddy = null;
	public Canvas canvas;

	private Drawer currentDrawer;

	private Descriptors descriptors;
	//STATS
	private float Suspicion = 0;
	private float Happiness = 65;
	private float Population = 0;
	private float Fanatacism = 0;
	private float Hunger = 5;
	private float Cow = 2;

	private float currentHungerTime = 0;
	private float hungerIncreaseTime = 10;
	private float hungerIncreaseValue = 1;

	private float currentPopulationTime = 0;
	private float populationIncreaseTime = 10;

	private int bloodCount = 0;
	private int cowDeadCount = 0;

	public Building barBuilding;
	public Building churchBuilding;
	public Building policeBuilding;
	public Building cityBuilding;

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

		descriptors = GetComponent<Descriptors>();
		
	}

	public void Update()
	{
		IncreaseHunger();
		if(EventManager.eventMomma.isGameStarted())
		{
			IncreasePopulation();
		}
	}

	void IncreaseHunger()
	{
		currentHungerTime += Time.deltaTime;
		if(currentHungerTime > hungerIncreaseTime)
		{
			currentHungerTime = 0;
			setHunger(hungerIncreaseValue);
		}
	}

	void IncreasePopulation()
	{
		currentPopulationTime += Time.deltaTime;
		if(currentPopulationTime >= populationIncreaseTime)
		{
			currentPopulationTime = 0;
			setPopulation(Mathf.Ceil((getHappiness() - 50)/ 20));
		}
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
	public float getCow(){return gameDaddy.Cow;}
	public float getBlood(){return gameDaddy.bloodCount;}
	public int getCowDead(){return gameDaddy.cowDeadCount;}

	public Descriptors getDescriptors(){return gameDaddy.descriptors;}

	public void setSuspicion(float newSuspicion){Suspicion = Mathf.Clamp(Suspicion + newSuspicion, 0, 100);}
	public void setHappiness(float newHappiness){Happiness = Mathf.Clamp(Happiness + newHappiness, 0, 100);}
	public void setPopulation(float newPopulation){Population = Mathf.Clamp(Population + newPopulation, 0, 100);}
	public void setFanaticism(float newFanaticism){Fanatacism = Mathf.Clamp(Fanatacism + newFanaticism, 0, 100);}
	public void setHunger(float newHunger){Hunger = Mathf.Clamp(Hunger + newHunger, 0, 100);}
	public void setHungerIncrease(float newHunger){hungerIncreaseValue = newHunger;}
	public void setHungerTime(float newTime){hungerIncreaseTime = newTime;}
	public void setCow(float newCow){Cow = Mathf.Clamp(Cow + newCow, 0, 20);}
	public void setBloodCount(int newBlood){bloodCount = Mathf.Clamp(bloodCount + newBlood, 0, 3);}
	public void setCowDead(int newDeadCow){cowDeadCount = Mathf.Clamp(cowDeadCount + newDeadCow, 0, 100);}

	public void setCurrentDrawer(Drawer newDrawer)
	{
		currentDrawer = newDrawer;
	}

	public Drawer getCurrentDrawer(){return currentDrawer;}

	public void closeCurrentDrawer(){gameDaddy.currentDrawer.closeDrawer();}

}
