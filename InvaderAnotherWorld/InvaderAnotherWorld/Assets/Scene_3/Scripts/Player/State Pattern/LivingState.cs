using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingState : IState
{
    private GameObject playerObject;
    private float speed = 0.2f;
    private bool isInput;
    private GameObject gameClearUI;
    
    public LivingState()
    {
        gameClearUI = GameObject.Find("InGameUI").transform.Find("GameClearUI").gameObject;
        playerObject = GameObject.Find("Player").gameObject;
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

        // 스테이지 1일 떄, 90가되면 게임 클리어가 뜬다.
        if (GameManager.Instance.CurrentStage == 0)
        {
            if (StageManager.time == 95)
            {
                gameClearUI.SetActive(true);
            }
        }

        else if (GameManager.Instance.CurrentStage == 1)
        {
            if (BossController.IsBossAlive != true)
            {
                gameClearUI.SetActive(true);
            }
        }
    }
}
