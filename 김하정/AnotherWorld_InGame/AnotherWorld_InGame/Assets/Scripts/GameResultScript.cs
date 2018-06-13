using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameResultScript : MonoBehaviour {

    private Text getPlayerScoreText;
    private Text getPlayerGoldText;
    private int playerScore = 50;  //이번 게임에서 플레이어가 획득한 점수 //임시 값으로 넣어 놨음
    private int tempScore = 0;
    private PlayerController playerstate;
    private GameObject gameEndResultPanel;
    private int playerGold = 100;   //이번 게임에서 플레이어가 획득한 골드. //임시 값으로 넣어 놨음
    private int tempGold = 0;
    //private bool coroutineFlag=true;
    private  Button nextButton;
    
    [SerializeField]
    private int controlChangeScore;


    void Start ()
    {
        getPlayerScoreText = GameObject.Find("GetPlayerScoreText").GetComponent<Text>();
        getPlayerGoldText = GameObject.Find("GetPlayerGoldText").GetComponent<Text>();
        //playerstate = GameObject.Find("PlayerShip").GetComponent<PlayerController>();
        gameEndResultPanel = GameObject.Find("GameEndResultPanel");
       
        nextButton = GameObject.Find("NextButton").GetComponent<Button>();
        nextButton.gameObject.SetActive(false);
        gameEndResultPanel.gameObject.SetActive(false);

    }

    /*delegate*/
    private void Awake()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        player.GameOverResult += GameOverResultMethod;
        player.GameClearResult += GameClearResultMethod;
    }

    void GameOverResultMethod()
    {
        gameEndResultPanel.gameObject.SetActive(true);
        StartCoroutine("ChangeScoreCoroutine");
        StartCoroutine("ChangeGoldCoroutine");
         
    }

    void GameClearResultMethod()
    {
        gameEndResultPanel.gameObject.SetActive(true);//게임 클리어 화면 트루로 바꿔주기
        nextButton.gameObject.SetActive(true);
        StartCoroutine("ChangeScoreCoroutine");
        StartCoroutine("ChangeGoldCoroutine");
        
    }




    //private void Update()
    //{
    //    if (playerstate.isGameOver&& coroutineFlag)
    //    {
    //        gameEndResultPanel.gameObject.SetActive(true);
    //        StartCoroutine("ChangeScoreCoroutine");
    //        StartCoroutine("ChangeGoldCoroutine");
    //        coroutineFlag = false;
    //    }

    //    else if (playerstate.isGameClear && coroutineFlag)
    //    {
    //gameEndResultPanel.gameObject.SetActive(true);//게임 클리어 화면 트루로 바꿔주기
    //        nextButton.gameObject.SetActive(true);
    //        StartCoroutine("ChangeScoreCoroutine");
    //StartCoroutine("ChangeGoldCoroutine");
    //coroutineFlag = false;
    //    }

    //}


    IEnumerator ChangeScoreCoroutine()
    {
        Debug.Log("코루틴 들어왔음");
        
        while (tempScore < playerScore)
        {
            tempScore += 1;
            getPlayerScoreText.text = string.Format("{0:D3}", tempScore);
            if (tempScore < playerScore - controlChangeScore) 
            {
                yield return new WaitForSeconds(0.01f);
            }
            else if (playerScore - controlChangeScore < tempScore  ) 
            { yield return new WaitForSeconds(0.1f); }
             
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

            if (tempScore < playerGold - controlChangeScore)
            {
                yield return new WaitForSeconds(0.01f);
            }
            else if (playerGold - controlChangeScore < tempScore)
            { yield return new WaitForSeconds(0.1f); }
        }
        yield return null;
    }

    public  void RestartBtn()
    {
        playerGold = 0; //어차피 게임내에서 획득한 점수/골드만 초기화 하면 되는것 아닌가여?0ㅇ0
        playerScore = 0;
        SceneManager.LoadScene("  ");   //씬 이름 넣어줄것.
          //아이템은 게임 매니저에 구현되면 넣을 예정.   


        /*
         * 
        *골드랑 점수 초기화
        *점수도 싱글톤에서 가져오기
        *델리게이트는 옵저버
        * 
        */
    }



}
