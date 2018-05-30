using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleController : MonoBehaviour
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

    string playerID = "";
    string secreatNum = "";
    private void Start()
    {
        Screen.SetResolution(700, 1080, true);
    }
    /// <summary>
    /// Login, CreateAccount
    /// </summary>
    public void LoginBtn()
    {
         LoingAccount();
    }

    void LoingAccount()
    {
        if (IDInputField.text != "" && PassInputField.text != "")
        {
            //아이디 및 비밀번호를 임시 변수에 저장
            playerID = IDInputField.text;
            secreatNum = PassInputField.text;

            Debug.Log("ID는?" + IDInputField.text);
            Debug.Log("비밀번호는?" + PassInputField.text);

            if (!LoginManager.isError)
            {

                Debug.Log("로그인 성공");
            }
            else
            {
                CreateAccountAlert.text = "아이디 및 비밀번호 오류입니다.";
                CreateAccountAlert.gameObject.SetActive(true);
                Debug.Log("로그인 실패");
            }

        }
    }

    public void OpenCreateAccountBtn()
    {
        CreateAccountPanel.SetActive(true);
    }

    public void CreateAccountBtn()
    {
        CreateAccount();
    }

    void CreateAccount()
    {
        playerID = New_IDInputField.text;
        secreatNum = New_PassInputField.text;



        if (!LoginManager.isError)
        {
            Debug.Log("계정 생성 성공");
        }
        else
        {
            Debug.Log("계정 생성 실패");
        }

 
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
        CreateAlertPanel.gameObject.SetActive(true);

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
