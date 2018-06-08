using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s
{
    IEnumerator Ddd()
    {
        yield return new WaitForSeconds(5.0f);
    }
}
public class TitleManager : MonoBehaviour
{
    [Header("LoginPanel")]
    [SerializeField]
    private InputField IDInputField;
    [SerializeField]
    private InputField PassInputField;

    [Header("CreateAccountPanel")]
    [SerializeField]
    public InputField New_IDInputField;
    [SerializeField]
    public InputField New_PassInputField;
    [SerializeField]
    public InputField Confirm_New_PassInputField;

    [Header("PopUp")]
    [SerializeField]
    private GameObject LoginAlertPanel;
    [SerializeField]
    private GameObject LoginErrorPanel;
    [SerializeField]
    private GameObject CreateAccountPanel;
    [SerializeField]
    private GameObject CreateAlertPanel;
    [SerializeField]
    private GameObject CreateIDErrorPanel;
    [SerializeField]
    private GameObject LoginPanel;
    [SerializeField]
    private Text CreateAccountAlert;

    [SerializeField]
    private GameObject LoginManager;

    [SerializeField]
    private GameObject IntroManager;

    string playerID = "";

    public static bool IsCreateIDError = false;
    public static bool IsLoginError = false;
    public static bool IsSuccesCreateId = false;
    public static bool IsNotFirstStart=false;

    private void Start()
    {
        Screen.SetResolution(700, 1080, true);
        if(!IsNotFirstStart)
        {
            IntroManager.SetActive(true);
            LoginManager.SetActive(false);
            IsNotFirstStart = true;
        }
        else
        {
            IntroManager.SetActive(false);
            LoginManager.SetActive(true);
        }

    }

    private void Update()
    {
        if (IsLoginError && LoginPanel.activeInHierarchy)
        {
            Debug.Log("로그인 에러!");
            LoginErrorPanel.gameObject.SetActive(true);
            IsLoginError = false;
            IsCreateIDError = false;
        }
        else if (IsCreateIDError && CreateAccountPanel.activeInHierarchy)
        {
            CreateIDErrorPanel.gameObject.SetActive(true);
            IsCreateIDError = false;
            IsLoginError = false;
            IsSuccesCreateId = false;
        }
        else if (CreateAccountPanel.activeInHierarchy && !IsCreateIDError && IsSuccesCreateId)
        {
            
            CreateAlertPanel.gameObject.SetActive(true);
            IsSuccesCreateId = false;
        }

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
           Debug.Log("ID는?" + IDInputField.text);
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

    }

    public void ShowLoginAlertPanel()
    {
        if (IDInputField.text == "" || PassInputField.text == "")
        {
            LoginAlertPanel.gameObject.SetActive(true);
        }
    }

    public void HideLoginErrorPanel()
    {
        LoginErrorPanel.gameObject.SetActive(false);
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

    public void ShowCreateIDErrorPanel()
    {
        CreateIDErrorPanel.gameObject.SetActive(true);
    }

    public void HideCreateIDErrorPanel()
    {
        CreateIDErrorPanel.gameObject.SetActive(false);
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
