using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatAffector))]
public class GameManager : MonoBehaviour {

	public static GameManager gameDaddy = null;
	private StatAffector statAffector;

	//STATS
	private float Suspicion;
	private float Happiness;
	private float Population;
	private float Fanatacism;
	private float Hunger;

	private float SuspicionTarget;
	private float HappinessTarget;
	private float PopulationTarget;
	private float FanaticismTarget;
	private float HungerTarget;

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

		gameDaddy.statAffector = GetComponent<StatAffector>();
	}
	
	public float getSuspicion(){return gameDaddy.Suspicion;}
	public float getHappiness(){return gameDaddy.Happiness;}
	public float getPopulation(){return gameDaddy.Population;}
	public float getFanatacism(){return gameDaddy.Fanatacism;}
	public float getHunger(){return gameDaddy.Hunger;}

	public void setSuspicion(float newSuspicion){Suspicion = newSuspicion;}
	public void setHappiness(float newHappiness){Happiness = newHappiness;}
	public void setPopulation(float newPopulation){Population = newPopulation;}
	public void setFanaticism(float newFanaticism){Fanatacism = newFanaticism;}
	public void setHunger(float newHunger){Hunger = newHunger;}

	public void setSupsicionTarget(float target){SuspicionTarget = target;}
	public void setHappinessTarget(float target){HappinessTarget = target;}
	public void setPopulationTarget(float target){PopulationTarget = target;}
	public void setFanaticismTarget(float target){FanaticismTarget = target;}
	public void setHungerTarget(float target){HungerTarget = target;}

	public float getSuspicionTarget(){return SuspicionTarget;}
	public float getHappinessTarget(){return HappinessTarget;}
	public float getPopulationTarget(){return PopulationTarget;}
	public float getFanatacismTarget(){return FanaticismTarget;}
	public float getHungerTarget(){return HungerTarget;}
	
}
