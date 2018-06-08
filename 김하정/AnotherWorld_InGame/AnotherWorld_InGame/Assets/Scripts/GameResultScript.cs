using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultScript : MonoBehaviour {

    private Text getPlayerScoreText;
    private Text getPlayerGoldText;
    private int playerScore = 500;
    private int tempScore = 0;
    private PlayerController playerstate;
    private GameObject gameEndResultPanel;
    private int playerGold = 100;
    private int tempGold = 0;
    private bool coroutineflag=true;


    void Start ()
    {
        getPlayerScoreText = GameObject.Find("GetPlayerScoreText").GetComponent<Text>();
        getPlayerGoldText = GameObject.Find("GetPlayerGoldText").GetComponent<Text>();
        playerstate = GameObject.Find("PlayerShip").GetComponent<PlayerController>();
        gameEndResultPanel = GameObject.Find("GameEndResultPanel");
        gameEndResultPanel.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (playerstate.isGameOver&& coroutineflag)
        {
            gameEndResultPanel.gameObject.SetActive(true);
            StartCoroutine("ChangeScoreCoroutine");
            StartCoroutine("ChangeGoldCoroutine");
            coroutineflag = false;
        }

        else if (playerstate.isGameClear && coroutineflag)
        {
            gameEndResultPanel.gameObject.SetActive(true);//게임 클리어 화면 트루로 바꿔주기
            StartCoroutine("ChangeScoreCoroutine");
            StartCoroutine("ChangeGoldCoroutine");
            coroutineflag = false;
        }



    }


    IEnumerator ChangeScoreCoroutine()
    {
        Debug.Log("코루틴 들어왔음");
        
        while (tempScore < playerScore)
        {
            tempScore += 1;
            getPlayerScoreText.text = string.Format("{0:D3}", tempScore);
                
            yield return new WaitForSeconds(0.01f);
        }
        yield return null; 
    }



    IEnumerator ChangeGoldCoroutine()
    {
        Debug.Log("코루틴 들어왔음");

        while (tempGold < playerGold)
        {
            tempGold += 1;
            getPlayerGoldText.text = string.Format("{0:D3}", tempGold);

            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }





}
