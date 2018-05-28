using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour {

    public static bool isError = false;

    [SerializeField]
    private List<GameObject> menus = new List<GameObject>();

    [SerializeField]
    private InputField loginUserName;

    [SerializeField]
    private InputField loginPassword;

    [SerializeField]
    private InputField registerUsername;

    [SerializeField]
    private InputField registerEmail;

    [SerializeField]
    private InputField registerPassword;

    [SerializeField]
    private InputField registerConfirmPassword;



    public void Login()
    {
        AccountInfo.Login(loginUserName.text, loginPassword.text);
       
    }

    public void Register()
    {
        if (registerConfirmPassword.text == registerPassword.text)
        {
            AccountInfo.Register(registerUsername.text, registerEmail.text, registerPassword.text);
            isError = false;

        }
        else
        {
            isError = true;
            Debug.LogError("Passwords do not match!");
        }
    }

    public void ChangeMenu(int i)
    {
        GameFunctions.ChangeMenu(menus.ToArray(), i);
    }
 
  
}
