using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatAffector : MonoBehaviour {

	//This is a script that will run coroutines to alter the stats that run the game (in gamemanager)

	private Coroutine changeSuspicion;
	private Coroutine changeHappiness;
	private Coroutine changePopulation;
	private Coroutine changeFanatacism;
	private Coroutine changeHunger;

	private float currentSuspicionTime;
	private float currentHappinessTime;
	private float currentPopulationTime;
	private float currentFanatacismTime;
	private float currentHungerTime;

	public AnimationCurve curve;

	public void alterSuspicion(float time, float target)
	{
		if(changeSuspicion != null)
			StopCoroutine(changeSuspicion);

		currentSuspicionTime = 0;
		GameManager.gameDaddy.setSupsicionTarget(target);
		changeSuspicion = StartCoroutine(doChangeSuspicion(time, target));
	}

	public void alterHappiness(float time, float target)
	{
		if(changeHappiness != null)
			StopCoroutine(changeHappiness);

		currentHappinessTime = 0;
		GameManager.gameDaddy.setHappinessTarget(target);
		changeSuspicion = StartCoroutine(doChangeHappiness(time, target));
	}

	public void alterPopulation(float time, float target)
	{
		if(changePopulation != null)
			StopCoroutine(changePopulation);

		currentPopulationTime = 0;
		GameManager.gameDaddy.setPopulationTarget(target);
		changePopulation = StartCoroutine(doChangePopulation(time, target));
	}

	public void alterFanatacism(float time, float target)
	{
		if(changeFanatacism != null)
			StopCoroutine(changeFanatacism);

		currentFanatacismTime = 0;
		GameManager.gameDaddy.setFanaticismTarget(target);
		changeFanatacism = StartCoroutine(doChangeFanatacism(time, target));
	}

	public void alterHunger(float time, float target)
	{
		if(changeHunger != null)
			StopCoroutine(changeHunger);

		currentHungerTime = 0;
		GameManager.gameDaddy.setHungerTarget(target);
		changeHunger = StartCoroutine(doChangeHunger(time, target));
	}

	IEnumerator doChangeSuspicion(float time, float target)
	{
		float rate = 1/time;		
		float currentSuspicion = GameManager.gameDaddy.getSuspicion();

		while(currentSuspicionTime < time)
		{
			currentSuspicionTime += Time.deltaTime * rate;
			currentSuspicion = Mathf.Lerp(currentSuspicion, target, curve.Evaluate(currentSuspicionTime));
			GameManager.gameDaddy.setSuspicion(currentSuspicion);
			yield return 0;
		}
		yield return 0;
	}

	IEnumerator doChangeHappiness(float time, float target)
	{
		float rate = 1/time;		
		float currentHappiness = GameManager.gameDaddy.getHappiness();

		while(currentHappinessTime < time)
		{
			currentHappinessTime += Time.deltaTime * rate;
			currentHappiness = Mathf.Lerp(currentHappiness, target, curve.Evaluate(currentHappinessTime));
			GameManager.gameDaddy.setHappiness(currentHappiness);
			yield return 0;
		}
		yield return 0;
	}

	IEnumerator doChangePopulation(float time, float target)
	{
		float rate = 1/time;		
		float currentPopulation = GameManager.gameDaddy.getPopulation();

		while(currentPopulationTime < time)
		{
			currentPopulationTime += Time.deltaTime * rate;
			currentPopulation = Mathf.Lerp(currentPopulation, target, curve.Evaluate(currentPopulationTime));
			GameManager.gameDaddy.setPopulation(currentPopulation);
			yield return 0;
		}
		yield return 0;
	}

	IEnumerator doChangeFanatacism(float time, float target)
	{
		float rate = 1/time;		
		float currentFanatacism = GameManager.gameDaddy.getFanatacism();

		while(currentFanatacismTime < time)
		{
			currentFanatacismTime += Time.deltaTime * rate;
			currentFanatacism = Mathf.Lerp(currentFanatacism, target, curve.Evaluate(currentFanatacismTime));
			GameManager.gameDaddy.setFanaticism(currentFanatacism);
			yield return 0;
		}
		yield return 0;
	}

	IEnumerator doChangeHunger(float time, float target)
	{
		float rate = 1/time;		
		float currentHunger = GameManager.gameDaddy.getHunger();

		while(currentHungerTime < time)
		{
			currentHungerTime += Time.deltaTime * rate;
			currentHunger = Mathf.Lerp(currentHunger, target, curve.Evaluate(currentHungerTime));
			GameManager.gameDaddy.setHunger(currentHunger);
			yield return 0;
		}
		yield return 0;
	}
}
