using UnityEngine;

public class ButtonMananger : MonoBehaviour
{

    private void Awake()
    {
        Screen.SetResolution(700, 1080, true);

    }


    public void OnClickLogin()
    {
        LoadingSceneController.LoadScene("Main");
    }
}
