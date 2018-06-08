using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingState : State
{
    private GameObject playerObject;
    private float speed = 0.2f;
    private bool isInput;
    private bool isGameClear;
    
    public LivingState()
    {
        playerObject = GameObject.Find("PlayerShip").gameObject;
        isInput = true;
        isGameClear = false;
    }

    public void Behavior()
    {
        if (isInput == true)
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

        //보스 몬스터가 죽었을 경우에 Gaem Clear를 보여주는 if문 작성!
        //if (보스가 살아있는가 != true)
        //{
        //    isInput = false;
        //    isGameClear = true;    
        //    if (isGameClear != flase)
        //    {
        //        Gaem Clear를 화면에 보여준다.
        //        isGameClear = false;
        //    }
        //}
    }
}
