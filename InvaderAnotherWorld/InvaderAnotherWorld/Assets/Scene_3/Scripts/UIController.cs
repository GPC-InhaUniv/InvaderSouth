using System.Collections;
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

    [SerializeField]
    private GameObject bossStatus;
    [SerializeField]
    private Image bossHpImage;
    private BossController bossController;

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

    [SerializeField]
    GameObject pausePanel;


    // Use this for initialization
    void Start()
    {
        SetPlayerInfo();
        SetGameReulstUI();
        SetPlayerUI();
        ReFresh();
        //일시정지 ui
        pausePanel = GameObject.Find("InGameUI").transform.Find("PausePanel").gameObject;
    }

    void SetGameReulstUI()
    {
        gameClearUI = GameObject.Find("InGameUI").transform.Find("GameClearUI").gameObject;
        gameOverUI = GameObject.Find("InGameUI").transform.Find("GameOverUI").gameObject;
        gameReulstPanel = GameObject.Find("InGameUI").transform.Find("GameEndResultPanel").gameObject;
        gameobjectPool = GameObject.Find("GameObjectPool").gameObject;
        
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

        //esc키를 받는지 검사
        if (playerstatusComponent.PlayerHp>0 && !gameCleard && Input.GetKeyDown(KeyCode.Escape))//Input.GetButtonDown("Pause")
        {
            //Debug.Log("Pause");
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }

        if(bossController!=null)
        {
            bossHpImage.fillAmount = bossController.BossHp / 30f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentStage == 1 && StageManager.time >= 45 && bossController == null)
            bossController = GameObject.Find("BossMonster").GetComponent<BossController>();


        ReFresh();
    }

    public void OnClickedBackToMainBtn()
    {
        StageManager.time = 0;
        StageManager.KillEnemyCount = 0;
        Destroy(gameobjectPool);
        Time.timeScale = 1;
        LoadingSceneController.LoadScene("Lobby");
    }

    public void OnClickedRestartBtn()
    {
        StageManager.time = 0;
        StageManager.KillEnemyCount = 0;
        Destroy(gameobjectPool);
        Time.timeScale = 1;
        LoadingSceneController.LoadScene("Main");
    }
    
    //일시정지
    public void OnClickedResumeBtn()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
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
        yield return new WaitForSeconds(1.0f); 
        gameReulstPanel.SetActive(true);
        if (result)
        {
            resultGameText.text = "Game Clear";
            NextStageBtn.SetActive(true);
            Debug.Log("게임승리");
            SetGameDataToServer();
            //수정
            DataManager.Instance.SetCompleteStage();
        }

        else
        {
            resultGameText.text = "Game Over";
            NextStageBtn.SetActive(false);
            Debug.Log("게임패배");
            SetGameDataToServer();
        }
        Time.timeScale = 0;
        yield return null;
    }

    void SetGameDataToServer()
    {
        resultScoreText.text = playerstatusComponent.Score.ToString();
        int getGoldAmount = playerstatusComponent.Score / 10;
        if (GameManager.Instance.BuyItemList[0])
        {
            resultGoldText.text =getGoldAmount.ToString()+" x2";
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
