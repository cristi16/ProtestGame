using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IndividualRequest
{
    public CauseStatType causeType;
    public bool isPro;

    public List<HappinessLevel> people;
    public int moneyRequired;
    // variables for distinguishing between age and possibly gender 
    //in order to fetch specific dialog for each individual
    //have a happpines level so that we know which ones to change( this is fetched in advanced based on 
    // the current happiness level) - allows for variety in dialog + text
    public int age;
    public bool isMale;

    private CauseStat stat;

    public IndividualRequest(CauseStatType causeType, , bool isPro, 
        List<HappinessLevel> people, int moneyRequired)
    {
        this.causeType = causeType;
        this.people = people;
        this.isPro = isPro;
        this.moneyRequired = moneyRequired;
        this.stat = GameController.Instance.GetCause(causeType);
    }

    public void FullfillRequest()
    {
        GameController.Instance.moneyAmount -= moneyRequired;

        if(isPro)
            stat.IncreaseHappiness(people);
        else
             stat.DecreaseHappiness(people.Count);
    }

    public void DenyRequest()
    {
         if(isPro)
            stat.DecreaseHappiness(people.Count);
        else
            stat.IncreaseHappiness(people);
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
            stat.IncreaseInterest();
        }    
        else
        {
            // Execution was well hid from media and people
            // Nothing happens
        }
    }
}
