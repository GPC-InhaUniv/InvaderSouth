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
        if (Instance != this)
            Instance = this;

        Info = GameObject.Find("AccountInfo").GetComponent<AccountInfo>();
        DontDestroyOnLoad(gameObject);

    }
    public void Start()
    {
        Instance.SetGameManagerData();
    }

    public void BuyItem(int price)
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

        GameManager.Instance.SetPlayerMoney(userData.Value);

    }

    public void SetGameManagerData()
    {
        UserDataRecord userData = new UserDataRecord();
        GameManager.Instance.SetPlayerName(Info.Info.AccountInfo.Username);
        Info.Info.UserData.TryGetValue("PlayerMoney", out userData);
        Debug.Log("playermoney" + userData.Value);
        GameManager.Instance.SetPlayerMoney(userData.Value);

        Info.Info.UserData.TryGetValue("PlayerDiamondCount", out userData);
        GameManager.Instance.SetPlayerDiamond(userData.Value);

        Info.Info.UserData.TryGetValue("CompleteStageNumber", out userData);
        GameManager.Instance.SetPlayerLastCompletedStageNumber(userData.Value);

    }


    void UpdateDataInfo(UpdateUserDataResult result)
    {
        Debug.Log("UpdateDataInfo");
    }

    // Update is called once per frame

}
