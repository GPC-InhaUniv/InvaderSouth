using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingState : State
{
    private GameObject playerObject;
    private float speed = 0.2f;
    
    public LivingState()
    {
        playerObject = GameObject.Find("PlayerShip").gameObject;
    }

    public void behavior()
    {
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            playerObject.transform.Translate(new Vector3(1, 0, 0) * speed);
        }

        else if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            playerObject.transform.Translate(new Vector3(1, 0, 0) * -speed);
        }

        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerObject.transform.Translate(new Vector3(0, 0, 1) * speed);
        }

        else if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            playerObject.transform.Translate(new Vector3(0, 0, 1) * -speed);
        }
    }
}
