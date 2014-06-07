using UnityEngine;
using System.Collections;

public class Activist
{
    // Can be between 0 and 100
    int happinessLevel;

    public int HappinessLevel
    {
        get { return happinessLevel; }
    }

    public Activist()
    {
        happinessLevel = 50;
    }

    public void ModifyHappiness(int amount)
    {
        happinessLevel = Mathf.Clamp(happinessLevel + amount, 0, 100);
    }
}
