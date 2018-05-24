using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_test : MonoBehaviour {
    public GameObject PauseUI;
    private bool paused = false;

	// Use this for initialization
	void Start () {
        PauseUI.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Pause"))
        {
            Debug.Log("Pause");
            paused = !paused;
        }
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
            toogleInput(!paused);
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
            toogleInput(!paused);
        }
	}
    public void RestartClick()
    {
        Debug.Log("RestartClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Application.LoadLevel(Application.loadedLevel);
    }
    public void ResumeClick()
    {
        Debug.Log("ResumeClick");
        paused = !paused;
    }
    public void toogleInput(bool IsAlive)
    {
        //PlayerController playerController = new PlayerController();
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = IsAlive;
        //playerController.enabled = IsAlive;
    }
}
