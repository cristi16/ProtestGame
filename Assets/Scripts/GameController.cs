using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance
    {
        get
        {
            if (instance = null)
                instance = new GameController();
            return instance;
        }
    }

    public List<GrowthStat> growthStats;
    public List<CauseStat> causeStats;

    public int moneyAmount = 0;
    public float timeInGame;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Start()
    {
        while(true)
        {

            yield return new WaitForSeconds(5f);
            timeInGame = Time.time;
            //Application.LoadLevel(Application.loadedLevel);
        }
    }

    public CauseStat GetCause(CauseStatType type)
    {
        return causeStats.Find(item => item.type == type);
    }

    void Update()
    {

    }
}
