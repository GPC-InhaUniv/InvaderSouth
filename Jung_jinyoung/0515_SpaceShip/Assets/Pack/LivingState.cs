using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LivingState : State
{
    private GameObject playerObject;
    private float speed = 0.2f;
    //private float speed = 10f;
    public float tilt = 3f;
    private bool isInput;
    private bool isGameClear;
    Rigidbody rigidbodyShip;

    public Boundary boundary = new Boundary();


    public LivingState()
    {
        playerObject = GameObject.Find("PlayerShipObject").gameObject;
        isInput = true;
        isGameClear = false;

        boundary.xMax = 6f;
        boundary.xMin = -6f;
        boundary.zMax = 8f;
        boundary.zMin = -8f;
        rigidbodyShip = playerObject.GetComponent<Rigidbody>();
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
        //if (isInput == true)
        //    MovingShip();
    }
    void MovingShip()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //Debug.Log(Input.GetAxis("Vertical"));

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbodyShip.velocity = movement * speed;

        rigidbodyShip.position = new Vector3
        (
            Mathf.Clamp(rigidbodyShip.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbodyShip.position.z, boundary.zMin, boundary.zMax)
        );
        rigidbodyShip.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbodyShip.velocity.x * -tilt);
    }
}
