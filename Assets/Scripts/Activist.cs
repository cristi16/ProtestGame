using UnityEngine;
using System.Collections;

public class Activist
{
    public bool toBeModified = false;
    // Can be between 0 and 100
    int happinessLevel;
    private int newLevel;

    public int HappinessLevel
    {
        get { return happinessLevel; }
    }

    public Activist()
    {
        happinessLevel = 50;
    }

    public void MarkToBeModified(int amount)
    {
        newLevel = Mathf.Clamp(happinessLevel + amount, 0, 100);
        toBeModified = true;
    }

    public void ModifyHappiness()
    {
        happinessLevel = newLevel;
        toBeModified = false;
    }

    public void AdjustHappiness(int amount)
    {
        happinessLevel = Mathf.Clamp(happinessLevel + amount, 0, 100);
    }
}
