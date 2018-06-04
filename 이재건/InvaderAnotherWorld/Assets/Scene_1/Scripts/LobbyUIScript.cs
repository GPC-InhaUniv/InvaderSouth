using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIScript : MonoBehaviour
{
    // UI 위치가 어딘지 몰라서 Diamond UI는 아직 안넣었습니다.
    private int playerDiamondCount;
    // lastCompletedStageNumber = GameManager.lastCompletedStageNumber;
    private int lastCompletedStageNumber = 3;
    // planeCount = GameManager.planeCount;
    private int planeCount = 1;

    private GameObject characterSelectionUIPanel;
    private GameObject stageSelectionUIPanel;
    private GameObject firstCharacterInfoImage;
    private GameObject secondCharacterInfoImage;
    private GameObject firstCharacter;
    private GameObject secondCharacter;
    private GameObject shopPanel;
 

    private Button stageOneSelectionButton;
    private Button stageTwoSelectionButton;
    private Button stageThreeSelectionButton;
    private Text playerMoneyCountText;
    private Text playerNameText;

    private void Awake()
    {
        characterSelectionUIPanel = GameObject.Find("LobbyUICanvas").transform.Find("CharacterSelectionUIPanel").gameObject;
        stageSelectionUIPanel = GameObject.Find("LobbyUICanvas").transform.Find("StageSelectionUIPanel").gameObject;
        shopPanel = GameObject.Find("LobbyUICanvas").transform.Find("ShopPanel").gameObject;
        firstCharacterInfoImage = characterSelectionUIPanel.transform.Find("FirstCharacterInfoImage").gameObject;
        secondCharacterInfoImage = characterSelectionUIPanel.transform.Find("SecondCharacterInfoImage").gameObject;
        firstCharacter = characterSelectionUIPanel.transform.Find("FirstCharacter").gameObject;
        secondCharacter = characterSelectionUIPanel.transform.Find("SecondCharacter").gameObject;
        stageOneSelectionButton = stageSelectionUIPanel.transform.Find("StageOneSelectionButton").GetComponent<Button>();
        stageTwoSelectionButton = stageSelectionUIPanel.transform.Find("StageTwoSelectionButton").GetComponent<Button>();
        stageThreeSelectionButton = stageSelectionUIPanel.transform.Find("StageThreeSelectionButton").GetComponent<Button>();
        playerMoneyCountText = characterSelectionUIPanel.transform.Find("PlayerNameAndMoneyImage").transform.Find("PlayerMoneyCountText").GetComponent<Text>();
        playerNameText = characterSelectionUIPanel.transform.Find("PlayerNameAndMoneyImage").transform.Find("PlayerNameText").GetComponent<Text>();

        lastCompletedStageNumber = Convert.ToInt32(GameManager.Instance.GetPlayerLastCompletedStageNumber());

        // playerMoneyCountText.text = GameManager.GetPlayerMoney();
        // playerNameText.text = GameManager.GetPlayerName();
        // lastCompletedStageNumber = GameManager.LastCompletedStageNumber;
        // playerDiamondCount = GameManager.GetPlayerDiamond();
    }

    private void Update()
    {
        playerMoneyCountText.text = GameManager.Instance.GetPlayerMoney();
        playerNameText.text = GameManager.Instance.GetPlayerName();
    }

    public void OnClickStartButtonOfCharacterSelection()
    {
        characterSelectionUIPanel.SetActive(false);
        stageSelectionUIPanel.SetActive(true);
        lastCompletedStageNumber =Convert.ToInt32(GameManager.Instance.GetPlayerLastCompletedStageNumber());
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

    private void CheckTheDifficulty()
    {
        if (lastCompletedStageNumber >= 2)
            stageTwoSelectionButton.interactable = true;
        if (lastCompletedStageNumber == 3)
            stageThreeSelectionButton.interactable = true;
    }
}
