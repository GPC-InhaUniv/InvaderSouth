using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShopUIScript : MonoBehaviour 
{
    [SerializeField]
    private GameObject ShopPanel;
    [SerializeField]
    private GameObject WarningPanel;
    [SerializeField]
    private Text WarningText;

    public List<Toggle> ShopToggleList;
    public List<Text> ItemPriceText;
    
    //private int playerMoneyCountText =  GameManager.GetPlayerMoney();
    private int playerDiamondCount = 50;
    //private int playerDiamondCount =  GameManager.GetPlayerDiamond();
    public Text ShowTotalItemPrice;
    public Text CurrentPlayerCash;

    int totalItemPrice = 0;

    // Use this for initialization
    void Start()
    {
        ResetToggleOff();
        GetItemPrice();

    }
    private void Update()
    {
        CurrentPlayerCash.text = GameManager.Instance.GetPlayerMoney() + "G";
    }

    void ResetToggleOff()
    {
        for (int i = 0; i < ShopToggleList.Count; i++)
        {
            ShopToggleList[i].isOn = false;
        }
    }


    public void GetItemPrice()
    {
        int itemprice = 0;
        for (int i = 0; i < ShopToggleList.Count; i++)
        {
           
            if (ShopToggleList[i].isOn)
            {
                itemprice += Convert.ToInt32(ItemPriceText[i].text);
                Debug.Log(ShopToggleList[i] + "는 토글 켜져있음-ON");
            }
            else 
            {
                Debug.Log(ShopToggleList[i] + "는 토글 꺼져있음-OFF");
            }
            
        }
        Debug.Log(itemprice);
        if (itemprice == 0)
        { ShowTotalItemPrice.text = itemprice.ToString();   }
        else
        { ShowTotalItemPrice.text = "-" + itemprice.ToString(); }



    }

 
    public void CloseShopBtn()
    {
        ShopPanel.SetActive(false);
    }

    

    public void OnClickStartBtn()
    {
        totalItemPrice = Convert.ToInt32(ShowTotalItemPrice.text);
        if (totalItemPrice < 0)
            totalItemPrice = totalItemPrice * -1;
        Debug.Log(totalItemPrice);
        int calculateMoneyBeforeStart = Convert.ToInt32(GameManager.Instance.GetPlayerMoney()) - totalItemPrice;
        if (calculateMoneyBeforeStart < 0)
        {
            Debug.Log("소지 금액 부족");
            WarningText.text = "소지금액 " + calculateMoneyBeforeStart.ToString() + " 원이 부족합니다.";
            WarningPanel.SetActive(true);


        }
        else
        {
            DataManager.Instance.BuyItem(totalItemPrice);
            LoadingSceneController.LoadScene("Main");
        }
    }


}
