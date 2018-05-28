using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;

public class DataManager : MonoBehaviour
{

    public AccountInfo Info;

    public static DataManager Instance;

    [SerializeField]
    private List<GameObject> menus;


    private void Awake()
    {
        if (Instance != this)
            Instance = this;

        Info = GameObject.Find("AccountInfo").GetComponent<AccountInfo>();
    }


    // Use this for initialization
    void Start()
    {

    }

    public void ChangeMenu(int i)
    {
        GameFunctions.ChangeMenu(menus.ToArray(), i);
    }


    public void UseMoney()
    {
        UserDataRecord userData = new UserDataRecord();
        Info.Info.UserData.TryGetValue("PlayerMoney", out userData);
        userData.Value = "90";
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("PlayerMoney", userData.Value);
        data.Add("PlayerStage", "0");

        UpdateUserDataRequest request = new UpdateUserDataRequest()
        {
            Data = data,

        };
        PlayFabClientAPI.UpdateUserData(request, UpdateDataInfo, GameFunctions.OnAPIError);
    }
    void UpdateDataInfo(UpdateUserDataResult result)
    {
        Debug.Log("UpdateDataInfo");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Info != null)
        //    name.text = Info.Info.AccountInfo.Username;

        //UserDataRecord recod = new UserDataRecord();
        //if (Info.Info.UserData != null)
        //{
        //    if (Info.Info.UserData.TryGetValue("PlayerMoney", out recod))
        //    {
                
        //        money.text = recod.Value;
              
        //    }
        //}



    }
}
