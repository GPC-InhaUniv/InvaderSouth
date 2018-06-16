using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyUIScript_test : MonoBehaviour
{
    private int lastCompletedStageNumber = 0;
    // planeCount = GameManager.planeCount;

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
      //  playerMoneyCountText.text = GameManager.Instance.PlayerMoneyCount;
        playerNameText.text = GameManager.Instance.PlayerName;
    }

    public void OnClickStartButtonOfCharacterSelection()
    {
        characterSelectionUIPanel.SetActive(false);
        stageSelectionUIPanel.SetActive(true);
        lastCompletedStageNumber =Convert.ToInt32(GameManager.Instance.LastCompletedStageNumber);
        CheckTheDifficulty();
        Debug.Log("Start Button Click!");
    }

    public void OnClickRightArrowButtonOfCharacterSelection()
    {
        firstCharacter.SetActive(false);
        firstCharacterInfoImage.SetActive(false);
        secondCharacter.SetActive(true);
        secondCharacterInfoImage.SetActive(true);
        Debug.Log("Right Arrow Button Click!");
    }

    public void OnClickLeftArrowButtonOfCharacterSelection()
    {
        firstCharacter.SetActive(true);
        firstCharacterInfoImage.SetActive(true);
        secondCharacter.SetActive(false);
        secondCharacterInfoImage.SetActive(false);
        Debug.Log("Left Arrow Button Click!");
    }

    public void OnClickBackwardMovementButtonOfStageSelection()
    {
        characterSelectionUIPanel.SetActive(true);
        stageSelectionUIPanel.SetActive(false);
        Debug.Log("Backward Movement Button Click!");
    }

    public void OnClickStageButtonClick()
    {
        Debug.Log("Stage Button Click");
        Debug.Log("Go to the store");
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
        if (lastCompletedStageNumber == 2)
            stageThreeSelectionButton.interactable = true;
    }

    private void SetCharacterSelectionUIPanel()
    {
        characterSelectionUIPanel = GameObject.Find("LobbyUICanvas").transform.Find("CharacterSelectionUIPanel").gameObject;
        firstCharacter = characterSelectionUIPanel.transform.Find("FirstCharacter").gameObject;
        firstCharacter = characterSelectionUIPanel.transform.Find("FirstCharacter").gameObject;
        secondCharacter = characterSelectionUIPanel.transform.Find("SecondCharacter").gameObject;
        backToLoginScenePanel = characterSelectionUIPanel.transform.Find("BackToLoginScenePanel").gameObject;
        playerNameText = characterSelectionUIPanel.transform.Find("PlayerNameAndMoneyImage").transform.Find("PlayerNameText").GetComponent<Text>();
        playerMoneyCountText = characterSelectionUIPanel.transform.Find("PlayerNameAndMoneyImage").transform.Find("PlayerMoneyCountText").GetComponent<Text>();
    }

    private void SetStageSelectionUIPanel()
    {
        stageSelectionUIPanel = GameObject.Find("LobbyUICanvas").transform.Find("StageSelectionUIPanel").gameObject;
        stageOneSelectionButton = stageSelectionUIPanel.transform.Find("StageOneSelectionButton").GetComponent<Button>();
        stageTwoSelectionButton = stageSelectionUIPanel.transform.Find("StageTwoSelectionButton").GetComponent<Button>();
        stageThreeSelectionButton = stageSelectionUIPanel.transform.Find("StageThreeSelectionButton").GetComponent<Button>();
    }

    private void SetShopUIPanel()
    {
        shopPanel = GameObject.Find("LobbyUICanvas").transform.Find("ShopPanel").gameObject;
    }
}
