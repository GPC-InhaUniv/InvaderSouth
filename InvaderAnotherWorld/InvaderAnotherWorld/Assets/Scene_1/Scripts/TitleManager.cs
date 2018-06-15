using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{

    /*LoginObject가 ActiveInHierachy가 False 이므로 Start 부분에서 find를 하기 않고
    하이라키 상에서 끌어다가 사용*/

    [Header("LoginPanel")]
    [SerializeField]
    private InputField idInputField;
    [SerializeField]
    private InputField passInputField;

    [Header("CreateAccountPanel")]
    [SerializeField]
    private InputField new_IDInputField;
    [SerializeField]
    private InputField new_PassInputField;
    [SerializeField]
    private InputField confirm_New_PassInputField;

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

    private string playerID = "";

    /*AccountInfoMation에서 사용해야 하기 때문에 static으로 선언*/
    public static bool IsCreateIDError = false;
    public static bool IsLoginError = false;
    public static bool IsSuccesCreateId = false;

    private bool IsNotFirstStart=false;

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
        if (idInputField.text != "" && passInputField.text != "")
        {
            //아이디 및 비밀번호를 임시 변수에 저장
            playerID = idInputField.text;
          
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
        playerID = new_IDInputField.text;

    }

    public void ShowLoginAlertPanel()
    {
        if (idInputField.text == "" || passInputField.text == "")
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
