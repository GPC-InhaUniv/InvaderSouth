using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    private GameObject gameOverObject;

    public DeadState()
    {
        gameOverObject = GameObject.Find("Canvas").transform.Find("GameOverImage").gameObject;
    }
    public void behavior()
    {
        gameOverObject.SetActive(true);
    }
}
