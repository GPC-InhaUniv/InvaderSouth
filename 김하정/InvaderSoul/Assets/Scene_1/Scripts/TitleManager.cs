using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleManager : MonoBehaviour {


    [Header("LoginPanel")]
    private InputField IDInputField;
    private InputField PassInputField;

    [Header("CreateAccountPanel")]
    private InputField New_IDInputField;
    private InputField New_PassInputField;
    private InputField Confirm_New_PassInputField;


    [Header("PopUp")]
    private GameObject LoginAlertPanel;
    private GameObject CreateAlertPanel;
    private GameObject CreateAccountPanel;
    private GameObject LoginPanel;
    private Text CreateAccountAlert;
    private Text LoginAlert;
    private GameObject QuitAlertPanel;

     
    


    string playerID="";
    string secreatNum="";
    private void Start()
    {
        Screen.SetResolution(700, 1080, true);

        LoginPanel = GameObject.Find("LoginPanel");
        IDInputField = GameObject.Find("IDInputField").GetComponent<InputField>();
        PassInputField = GameObject.Find("PassInputField").GetComponent<InputField>();
        LoginAlertPanel = GameObject.Find("LoginAlertPanel");
        LoginAlert = GameObject.Find("LoginAlert").GetComponent<Text>();
        LoginAlert.gameObject.SetActive(false);
        LoginAlertPanel.SetActive(false);

        New_IDInputField = GameObject.Find("New_IDInputField").GetComponent<InputField>();
        New_PassInputField = GameObject.Find("New_PassInputField").GetComponent<InputField>();
        Confirm_New_PassInputField = GameObject.Find("Confirm_New_PassInputField").GetComponent<InputField>();
        CreateAccountPanel = GameObject.Find("CreateAccountPanel");

        CreateAlertPanel = GameObject.Find("CreateAlertPanel");
        CreateAlertPanel.SetActive(false);
        CreateAccountAlert = GameObject.Find("CreateAccountAlert").GetComponent<Text>();
        CreateAccountAlert.gameObject.SetActive(false);
        CreateAccountPanel.SetActive(false);

        QuitAlertPanel = GameObject.Find("QuitAlertPanel");
        QuitAlertPanel.gameObject.SetActive(false);


    }
   
    /// <summary>
    /// Login, CreateAccount
    /// </summary>
    public void LoginBtn()
    {
        StartCoroutine(LginCo());
    }

    IEnumerator LginCo()
    {
        if (IDInputField.text != "" && PassInputField.text != "")
        {
            //아이디 및 비밀번호를 임시 변수에 저장
            playerID = IDInputField.text;
            secreatNum = PassInputField.text;

            Debug.Log("ID는?" + IDInputField.text);
            Debug.Log("비밀번호는?" + PassInputField.text);
            
           
            if(PlayerPrefs.GetString(playerID+"secretNum").Equals(secreatNum))
            {
                LoadingSceneController.LoadScene("TitleScene");
                GameController.Instance.PlayerName = playerID;

            }
            else if (!(PlayerPrefs.HasKey(playerID)))
            {
                Debug.Log("해당 아이디는 존재하지 않습니다.");
                LoginAlert.gameObject.SetActive(true);
                LoginAlert.text = "없는 계정입니다.";
            }
            else
            {
                Debug.Log("비밀번호가 틀립니다!");
                LoginAlert.gameObject.SetActive(true);
                LoginAlert.text = "비밀번호가 틀립니다.";
            }
            
          
        }
        yield return null;
    }

    public void OpenCreateAccountBtn()
    {
        CreateAccountPanel.SetActive(true);
    }

    public void CreateAccountBtn()
    {
        StartCoroutine(CreateCo());
    }

    IEnumerator CreateCo()
    {
        playerID = New_IDInputField.text;
        secreatNum = New_PassInputField.text;

        if (PlayerPrefs.HasKey(playerID))
        {
            Debug.Log("해당 아이디 :" + playerID + " 는 이미 존재합니다");
            CreateAccountAlert.gameObject.SetActive(true);
            CreateAccountAlert.text = "이미 존재하는 계정입니다.";
        }
        else if (New_IDInputField.text != "" && New_PassInputField.text != ""&& Confirm_New_PassInputField.text != "")
        {
            
            Debug.Log("새로 만드는 계정의 ID는?" + New_IDInputField.text);
            Debug.Log("새로 만드는 계정의 비밀번호는?" + New_PassInputField.text);
            Debug.Log("새로만드는 계정의 비밀번호 확인" + Confirm_New_PassInputField.text);

            if (New_PassInputField.text != Confirm_New_PassInputField.text)
            {
                CreateAccountAlert.gameObject.SetActive(true);
                CreateAccountAlert.text = "비밀번호가 일치하지 않습니다.";
            }
             
           
            else
            {
                PlayerPrefs.SetString(playerID, playerID);
                GameController.Instance.PlayerName = playerID;
                PlayerPrefs.SetString(playerID + "secretNum", secreatNum);
                PlayerPrefs.Save();
                LoadingSceneController.LoadScene("TitleScene");
            }


        }
       yield return null;
    }

/// <summary>
/// 팝업 창
/// </summary>

    public void ShowLoginAlertPanel()
    {
        if (IDInputField.text == "" || PassInputField.text=="")
        {
            LoginAlertPanel.gameObject.SetActive(true);
        }
    }

    public void HideLoginAlertPanel()
    {
        LoginAlertPanel.gameObject.SetActive(false);
    }

    public void ShowCreateAlertPanel()
    {
        if (New_IDInputField.text == "" || New_PassInputField.text == "" || Confirm_New_PassInputField.text =="")
        {
            CreateAlertPanel.gameObject.SetActive(true);
            
        }
       
    }
    public void HideCreateAlertPanel()
    {
        CreateAlertPanel.gameObject.SetActive(false);
    }

    public void HideCreateAccountPanel()
    {
        CreateAccountPanel.gameObject.SetActive(false);
    }

    public void HideLoginPanel()
    {
        LoginPanel.gameObject.SetActive(false);
    }

    public void ShowLoginPanel()
    {
        LoginPanel.gameObject.SetActive(true);
    }

    public void ClrearCreateAccountPanel()
    {
        New_IDInputField.text = "";
        New_PassInputField.text = "";
        Confirm_New_PassInputField.text = "";
        CreateAccountAlert.gameObject.SetActive(false);
    }

    public void GameQuit()
    {
        QuitAlertPanel.gameObject.SetActive(true);
        
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
    public void NotQuitBtn()
    {
        QuitAlertPanel.gameObject.SetActive(false);
    }
}
