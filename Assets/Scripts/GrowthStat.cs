using UnityEngine;
using System.Collections;

public enum GrowthStatType
{
    Population,
    Tech,
    Freedom
}
[System.Serializable]
public class GrowthStat
{
    public GrowthStatType type;
    public float value;
    public float rate;

    //Methods for changing rate/value of growthstat
}
