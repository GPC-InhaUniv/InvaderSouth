using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    private GameObject gameOverUI;
    private bool isBehavior;

    public DeadState()
    {
        gameOverUI = GameObject.Find("InGameUI").transform.Find("GameOverUI").gameObject;
        isBehavior = true;
    }

    public void Behavior()
    {
        if(isBehavior == true)
        {
            gameOverUI.SetActive(true);
            isBehavior = false;
            Debug.Log("Game Over Image Output");
        }
    }
}
