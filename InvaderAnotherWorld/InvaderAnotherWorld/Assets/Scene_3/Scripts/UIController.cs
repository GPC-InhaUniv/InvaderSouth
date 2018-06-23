using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{

    [SerializeField]
    private Image hpBar;
    [SerializeField]
    private Image skillBar;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text skillAmountText;

    private GameObject gameClearUI;
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject gameReulstPanel;
    [SerializeField]
    private Text resultGameText;
    [SerializeField]
    private Text resultScoreText;
    [SerializeField]
    private Text resultGoldText;
    [SerializeField]
    private GameObject NextStageBtn;

    private GameObject gameobjectPool;
    private MastarPlayerController mastarPlayerController;

    private PlayerStatus playerstatusComponent;
    private float previousSkillAmount;

    private bool gameCleard = false;
    // Use this for initialization
    void Start()
    {
        SetPlayerInfo();
        SetGameReulstUI();
        SetPlayerUI();
        ReFresh();
    }

    void SetGameReulstUI()
    {
        gameClearUI = GameObject.Find("InGameUI").transform.Find("GameClearUI").gameObject;
        gameOverUI = GameObject.Find("InGameUI").transform.Find("GameOverUI").gameObject;
        gameReulstPanel = GameObject.Find("InGameUI").transform.Find("GameEndResultPanel").gameObject;
        gameobjectPool = GameObject.Find("GameObjectPool").gameObject;
        //resultGameText = gameReulstPanel.transform.Find("GameEndResultPanel").Find("GameResultText").GetComponent<Text>();
        //resultScoreText = gameReulstPanel.transform.Find("GameEndResultPanel").Find("PlayerScoreText").GetComponent<Text>();
        //resultGoldText = gameReulstPanel.transform.Find("GameEndResultPanel").Find("PlayerGoldText").GetComponent<Text>();
        //NextStageBtn = gameReulstPanel.transform.Find("GameEndResultPanel").Find("NextButton").gameObject;
    }

    void SetPlayerInfo()
    {
        mastarPlayerController = GameObject.Find("Player").GetComponent<MastarPlayerController>();
        playerstatusComponent = GameObject.Find("Player").GetComponent<PlayerStatus>();
        mastarPlayerController.GameResultDelegate = new MastarPlayerController.GameResult(GameResult);
    }

    void SetPlayerUI()
    {
        skillBar.fillAmount = playerstatusComponent.SkillAmount / 2;
        skillAmountText.text = (playerstatusComponent.SkillAmount * 100).ToString() + "%";
        previousSkillAmount = 0.0f;
    }


    public void ReFresh()
    {
        hpBar.fillAmount = playerstatusComponent.PlayerHp / 10f;

        if (hpBar.fillAmount >= 0.3f && hpBar.fillAmount <= 0.5f)
            hpBar.color = Color.yellow;
        else if (hpBar.fillAmount < 0.3f)
            hpBar.color = Color.red;


        if (playerstatusComponent.SkillAmount == 0)
        {
            skillBar.fillAmount = 0;
            skillAmountText.text = "0%";
            previousSkillAmount = 0.0f;
        }
        else if (previousSkillAmount < playerstatusComponent.SkillAmount / 2
           && skillBar.fillAmount < 0.5f)
        {
            skillBar.fillAmount += 0.005f;
            previousSkillAmount += 0.005f;
            if (previousSkillAmount >= 0.5f ||
                skillBar.fillAmount >= 0.5f)
            {
                previousSkillAmount = 0.5f;
                skillBar.fillAmount = 0.5f;
            }

            skillAmountText.text = (Math.Truncate(skillBar.fillAmount * 2 * 100)).ToString() + "%";
        }

        scoreText.text = playerstatusComponent.Score.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        ReFresh();
    }

    public void OnClickedBackToMainBtn()
    {
        Destroy(gameobjectPool);
        LoadingSceneController.LoadScene("Lobby");
    }

    public void OnClickedRestartBtn()
    {
        Destroy(gameobjectPool);
        LoadingSceneController.LoadScene("Main");
    }
    public void GameResult(bool result)
    {
        if (result == true)
        {
            if (GameManager.Instance.CurrentStage == 0)
            {
                if (StageManager.time >= 100&& !gameCleard)
                {
                    gameClearUI.SetActive(true);
                    gameCleard = true;
                    StartCoroutine(SetGameResult(result));
                }
            }

            else if (GameManager.Instance.CurrentStage == 1)
            {
                if (BossController.IsBossAlive != true && !gameCleard)
                {
                    gameClearUI.SetActive(true);
                    gameCleard = true;
                    StartCoroutine(SetGameResult(result));
                }
            }
        }

        if (result == false)
        {
            gameOverUI.SetActive(true);
            StageManager.time = 90;
            StartCoroutine(SetGameResult(result));
        }

    }

    IEnumerator SetGameResult(bool result)
    {
        StageManager.time = 0;
        StageManager.KillEnemyCount = 0;
        yield return new WaitForSeconds(1.0f); 
        gameReulstPanel.SetActive(true);
        if (result)
        {
            resultGameText.text = "Game Clear";
            NextStageBtn.SetActive(true);
            Debug.Log("게임승리");
            SetGameDataToServer();
        }

        else
        {
            resultGameText.text = "Game Over";
            NextStageBtn.SetActive(false);
            Debug.Log("게임패배");
              SetGameDataToServer();
        }

        yield return null;
    }

    void SetGameDataToServer()
    {
        resultScoreText.text = playerstatusComponent.Score.ToString();
        int getGoldAmount = playerstatusComponent.Score / 10;
        if (GameManager.Instance.BuyItemList[0])
        {
            resultGoldText.text ="아이템 효과! "+getGoldAmount*2;
            getGoldAmount *= 2;
            GameManager.Instance.BuyItemList[0] = false;
        }
        else
        {
            resultGoldText.text = getGoldAmount.ToString();
        }
        Debug.Log(getGoldAmount + "원을 벌었음");
        DataManager.Instance.BuyMoney(getGoldAmount);
    }
}
