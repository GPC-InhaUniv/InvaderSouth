using UnityEngine;

public class LivingState : IState
{
    private GameObject playerObject;
    private float speed = 0.2f;
    private bool isInput;

    public LivingState()
    {
        playerObject = GameObject.Find("Player").gameObject;
        isInput = true;
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
    }
}
