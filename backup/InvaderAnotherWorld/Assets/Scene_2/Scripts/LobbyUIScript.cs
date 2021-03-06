﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyUIScript : MonoBehaviour
{
    private int lastCompletedStageNumber = 0;

    private GameObject characterSelectionUIPanel;
    private GameObject stageSelectionUIPanel;
    private GameObject firstCharacterInfoImage;
    private GameObject secondCharacterInfoImage;
    private GameObject firstCharacter;
    private GameObject secondCharacter;
    private GameObject shopPanel;
    private GameObject backToLoginScenePanel;

    private Button stageOneSelectionButton;
    private Button stageTwoSelectionButton;
    private Button stageThreeSelectionButton;
    private Text playerMoneyCountText;
    private Text playerNameText;

    private void Awake()
    {
        SetCharacterSelectionUIPanel();
        SetStageSelectionUIPanel();
        SetShopUIPanel();
        lastCompletedStageNumber = Convert.ToInt32(GameManager.Instance.LastCompletedStageNumber);
    }

    private void Update()
    {
        /* 서버에서 정보가 늦게 들어올 것을 방지하여 데이터가 들어올 때 까지 update*/
        if (playerNameText.text == ""
            || playerMoneyCountText.text == "")
        {
            playerMoneyCountText.text = GameManager.Instance.PlayerMoneyCount.ToString();
            playerNameText.text = GameManager.Instance.PlayerName;
        }
    }

    public void OnClickStartButtonOfCharacterSelection()
    {
        characterSelectionUIPanel.SetActive(false);
        stageSelectionUIPanel.SetActive(true);
        lastCompletedStageNumber =GameManager.Instance.LastCompletedStageNumber;
        CheckTheDifficulty();
     //   Debug.Log("Start Button Click!");
    }

    public void OnClickRightArrowButtonOfCharacterSelection()
    {
        firstCharacter.SetActive(false);
        firstCharacterInfoImage.SetActive(false);
        secondCharacter.SetActive(true);
        secondCharacterInfoImage.SetActive(true);
    //    Debug.Log("Right Arrow Button Click!");
    }

    public void OnClickLeftArrowButtonOfCharacterSelection()
    {
        firstCharacter.SetActive(true);
        firstCharacterInfoImage.SetActive(true);
        secondCharacter.SetActive(false);
        secondCharacterInfoImage.SetActive(false);
    //    Debug.Log("Left Arrow Button Click!");
    }

    private void OnClickBackwardMovementButtonOfStageSelection()
    {
        characterSelectionUIPanel.SetActive(true);
        stageSelectionUIPanel.SetActive(false);
  //      Debug.Log("Backward Movement Button Click!");
    }

    public void OnClickStageOneButtonClick()
    {
  //      Debug.Log("Stage Button Click");
  //      Debug.Log("Go to the store");
        GameManager.Instance.CurrentStage = 0;
        shopPanel.SetActive(true);
    }
    public void OnClickStageTwoButtonClick()
    {
        Debug.Log("Stage Button Click");
        Debug.Log("Go to the store");
        GameManager.Instance.CurrentStage = 1 << 0;
        shopPanel.SetActive(true);
    }
    
    public void OnClickStageThreeButtonClick()
    {
  //      Debug.Log("Stage Button Click");
  //      Debug.Log("Go to the store");
        GameManager.Instance.CurrentStage = 1 << 1;
        shopPanel.SetActive(true);
    }



    public void OnClickBackToLoginSceneButton()
    {
        backToLoginScenePanel.SetActive(true);
    }

    public void OnClickBackLoginYesBtn()
    {
        GameManager.Instance.ResetPlayerInfo();
        SceneManager.LoadScene(0);
    }


    private void CheckTheDifficulty()
    {
        if (lastCompletedStageNumber >= 1)
            stageTwoSelectionButton.interactable = true;
        //if (lastCompletedStageNumber == 2)
        //    stageThreeSelectionButton.interactable = true;
    }

    private void SetCharacterSelectionUIPanel()
    {
        characterSelectionUIPanel = GameObject.Find("LobbyUICanvas").transform.Find("CharacterSelectionUIPanel").gameObject;
        firstCharacterInfoImage = characterSelectionUIPanel.transform.Find("FirstCharacterInfoImage").gameObject;
        secondCharacterInfoImage = characterSelectionUIPanel.transform.Find("SecondCharacterInfoImage").gameObject;
        firstCharacter = characterSelectionUIPanel.transform.Find("FirstCharacter").gameObject;
        secondCharacter = characterSelectionUIPanel.transform.Find("SecondCharacter").gameObject;
        playerMoneyCountText = characterSelectionUIPanel.transform.Find("PlayerNameAndMoneyImage").transform.Find("PlayerMoneyCountText").GetComponent<Text>();
        playerNameText = characterSelectionUIPanel.transform.Find("PlayerNameAndMoneyImage").transform.Find("PlayerNameText").GetComponent<Text>();
        backToLoginScenePanel = characterSelectionUIPanel.transform.Find("BackToLoginScenePanel").gameObject;
        firstCharacterInfoImage = characterSelectionUIPanel.transform.Find("FirstCharacterInfoImage").gameObject;
        secondCharacterInfoImage = characterSelectionUIPanel.transform.Find("SecondCharacterInfoImage").gameObject;
    }

    private void SetStageSelectionUIPanel()
    {
        stageSelectionUIPanel = GameObject.Find("LobbyUICanvas").transform.Find("StageSelectionUIPanel").gameObject;
        stageOneSelectionButton = stageSelectionUIPanel.transform.Find("StageOneSelectionButton").GetComponent<Button>();
        stageTwoSelectionButton = stageSelectionUIPanel.transform.Find("StageTwoSelectionButton").GetComponent<Button>();
       // stageThreeSelectionButton = stageSelectionUIPanel.transform.Find("StageThreeSelectionButton").GetComponent<Button>();
    }

    private void SetShopUIPanel()
    {
        shopPanel = GameObject.Find("LobbyUICanvas").transform.Find("ShopPanel").gameObject;
    }
}
