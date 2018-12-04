using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ChoiceButton : Button {
    
    private enum ButtonType
    {
        CHOICE_CARD,
        EVENT_CARD,
    }

    private ButtonType buttonType = ButtonType.CHOICE_CARD;

    private ChoiceCard cardParent;

    public string tooltipText = null;

    //[Header("change These Values")]
    [HideInInspector]
    public bool changeSuspicion, changeHappiness, changePopulation, changeFanatacism, changeHunger, changeBlood, changeCows;
    
    [HideInInspector]
    public float suspicionValue, happinessValue, populationValue, fanatacismValue, hungerValue, timeValue, cowValue, bloodValue;
	

    public void Initialize(ChoiceCard card)
    {
        if(card is EventCard)
        {
            setButtonAsEvent();
        }

        cardParent = card;
    }

    public virtual void pressButton()
    {
        Debug.Log("press button");
        /* if(!changeSuspicion && !changeHappiness && !changePopulation && !changeFanatacism && !changeHunger)
            return; */

        if(changeSuspicion)        
        {
            GameManager.gameDaddy.setSuspicion(suspicionValue);
            FeedBackManager.feedDaddy.spawnFeedbackText(transform, "Suspicion", suspicionValue);
        }
            

        if(changeHappiness)
        {
            GameManager.gameDaddy.setHappiness(happinessValue);
            FeedBackManager.feedDaddy.spawnFeedbackText(transform, "Happiness", happinessValue);
        }
            
        
        if(changePopulation)
        {
            GameManager.gameDaddy.setPopulation(populationValue);
            FeedBackManager.feedDaddy.spawnFeedbackText(transform, "Population", populationValue);
        }
            
        
        if(changeFanatacism)
        {
            GameManager.gameDaddy.setFanaticism(fanatacismValue);
            FeedBackManager.feedDaddy.spawnFeedbackText(transform, "Fanatacism", fanatacismValue);
        }
            

        if(changeHunger)
        {
            GameManager.gameDaddy.setHunger(hungerValue);
            FeedBackManager.feedDaddy.spawnFeedbackText(transform, "Hunger", hungerValue);
        }
            

        if(changeCows)
        {
            GameManager.gameDaddy.setCow(cowValue);
            FeedBackManager.feedDaddy.spawnFeedbackText(transform, "Cow", cowValue);
        }
            

        if(changeBlood)
        {
            GameManager.gameDaddy.setBloodCount((int)bloodValue);
            FeedBackManager.feedDaddy.spawnFeedbackText(transform, "Blood", bloodValue);
        }            

        this.interactable = false;
        Invoke("reEnableButton", timeValue);

        Debug.Log("parent: " + transform.parent.root);

        cardParent.buttonPressed(timeValue, this);


    }

    public virtual void reEnableButton()
    {
        this.interactable = true;
    }

    public void setButtonAsEvent(){buttonType = ButtonType.EVENT_CARD;}

    public bool isButtonEvent(){return buttonType == ButtonType.EVENT_CARD;}
}
