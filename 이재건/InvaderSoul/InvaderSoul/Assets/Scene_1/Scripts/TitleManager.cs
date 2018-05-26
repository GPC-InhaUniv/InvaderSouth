using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleManager : MonoBehaviour
{
    [Header("LoginPanel")]
    public InputField IDInputField;
    public InputField PassInputField;

    [Header("CreateAccountPanel")]
    public InputField New_IDInputField;
    public InputField New_PassInputField;
    public InputField Confirm_New_PassInputField;

    [Header("PopUp")]
    public GameObject LoginAlertPanel;
    public GameObject CreateAlertPanel;
    public GameObject CreateAccountPanel;
    public GameObject LoginPanel;
    public Text CreateAccountAlert;

    string playerID="";
    string secreatNum="";
    private void Start()
    {  
        Screen.SetResolution(700, 1080, true);
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
                GameController.Instance.PlayerName = playerID;
                LoadingSceneController.LoadScene("LobbyUI");
            }
            else if (!(PlayerPrefs.HasKey(playerID)))
            {
                Debug.Log("해당 아이디는 존재하지 않습니다.");
            }
            else
            {
                Debug.Log("비밀번호가 틀립니다!");
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
        }
        else if (New_IDInputField.text != "" && New_PassInputField.text != "" && Confirm_New_PassInputField.text != "")
        {

            Debug.Log("새로 만드는 계정의 ID는?" + New_IDInputField.text);
            Debug.Log("새로 만드는 계정의 비밀번호는?" + New_PassInputField.text);
            Debug.Log("새로만드는 계정의 비밀번호 확인" + Confirm_New_PassInputField.text);


            if (New_PassInputField.text != Confirm_New_PassInputField.text)
            {
                CreateAccountAlert.gameObject.SetActive(true);
                CreateAccountAlert.text = "비밀번호가 일치하지 않습니다.";
            }
            //else if (PlayerPrefs.GetString(playerID, playerID) == New_IDInputField.text)
            //{
            //    CreateAccountAlert.text = "이미 존재하는 계정입니다.";
            //}
            else
            {
                PlayerPrefs.SetString(playerID, playerID);
                PlayerPrefs.SetString(playerID + "secretNum", secreatNum);
                PlayerPrefs.Save();
                LoadingSceneController.LoadScene("LobbyUI");
            }
        }
        yield return null;
    }

    public void ShowLoginAlertPanel()
    {
        if (IDInputField.text == "" || PassInputField.text == "")
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
        if (New_IDInputField.text == "" || New_PassInputField.text == "" || Confirm_New_PassInputField.text == "")
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

    public void GameQuit()
    {
        Application.Quit();
    }
}
