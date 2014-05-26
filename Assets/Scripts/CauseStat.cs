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

    public List<HappinessLevel> people;

    private List<HappinessLevel> happinessLevels;
    
    public CauseStat()
    {
        happinessLevels = EnumUtil.GetValues<HappinessLevel>();
    }

    public void IncreaseHappiness(List<HappinessLevel> requestingPeople)
    {
        happinessLevel.sad -= amount;
        happinessLevel.happy += amount;
        ClampHappinessLevel();
    }

    public void DecreaseHappiness(int amount)
    {
        happinessLevel.happy -= amount;
        happinessLevel.sad += amount;
        ClampHappinessLevel();
    }

    public void RemoveUnHappyPeople(int amount)
    {
        happinessLevel.sad -= amount;
        ClampHappinessLevel();
    }

    public void IncreaseInterest(int happyIncrease = 0, int sadIncrease = 0)
    {
        // if no specific increase we add half of current amount of people
        // with same proportion of happiness
        if(happyIncrease == 0 && sadIncrease == 0)
        {
            happinessLevel.happy += happinessLevel.happy / 2;
            happinessLevel.sad += happinessLevel.sad / 2;
        }
        
    }

    private void ClampHappinessLevel()
    {
        happinessLevel.happy = Mathf.Clamp(happinessLevel.happy, 0, 100);
        happinessLevel.sad = Mathf.Clamp(happinessLevel.sad, 0, 100);
    }
}
