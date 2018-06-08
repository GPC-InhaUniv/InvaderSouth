using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    private GameObject gameOverObject;
    private bool isBehavior;

    public DeadState()
    {
        gameOverObject = GameObject.Find("Canvas").transform.Find("GameOverImage").gameObject;
        isBehavior = true;
    }

    public void Behavior()
    {
        if(isBehavior == true)
        {
            Debug.Log("Game Over Image Output");
            gameOverObject.SetActive(true);
            isBehavior = false;
        }
    }
}
