using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : IState
{
    private bool isBehavior;

    public DeadState()
    {
        isBehavior = true;
    }

    public void Behavior()
    {
        if(isBehavior == true)
        {
            isBehavior = false;
            Debug.Log("Game Over Image Output");
        }
    }
}
