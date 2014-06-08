using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class IndividualRequest
{
    public CauseStatType causeType;
    public bool isPro;

    public int moneyRequired;
    // variables for distinguishing between age and possibly gender 
    //in order to fetch specific dialog for each individual
    //average happiness of cause - allows for variety in dialog + text
    public int age;
    public bool isMale;

    private CauseStat supportedCause;
    public int numberOfActivists;

    public IndividualRequest(CauseStatType causeType, bool isPro, int moneyRequired)
    {
        this.causeType = causeType;
        this.isPro = isPro;
        this.moneyRequired = moneyRequired;
        this.supportedCause = GameController.Instance.GetCause(causeType);
        numberOfActivists = Random.Range(10, 30);
    }

    public void FullfillRequest()
    {
        GameController.Instance.moneyAmount -= moneyRequired;

        if(isPro)
            supportedCause.AdjustHappiness(numberOfActivists, 10);
        else
            supportedCause.AdjustHappiness(100, -5);
    }

    public void DenyRequest()
    {
        if(isPro)
            supportedCause.AdjustHappiness(numberOfActivists, -10);
        else
            supportedCause.AdjustHappiness(100, 5);
    }
    
    public void ExecuteIndividual()
    {
        // Remove sad people
        //stat.RemoveUnHappyPeople(amountOfPeople);

        // Random chance 50-50
        int rand = Random.Range(0, 1);
        // The word gets out and people find out about the execution
        // So more people get interested in the cause
        if(rand == 0)
        {
            supportedCause.IncreaseInterest();
        }    
        else
        {
            // Execution was well hid from media and people
            // Nothing happens
        }
    }
}
