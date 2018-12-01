using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ChoiceButton : Button {

    //[Header("change These Values")]
    [HideInInspector]
    public bool changeSuspicion, changeHappiness, changePopulation, changeFanatacism, changeHunger;
    
    [HideInInspector]
    public float suspicionValue, happinessValue, populationValue, fanatacismValue, hungerValue, timeValue;
	

    public void pressButton()
    {
        if(!changeSuspicion && !changeHappiness && !changePopulation && !changeFanatacism && !changeHunger)
            return;

        if(changeSuspicion)        
            GameManager.gameDaddy.setSuspicion(suspicionValue);        

        if(changeHappiness)
            GameManager.gameDaddy.setHappiness(happinessValue);
        
        if(changePopulation)
            GameManager.gameDaddy.setPopulation(populationValue);
        
        if(changeFanatacism)
            GameManager.gameDaddy.setFanaticism(fanatacismValue);

        if(changeHunger)
            GameManager.gameDaddy.setHunger(hungerValue);

        this.enabled = false;
        Invoke("reEnableButton", timeValue);
    }

    public void reEnableButton()
    {
        this.enabled = true;
    }
}
