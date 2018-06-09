using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartScene_test : MonoBehaviour {
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("getkey");
            gameObject.SetActive(true);
        }
    }
    public void OnClickOK()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
