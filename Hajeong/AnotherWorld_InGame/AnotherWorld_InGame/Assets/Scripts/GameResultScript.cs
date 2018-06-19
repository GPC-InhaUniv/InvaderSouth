using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameResultScript : MonoBehaviour {

    private Text playerScoreText;
    private Text playerGoldText;
    private int playerScore = 50;  //이번 게임에서 플레이어가 획득한 점수 //임시 값으로 넣어 놨음
    private int tempScore = 0;
    private PlayerController playerstate;
    private GameObject gameEndResultPanel;
    private int playerGold = 100;   //이번 게임에서 플레이어가 획득한 골드. //임시 값으로 넣어 놨음
    private int tempGold = 0;
    private  Button nextButton;
    
    [SerializeField]
    private int controlChangeScore;


    void Start ()
    {
        SetGameResultUIObject();
        nextButton.gameObject.SetActive(false);
        gameEndResultPanel.gameObject.SetActive(false);
    }


    private void SetGameResultUIObject()
    {
        gameEndResultPanel = GameObject.Find("GameEndResultPanel");
        playerScoreText = gameEndResultPanel.transform.Find("PlayerScoreText").GetComponent<Text>();
        playerGoldText = gameEndResultPanel.transform.Find("PlayerGoldText").GetComponent<Text>();
        nextButton = gameEndResultPanel.transform.Find("NextButton").GetComponent<Button>();
    }




    /*delegate*/
    private void Awake()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        player.GameOverResult += GameOverResultMethod;
        player.GameClearResult += GameClearResultMethod;
    }

    private void GameOverResultMethod()
    {
        gameEndResultPanel.gameObject.SetActive(true);
        StartCoroutine("ChangeScoreCoroutine");
        StartCoroutine("ChangeGoldCoroutine");
         
    }

    private void GameClearResultMethod()
    {
        gameEndResultPanel.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        StartCoroutine("ChangeScoreCoroutine");
        StartCoroutine("ChangeGoldCoroutine");
        
    }

    IEnumerator ChangeScoreCoroutine()
    {
        Debug.Log("코루틴 들어왔음");
        
        while (tempScore < playerScore)
        {
            tempScore += 1;
            playerScoreText.text = string.Format("{0:D3}", tempScore);
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
            playerGoldText.text = string.Format("{0:D3}", tempGold);

            if (tempScore < playerGold - controlChangeScore)
            {
                yield return new WaitForSeconds(0.01f);
            }
            else if (playerGold - controlChangeScore < tempScore)
            { yield return new WaitForSeconds(0.1f); }
        }
        yield return null;
    }

    public  void OnClickedRestartButton()
    {
        playerGold = 0; //어차피 게임내에서 획득한 점수/골드만 초기화 하면 되는것 아닌가여?0ㅇ0
        playerScore = 0;
        SceneManager.LoadScene("Lobby");   
          //아이템은 게임 매니저에 구현되면 넣을 예정.   
 
    }



}
