using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class AccountInfo : MonoBehaviour
{
    private static AccountInfo instance;
    public int Money = 0;
    public int Stage = 0;


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
        if (instance != this)
            instance = this;

        DontDestroyOnLoad(gameObject);
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

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegister, GameFunctions.OnAPIError);

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

        PlayFabClientAPI.LoginWithPlayFab(request, OnLogin, GameFunctions.OnAPIError);
        
    }

    static void OnLogin(LoginResult result)
    {
        Debug.Log("Login with: " + result.PlayFabId);
        GetAccountInfo(result.PlayFabId);
      
        SceneManager.LoadScene(1);

    }


    public static void GetAccountInfo(string playfabId)
    {
        GetPlayerCombinedInfoRequestParams paramInfo = new GetPlayerCombinedInfoRequestParams()
        {
            GetTitleData=true,
            GetUserInventory=true,
            GetUserAccountInfo=true,
            GetUserVirtualCurrency=true,
            GetPlayerProfile=true,
            GetPlayerStatistics=true,
            GetUserData=true,
            GetUserReadOnlyData=true,
            
        };

        GetPlayerCombinedInfoRequest request = new GetPlayerCombinedInfoRequest()
        {
            PlayFabId=playfabId,
            InfoRequestParameters=paramInfo
        };

        PlayFabClientAPI.GetPlayerCombinedInfo(request,OnGotAccountInfo , GameFunctions.OnAPIError);
    }

    static void OnGotAccountInfo(GetPlayerCombinedInfoResult result)
    {
        Debug.Log("Update Account Infomation!");
        Instance.info = result.InfoResultPayload;
    }


    void SetUpAccount()
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("PlayerMoney", "100");
        data.Add("PlayerStage", "0");

        UpdateUserDataRequest request = new UpdateUserDataRequest()
        {
            Data=data,
            
        };
        PlayFabClientAPI.UpdateUserData(request,UpdateDataInfo,GameFunctions.OnAPIError);

    }

  
    void UpdateDataInfo(UpdateUserDataResult result)
    {
        Debug.Log("UpdateDataInfo");

        //List<StatisticUpdate> stats = new List<StatisticUpdate>();
        //StatisticUpdate trophies = new StatisticUpdate();
        
    }





}
