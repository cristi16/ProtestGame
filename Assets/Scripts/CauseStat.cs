using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CauseStatType
{
    AnimalRights,
    EnvironmentalAwareness,
    Homosexuality,
    Abortion,
    FreeEducation,
    Immigration
}
// Could be used to display average happiness levels instead of just one number
public enum HappinessLevel
{
    VerySad,
    Sad,
    Neutral,
    Happy,
    VeryHappy
}

[System.Serializable]
public class CauseStat
{
    public CauseStatType type;
    public GrowthStatType growthStatRelated;
    public int numberOfActivists;

    private List<Activist> activists;

    private List<HappinessLevel> happinessLevels;
    
    public CauseStat()
    {
        happinessLevels = EnumUtil.GetValues<HappinessLevel>();
        activists = new List<Activist>(numberOfActivists);
    }

    // Adjust the happiness level of "percentage" percent activists by "amount"
    public void AdjustHappiness(int percentageOfActivists, int amount)
    {
        int count = percentageOfActivists * numberOfActivists / 100;

        int weightedSum = 0;
        foreach (Activist ac in activists)
        {
            // if we are decreasing happiness, we want people with higher happiness to have a bigger chance of being picked
            // otherwise, if we're increasing happiness, we want peole with lower happiness to have a bigger chance of being picked 
            weightedSum += amount > 0 ? 100 - ac.HappinessLevel : ac.HappinessLevel;
        }
        for(int i = 0; i < count; i++)
        {
            Activist selectedActivist = GetWeightedRandomActivist(weightedSum, amount > 0);
            selectedActivist.ModifyHappiness(amount);
        }
    }
    // This function uses a weighted random to select the activists whose happiness level should be adjusted
    private Activist GetWeightedRandomActivist(int weightedSum, bool inverted)
    {
        int random = Random.Range(0, weightedSum - 1);
        foreach(Activist ac in activists)
        {
            int happinessLevel = inverted ? 100 - ac.HappinessLevel : ac.HappinessLevel;
            if (random < happinessLevel)
                return ac;
            random -= happinessLevel;
        }
        Debug.LogError("Weighted random selection of activist in not working properly! I should never get to this point!");
        return activists[0];
    }

    public void RemoveUnHappyPeople(int amount)
    {
        
    }

    public void IncreaseInterest(int happyIncrease = 0, int sadIncrease = 0)
    {
        // if no specific increase we add half of current amount of people
        // with same proportion of happiness
        
    }
}
