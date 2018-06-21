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

    [Header("PopUp")]
    [SerializeField]
    private GameObject loginErrorPanel;
    [SerializeField]
    private GameObject createAccountPanel;
    [SerializeField]
    private GameObject createAlertPanel;
    [SerializeField]
    private GameObject loginPanel;
     
    [SerializeField]
    private GameObject loginManager;

    [SerializeField]
    private GameObject introManager;


    /*AccountInfoMation에서 사용해야 하기 때문에 static으로 선언*/
    public static bool IsCreateIDError = false;
    public static bool IsLoginError = false;
    public static bool IsSuccesCreateId = false;

    private bool isNotFirstStart=false;

    private void Start()
    {
        Screen.SetResolution(700, 1080, true);
        if(!isNotFirstStart)
        {
            introManager.SetActive(true);
            loginManager.SetActive(false);
            isNotFirstStart = true;
        }
        else
        {
            introManager.SetActive(false);
            loginManager.SetActive(true);
        }


    }

    private void Update()
    {
        if (IsLoginError && loginPanel.activeInHierarchy)
        {
            Debug.Log("로그인 에러!");
            loginErrorPanel.gameObject.SetActive(true);
            IsLoginError = false;
            IsCreateIDError = false;
        }
        else if (IsCreateIDError && createAccountPanel.activeInHierarchy)
        {
            IsCreateIDError = false;
            IsLoginError = false;
            IsSuccesCreateId = false;
        }
        else if (createAccountPanel.activeInHierarchy && !IsCreateIDError && IsSuccesCreateId)
        {
            createAlertPanel.gameObject.SetActive(true);
            IsSuccesCreateId = false;
        }

    }

    public void OnClickedGameQuit()
    {
        Application.Quit();
    }
}
