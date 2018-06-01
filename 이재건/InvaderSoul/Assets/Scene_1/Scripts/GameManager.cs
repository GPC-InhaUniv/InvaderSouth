using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private string playerName;
    private string playerMoneyCount;
    private int playerDiamondCount;

    public int LastCompletedStageNumber;
    public int[] CleardStageScore;
    public bool[] IsPlayerHavePlane;

    private int maxStageCount = 3;
    private int PlaneCount = 2;



    private void Start()
    {
        playerName = "";
        playerMoneyCount = "";
        playerDiamondCount = 0;
        LastCompletedStageNumber = 0;
        CleardStageScore = new int[maxStageCount];
        for (int i = 0; i < maxStageCount; i++)
            CleardStageScore[i] = 0;

        IsPlayerHavePlane = new bool[PlaneCount];
        for (int i = 0; i < PlaneCount; i++)
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

    public void SetPlayerDiamond(int diamond)
    {
        playerDiamondCount = diamond;
    }

    public int GetPlayerDiamond()
    {
        return playerDiamondCount;
    }


}