using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    private GameObject lobbyGUI;
    private GameController allGameManager;
    public Button Stage2Button;
    public Button Stage3Button;

    private void Start()
    {
        lobbyGUI = GameObject.Find("LobbyGUI");
        allGameManager = GameObject.Find("GameController").GetComponent<GameController>();
        Stage2Button = GameObject.Find("LobbyGUI").transform.Find("Stage").transform.Find("Canvas").transform.Find("Stage2Button").GetComponent<Button>();
        Stage3Button = GameObject.Find("LobbyGUI").transform.Find("Stage").transform.Find("Canvas").transform.Find("Stage3Button").GetComponent<Button>();
    }

    private void Update()
    {
        if(allGameManager.Count == 2)
        {
            Stage2Button.interactable = true;
        }

        if (allGameManager.Count == 3)
        {
            Stage3Button.interactable = true;
        }
    }

    public void OnLobbyStart()
    {
        lobbyGUI.transform.Find("Lobby").gameObject.SetActive(false);
        lobbyGUI.transform.Find("Stage").gameObject.SetActive(true);
        Debug.Log("스테이지 UI로 이동!");
    }

    public void OnStageClick()
    {
        lobbyGUI.transform.Find("Stage").gameObject.SetActive(false);
        lobbyGUI.transform.Find("Shop").gameObject.SetActive(true);
        Debug.Log("상점 UI로 이동!");
    }

    public void ShopStart()
    {
        Debug.Log("메인 게임 입장!");
        if(allGameManager.CarryingAmount < allGameManager.TotalAmount)
        {
            Debug.Log("소지금액 부족");
        }

        else
        {
            allGameManager.CarryingAmount -= allGameManager.TotalAmount;
            PlayerPrefs.SetInt(allGameManager.PlayerName + "CarryingAmount", allGameManager.CarryingAmount);
            Debug.Log("소지금액 : " + allGameManager.CarryingAmount);
            LoadingSceneController.LoadScene("Main");
        }
    }

    public void OnItem1Toggle()
    {
        allGameManager.LifeUpAndDown(lobbyGUI.transform.Find("Shop").transform.Find("Canvas").transform.Find("Item1").GetComponent<Toggle>().isOn);
        lobbyGUI.transform.Find("Shop").transform.Find("Canvas").transform.Find("StartButton").transform.Find("Text").GetComponent<Text>().text = "Start\n" + "" + allGameManager.TotalAmount.ToString();

        //if (lobbyGUI.transform.Find("Shop").transform.Find("Canvas").transform.Find("Item1").GetComponent<Toggle>().isOn == true)
        //{
        //    Debug.Log("Item1 구매 체크");
        //}

        //else
        //{
        //    Debug.Log("Item1 구매 해제");
        //}
    }
    
    public void OnItem2Toggle()
    {
        allGameManager.DamageUpAndDown(lobbyGUI.transform.Find("Shop").transform.Find("Canvas").transform.Find("Item2").GetComponent<Toggle>().isOn);
        lobbyGUI.transform.Find("Shop").transform.Find("Canvas").transform.Find("StartButton").transform.Find("Text").GetComponent<Text>().text = "Start\n" + "" + allGameManager.TotalAmount.ToString();

        //if (lobbyGUI.transform.Find("Shop").transform.Find("Canvas").transform.Find("Item2").GetComponent<Toggle>().isOn == true)
        //{
        //    Debug.Log("Item2 구매 체크");
        //}

        //else
        //{
        //    Debug.Log("Item2 구매 해제");
        //}
    }

    public void OnItem3Toggle()
    {
        if (lobbyGUI.transform.Find("Shop").transform.Find("Canvas").transform.Find("Item3").GetComponent<Toggle>().isOn == true)
        {
            Debug.Log("Item3 구매 체크");
        }

        else
        {
            Debug.Log("Item3 구매 해제");
        }
    }

    public void RightArrowClick()
    {
        lobbyGUI.transform.Find("Lobby").transform.Find("Canvas").transform.Find("character1Button").gameObject.SetActive(false);
        lobbyGUI.transform.Find("Lobby").transform.Find("Canvas").transform.Find("character2Button").gameObject.SetActive(true);
        Debug.Log("오른쪽 화살표 클릭!");
    }

    public void LeftArrowClick()
    {
        lobbyGUI.transform.Find("Lobby").transform.Find("Canvas").transform.Find("character1Button").gameObject.SetActive(true);
        lobbyGUI.transform.Find("Lobby").transform.Find("Canvas").transform.Find("character2Button").gameObject.SetActive(false);
        Debug.Log("왼쪽 화살표 클릭!");
    }

    public void OnShopBackButtonClick()
    {
        lobbyGUI.transform.Find("Stage").gameObject.SetActive(true);
        lobbyGUI.transform.Find("Shop").gameObject.SetActive(false);
        Debug.Log("상점에서 스테이지 UI로 되돌아가기!");
    }

    public void OnStageBackButtonClick()
    {
        lobbyGUI.transform.Find("Stage").gameObject.SetActive(false);
        lobbyGUI.transform.Find("Lobby").gameObject.SetActive(true);
        Debug.Log("스테이지에서 로비 UI로 되돌아가기!");
    }

    public void OnStageTwoButtonClick()
    {
        Debug.Log("Stage2 입장");
    }

    public void OnStageThreeOnButtonClick()
    {
        Debug.Log("Stage3 입장");
    }

    public void OnStageClearButtonClick()
    {
        allGameManager.GameClear();
    }
}