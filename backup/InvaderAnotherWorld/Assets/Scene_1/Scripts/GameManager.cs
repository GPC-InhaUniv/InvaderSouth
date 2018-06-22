using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public string PlayerName;
    public int PlayerMoneyCount;
    public int PlayerDiamondCount;
    public int LastCompletedStageNumber;
    public int[] CleardStageScore;
    public bool[] IsPlayerHavePlane;
    public bool[] BuyItemList;
    public int CurrentStage = (1 << 0);

    private const int maxStageCount = 3;
    private const int maxPlaneCount = 2;
    private const int maxItemCount = 3;



    private void Start()
    {
        PlayerName = "";
        PlayerMoneyCount = 0;
        PlayerDiamondCount = 0;
        LastCompletedStageNumber = 0;
        CleardStageScore = new int[maxStageCount];
        for (int i = 0; i < maxStageCount; i++)
            CleardStageScore[i] = 0;

        IsPlayerHavePlane = new bool[maxPlaneCount];
        for (int i = 0; i < maxPlaneCount; i++)
            IsPlayerHavePlane[i] = false;

        BuyItemList = new bool[maxItemCount];
        for (int i = 0; i < maxItemCount; i++)
            BuyItemList[i] = false;

    }

    public void ResetPlayerInfo()
    {
        PlayerName = "";
        PlayerMoneyCount = 0;
        PlayerDiamondCount = 0;
        LastCompletedStageNumber = 0;
        CleardStageScore = new int[maxStageCount];
        for (int i = 0; i < maxStageCount; i++)
            CleardStageScore[i] = 0;

        IsPlayerHavePlane = new bool[maxPlaneCount];
        for (int i = 0; i < maxPlaneCount; i++)
            IsPlayerHavePlane[i] = false;
       
    }

}