using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private string playerName;
    private string playerMoneyCount;
    private string playerDiamondCount;
    private string LastCompletedStageNumber;

    public int[] CleardStageScore;
    public bool[] IsPlayerHavePlane;

    private const int maxStageCount = 3;
    private const int maxPlaneCount = 2;



    private void Start()
    {
        playerName = "";
        playerMoneyCount = "";
        playerDiamondCount = "0";
        LastCompletedStageNumber = "0";
        CleardStageScore = new int[maxStageCount];
        for (int i = 0; i < maxStageCount; i++)
            CleardStageScore[i] = 0;

        IsPlayerHavePlane = new bool[maxPlaneCount];
        for (int i = 0; i < maxPlaneCount; i++)
            IsPlayerHavePlane[i] = false;

    }


    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SetPlayerMoney(string money)
    {
        playerMoneyCount = money;
    }

    public string GetPlayerMoney()
    {
        return playerMoneyCount;
    }

    public void SetPlayerDiamond(string diamond)
    {
        playerDiamondCount = diamond;
    }

    public string GetPlayerDiamond()
    {
        return playerDiamondCount;
    }
    public void SetPlayerLastCompletedStageNumber(string stage)
    {
        LastCompletedStageNumber = stage;
    }

    public string GetPlayerLastCompletedStageNumber()
    {
        return LastCompletedStageNumber;
    }





}