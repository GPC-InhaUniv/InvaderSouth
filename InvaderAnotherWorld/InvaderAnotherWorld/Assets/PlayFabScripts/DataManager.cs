using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using System;

public class DataManager : MonoBehaviour
{

    private AccountInfo info;

    public static DataManager Instance;

    private void Awake()
    {
        info = GameObject.Find("AccountInfo").GetComponent<AccountInfo>();
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
        info.Info.UserData.TryGetValue("PlayerMoney", out userData);
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

        int.TryParse(userData.Value, out GameManager.Instance.PlayerMoneyCount);

    }

    public void UseDiaMond(int price)
    {
        UserDataRecord userData = new UserDataRecord();
        info.Info.UserData.TryGetValue("PlayerDiamondCount", out userData);
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

        int.TryParse(userData.Value, out GameManager.Instance.PlayerDiamondCount);
    }



    public void BuyMoney(int price)
    {
        UserDataRecord userData = new UserDataRecord();
        info.Info.UserData.TryGetValue("PlayerMoney", out userData);
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

        int.TryParse(userData.Value, out GameManager.Instance.PlayerMoneyCount);
    }

    public void BuyDiaMond(int price)
    {
        UserDataRecord userData = new UserDataRecord();
        info.Info.UserData.TryGetValue("PlayerDiamondCount", out userData);
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

        int.TryParse(userData.Value, out GameManager.Instance.PlayerDiamondCount);
    }

    public void SetGameManagerData()
    {
        UserDataRecord userData = new UserDataRecord();
        GameManager.Instance.PlayerName=info.Info.AccountInfo.Username;
        info.Info.UserData.TryGetValue("PlayerMoney", out userData);
        Debug.Log("playermoney" + userData.Value);
        int.TryParse(userData.Value, out GameManager.Instance.PlayerMoneyCount);

        info.Info.UserData.TryGetValue("PlayerDiamondCount", out userData);
        int.TryParse(userData.Value, out GameManager.Instance.PlayerDiamondCount);

        info.Info.UserData.TryGetValue("CompleteStageNumber", out userData);
        int.TryParse(userData.Value, out GameManager.Instance.LastCompletedStageNumber);

    }

    void UpdateDataInfo(UpdateUserDataResult result)
    {
        Debug.Log("UpdateDataInfo");
    }

}
