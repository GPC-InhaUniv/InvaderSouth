using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public string PlayerName;
    public string PlayerMoneyCount;
    public string PlayerDiamondCount;
    public string LastCompletedStageNumber;
    public int[] CleardStageScore;
    public bool[] IsPlayerHavePlane;

  

    public int currentStage = 0;
    public bool[] buyItemList;

    private const int maxStageCount = 3;
    private const int maxPlaneCount = 2;
    private const int maxItemCount = 3;



    private void Start()
    {
        PlayerName = "";
        PlayerMoneyCount = "";
        PlayerDiamondCount = "0";
        LastCompletedStageNumber = "0";
        CleardStageScore = new int[maxStageCount];
        for (int i = 0; i < maxStageCount; i++)
            CleardStageScore[i] = 0;

        IsPlayerHavePlane = new bool[maxPlaneCount];
        for (int i = 0; i < maxPlaneCount; i++)
            IsPlayerHavePlane[i] = false;

        buyItemList = new bool[maxItemCount];
        for (int i = 0; i < maxItemCount; i++)
            buyItemList[i] = false;

    }

    public void ResetPlayerInfo()
    {
        PlayerName = "";
        PlayerMoneyCount = "";
        PlayerDiamondCount = "0";
        LastCompletedStageNumber = "0";
        CleardStageScore = new int[maxStageCount];
        for (int i = 0; i < maxStageCount; i++)
            CleardStageScore[i] = 0;

        IsPlayerHavePlane = new bool[maxPlaneCount];
        for (int i = 0; i < maxPlaneCount; i++)
            IsPlayerHavePlane[i] = false;
       
    }

}