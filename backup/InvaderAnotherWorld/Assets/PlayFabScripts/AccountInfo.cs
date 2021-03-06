﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using System;

public class AccountInfo : MonoBehaviour
{
    private static AccountInfo instance;


    [SerializeField]
    private GetPlayerCombinedInfoResultPayload info;

    public GetPlayerCombinedInfoResultPayload Info
    {
        get { return info; }
        set { info = value; }
    }


    public static AccountInfo Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            if (instance != this)
                instance = this;


            DontDestroyOnLoad(gameObject);
        }
    }

    public static void Register(string username, string email, string password)
    {
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest()
        {
            TitleId = PlayFabSettings.TitleId,
            Email = email,
            Username = username,
            Password = password,

        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegister, GameErrorManager.OnAPIError);


    }

    static void OnRegister(RegisterPlayFabUserResult result)
    {
        Debug.Log("Registered with: " + result.PlayFabId);
        Instance.SetUpAccount();
        Debug.Log("계정 생성 완료!");

    }

    public static void Login(string username, string password)
    {
        LoginWithPlayFabRequest request = new LoginWithPlayFabRequest
        {
            TitleId = PlayFabSettings.TitleId,
            Username = username,
            Password = password,

        };

        PlayFabClientAPI.LoginWithPlayFab(request, OnLogin, GameErrorManager.OnAPIError);
    }

    static void OnLogin(LoginResult result)
    {
        Debug.Log("Login with: " + result.PlayFabId);
        GetAccountInfo(result.PlayFabId);
        LoadingSceneController.LoadScene("Lobby");

    }

    public static void GetAccountInfo(string playfabId)
    {
        GetPlayerCombinedInfoRequestParams paramInfo = new GetPlayerCombinedInfoRequestParams()
        {
            GetTitleData = true,
            GetUserInventory = true,
            GetUserAccountInfo = true,
            GetUserVirtualCurrency = true,
            GetPlayerProfile = true,
            GetPlayerStatistics = true,
            GetUserData = true,
            GetUserReadOnlyData = true,

        };

        GetPlayerCombinedInfoRequest request = new GetPlayerCombinedInfoRequest()
        {
            PlayFabId = playfabId,
            InfoRequestParameters = paramInfo
        };

        PlayFabClientAPI.GetPlayerCombinedInfo(request, OnGotAccountInfo, GameErrorManager.OnAPIError);
    }

    static void OnGotAccountInfo(GetPlayerCombinedInfoResult result)
    {
        Debug.Log("Update Account Infomation!");
        Instance.info = result.InfoResultPayload;
    }


    void SetUpAccount()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();

        data.Add("PlayerMoney", "1000");
        data.Add("PlayerDiamondCount", "0");
        data.Add("CompleteStageNumber", "0");
        data.Add("CleardStageScore", "0");
        data.Add("PlayerPlaneCount", "0");

        UpdateUserDataRequest request = new UpdateUserDataRequest()
        {
            Data = data,

        };
        PlayFabClientAPI.UpdateUserData(request, UpdateDataInfo, GameErrorManager.OnAPIError);

    }


    void UpdateDataInfo(UpdateUserDataResult result)
    {
        Debug.Log("UpdateDataInfo");
        TitleManager.IsSuccesCreateId = true;
    }





}
