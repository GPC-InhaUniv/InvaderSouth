using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using System;

public class DataManager : MonoBehaviour
{

    public AccountInfo Info;

    public static DataManager Instance;

    private void Awake()
    {
        Info = GameObject.Find("AccountInfo").GetComponent<AccountInfo>();
        if (Instance == null)
        {
            if (Instance != this)
                Instance = this;

          
            DontDestroyOnLoad(gameObject);
        }
       

    }
    public void Start()
    {
        Instance.SetGameManagerData();
    }

    public void UseMoney(int price)
    {
        UserDataRecord userData = new UserDataRecord();
        Info.Info.UserData.TryGetValue("PlayerMoney", out userData);
        int money = Convert.ToInt32(userData.Value);
        money -= price;
        userData.Value = money.ToString();
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("PlayerMoney", userData.Value);


        UpdateUserDataRequest request = new UpdateUserDataRequest()
        {
            Data = data,

        };
        PlayFabClientAPI.UpdateUserData(request, UpdateDataInfo, GameErrorManager.OnAPIError);

        GameManager.Instance.PlayerMoneyCount=userData.Value;

    }

    public void UseDiaMond(int price)
    {
        UserDataRecord userData = new UserDataRecord();
        Info.Info.UserData.TryGetValue("PlayerDiamondCount", out userData);
        int diamond = Convert.ToInt32(userData.Value);
        diamond -= price;
        userData.Value = diamond.ToString();
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("PlayerDiamondCount", userData.Value);


        UpdateUserDataRequest request = new UpdateUserDataRequest()
        {
            Data = data,

        };
        PlayFabClientAPI.UpdateUserData(request, UpdateDataInfo, GameErrorManager.OnAPIError);

        GameManager.Instance.PlayerDiamondCount=userData.Value;
    }



    public void BuyMoney(int price)
    {
        UserDataRecord userData = new UserDataRecord();
        Info.Info.UserData.TryGetValue("PlayerMoney", out userData);
        int money = Convert.ToInt32(userData.Value);
        money += price;
        userData.Value = money.ToString();
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("PlayerMoney", userData.Value);


        UpdateUserDataRequest request = new UpdateUserDataRequest()
        {
            Data = data,

        };
        PlayFabClientAPI.UpdateUserData(request, UpdateDataInfo, GameErrorManager.OnAPIError);

        GameManager.Instance.PlayerMoneyCount=userData.Value;
    }

    public void BuyDiaMond(int price)
    {
        UserDataRecord userData = new UserDataRecord();
        Info.Info.UserData.TryGetValue("PlayerDiamondCount", out userData);
        int diamond = Convert.ToInt32(userData.Value);
        diamond += price;
        userData.Value = diamond.ToString();
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("PlayerDiamondCount", userData.Value);


        UpdateUserDataRequest request = new UpdateUserDataRequest()
        {
            Data = data,

        };
        PlayFabClientAPI.UpdateUserData(request, UpdateDataInfo, GameErrorManager.OnAPIError);

        GameManager.Instance.PlayerDiamondCount=userData.Value;
    }

    public void SetGameManagerData()
    {
        UserDataRecord userData = new UserDataRecord();
        GameManager.Instance.PlayerName=Info.Info.AccountInfo.Username;
        Info.Info.UserData.TryGetValue("PlayerMoney", out userData);
        Debug.Log("playermoney" + userData.Value);
        GameManager.Instance.PlayerMoneyCount=userData.Value;

        Info.Info.UserData.TryGetValue("PlayerDiamondCount", out userData);
        GameManager.Instance.PlayerDiamondCount=userData.Value;

        Info.Info.UserData.TryGetValue("CompleteStageNumber", out userData);
        GameManager.Instance.LastCompletedStageNumber=userData.Value;

    }

  


    void UpdateDataInfo(UpdateUserDataResult result)
    {
        Debug.Log("UpdateDataInfo");
    }

    // Update is called once per frame

}
