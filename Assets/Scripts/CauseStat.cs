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
// Could be used to display happiness levels instead of just one number for the average
// We could also display average, min an max levels. using some sort of color coding or graph charts
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
    public int numberOfInitialActivists;

    private List<Activist> activists;

    private List<HappinessLevel> happinessLevels;
    
    public void Initialize()
    {
        happinessLevels = EnumUtil.GetValues<HappinessLevel>();
        activists = new List<Activist>();
        for (int i = 0; i < numberOfInitialActivists; i++)
            activists.Add(new Activist());
    }   

    // Adjust the happiness level of "percentage" percent activists by "amount"
    public void AdjustHappiness(int percentageOfActivists, int amount)
    {
        int count = percentageOfActivists * activists.Count / 100;
        // if all of them are affected we don't need to randomly select them anymore
        if(count == activists.Count)
        {
            foreach (Activist ac in activists)
                ac.AdjustHappiness(amount);
        }
        else
        {
            // wieghted random selection
            int weightedSum = 0;
            foreach (Activist ac in activists)
            {
                // if we are decreasing happiness, we want people with higher happiness to have a bigger chance of being picked
                // otherwise, if we're increasing happiness, we want peole with lower happiness to have a bigger chance of being picked 
                weightedSum += amount > 0 ? 100 - ac.HappinessLevel : ac.HappinessLevel;
            }
            for(int i = 0; i < count; i++)
            {
                Activist selectedActivist;
                // we loop until we get an activist that hasn't been already updated
                do{
                    selectedActivist = GetWeightedRandomActivist(weightedSum, amount > 0);
                } while (selectedActivist.toBeModified);

                selectedActivist.MarkToBeModified(amount);
            }
            // reset modified flag, and update happiness values
            foreach (Activist ac in activists)
                if(ac.toBeModified)
                    ac.ModifyHappiness();
        }      
        // Update the overall stats
        GameController.Instance.UpdateAllStats();
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
        Application.Quit();
        return activists[0];
    }

    public int GetAverageHappiness()
    {
        int sum = 0;
        foreach (Activist ac in activists)
            sum += ac.HappinessLevel;
        return sum / activists.Count;
    }

    public int GetMinHappiness()
    {
        int min = 999;
        foreach (Activist ac in activists)
        {
            if (ac.HappinessLevel < min)
                min = ac.HappinessLevel;
        }
        return min;
    }

    public int GetMaxHappiness()
    {
        int max = -1;
        foreach (Activist ac in activists)
        {
            if (ac.HappinessLevel > max)
                max = ac.HappinessLevel;
        }
        return max;
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
