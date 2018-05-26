using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMananger : MonoBehaviour {

   

    private void Awake()
    {
        Screen.SetResolution(700, 1080, true);
        Debug.Log(GameController.Instance.CarryingAmount);
    }


    public void OnClickLogin()
    {
        LoadingSceneController.LoadScene("Main");
    }
}
