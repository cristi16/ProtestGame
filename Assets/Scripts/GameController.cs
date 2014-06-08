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
            if (instance == null)
                instance = new GameController();
            return instance;
        }
    }
    [HideInInspector]
    public DialogueHandler dialogueHandler;
    private ShowStatsPanel statsPanel;
    private UILabel cashLabel;

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
        dialogueHandler = GameObject.FindObjectOfType<DialogueHandler>();
        statsPanel = GameObject.FindObjectOfType<ShowStatsPanel>();
        cashLabel = GameObject.FindGameObjectWithTag("CashLabel").GetComponent<UILabel>();
        cashLabel.text = moneyAmount + " $";

        foreach (CauseStat cause in causeStats)
            cause.Initialize();

        yield return new WaitForSeconds(1f);

        UpdateAllStats();

        while(true)
        {

            yield return new WaitForSeconds(1f);
            timeInGame = Time.time;
            //Application.LoadLevel(Application.loadedLevel);
        }
    }

    public CauseStat GetCause(CauseStatType type)
    {
        return causeStats.Find(item => item.type == type);
    }

    public void UpdateAllStats()
    {
        string text = "";

        foreach(CauseStat cause in causeStats)
        {
            text += cause.type.ToString() + "\t Avg HP: " + cause.GetAverageHappiness() + "\t Min: " + 
                cause.GetMinHappiness() + "\t Max: " + cause.GetMaxHappiness() + "\n";
        }
        statsPanel.statsTextLabel.text = text;

        cashLabel.text = moneyAmount + " $";
    }
}
