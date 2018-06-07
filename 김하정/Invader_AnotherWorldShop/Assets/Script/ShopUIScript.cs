using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class ShopUIScript : MonoBehaviour 
{
    [Header("<Shop>")]
    private GameObject ShopPanel;
    [SerializeField]
    private List<Toggle> ShopToggleList;
    [SerializeField]
    private List<Text> ItemPriceText;
    
    //싱글톤으로 연결 부탁드립니다. 값은 테스트를 위해 임시로 넣어놨어요!
    private  int playerMoneyCount = GameManager.GetPlayerMoney();
    
    private int playerDiamondCount = GameManager.GetPlayerDiamond();
    

    private int ShowTotalItemPrice;
    private Text ShowTotalItemPriceText;
    private Text CurrentPlayerCashText;
    
    [Header("<Gold>")]
    private Text GoldAlert;
    
    private int MaxGold = 9999999 ;
    [SerializeField]
    private List<Text> GoldPriceText;
    [SerializeField]
    private List<int> GoldPrice;    //이후에도 골드가격을 편하게 추가/변경할 수 있도록 배열로 생성
    private GameObject BuyGoldPanel;
    private Image BuyAlert;
    private Text CanBuyGoldAndDiamondText;
    private Text CantBuyGoldAndDiamondText;
   
    public int DiamondPriceForGold; //골드당 다이아몬드 가격 나중에 배열로 바꿔서 각기 정해줄 예정

    private int SaveGoldItemPrice= 0;
    private int SaveDiamondItemPrice = 0;
    private Image ThankAlert;

   
    [Header("<Diamond>")]
   
    private int MaxDiamond = 999999;
    [SerializeField]
    private List<Text> DiamondPriceText;
    [SerializeField]
    private List<int> DiamondPrice; //이후에도 다이아몬드가격을 편하게 추가/변경할 수 있도록 배열로 생성
   
    private GameObject BuyDiamondPanel;
    private Text DiamondAlert;

    private GameObject DiamondButtonPanel;
    private Text CurrentPlayerDiamondText;


    void Start()
    {
        /*오브젝트 불러오기*/
        ShopPanel = GameObject.Find("ShopPanel");
        ShowTotalItemPriceText = GameObject.Find("ShowTotalItemPriceText").GetComponent<Text>();
        CurrentPlayerCashText = GameObject.Find("CurrentPlayerCashText").GetComponent<Text>();
        GoldAlert = GameObject.Find("GoldAlert").GetComponent<Text>();
        GoldAlert.gameObject.SetActive(false);
        BuyGoldPanel = GameObject.Find("BuyGoldPanel");
        BuyAlert = GameObject.Find("BuyAlert").GetComponent<Image>();
        CanBuyGoldAndDiamondText = GameObject.Find("CanBuyGoldAndDiamondText").GetComponent<Text>();
        CantBuyGoldAndDiamondText = GameObject.Find("CantBuyGoldAndDiamondText").GetComponent<Text>();
        ThankAlert = GameObject.Find("ThankAlert").GetComponent<Image>();

        BuyDiamondPanel = GameObject.Find("BuyDiamondPanel");
        DiamondAlert = GameObject.Find("DiamondAlert").GetComponent<Text>();
        DiamondButtonPanel = GameObject.Find("DiamondButtonPanel");
        CurrentPlayerDiamondText = GameObject.Find("CurrentPlayerDiamondText").GetComponent<Text>();

        DiamondButtonPanel.gameObject.SetActive(false);
        DiamondAlert.gameObject.SetActive(false);
        BuyDiamondPanel.gameObject.SetActive(false);
        ThankAlert.gameObject.SetActive(false);
        CantBuyGoldAndDiamondText.gameObject.SetActive(false);
        CanBuyGoldAndDiamondText.gameObject.SetActive(false);
        BuyAlert.gameObject.SetActive(false);
        BuyGoldPanel.gameObject.SetActive(false);



        ResetToggleOff();
        GetItemPrice();
        CurrentPlayerCashText.text = playerMoneyCount.ToString() + "G";
        CurrentPlayerDiamondText.text = playerDiamondCount.ToString() + " D";

        //배열로 받아온 골드 가격 텍스트에 골드 가격(마찬가지로 배열)을 넣어줌//
        for (int i = 0; i < GoldPrice.Count; i++)
        {
            GoldPriceText[i].text = GoldPrice[i].ToString();
        }

        //배열로 받아온 다이아몬드 가격 텍스트에 다이아몬드 가격(마찬가지로 배열)을 넣어줌//
        for (int i = 0; i < DiamondPrice.Count; i++)
        {
            DiamondPriceText[i].text = DiamondPrice[i].ToString();
        }
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
        int itemPrice = 0;

        for (int i = 0; i < ShopToggleList.Count; i++)
        {
           
            if (ShopToggleList[i].isOn)
            {
                itemPrice += Convert.ToInt16(ItemPriceText[i].text);
                Debug.Log(ShopToggleList[i] + "는 토글 켜져있음-ON");
            }
            else 
            {
                Debug.Log(ShopToggleList[i] + "는 토글 꺼져있음-OFF");
            }
            
        }
        Debug.Log(itemPrice);
        if (itemPrice == 0)
        {
            ShowTotalItemPriceText.text = "0";
        }
        else
        {
            ShowTotalItemPrice = itemPrice;
            ShowTotalItemPriceText.text = "-" + ShowTotalItemPrice.ToString();
        }
    }

    public void CloseShopBtn()
    {
        ShopPanel.SetActive(false);
    }

    public void BuyItem()
    {
        playerMoneyCount -= ShowTotalItemPrice;
        CurrentPlayerCashText.text = playerMoneyCount.ToString() + "G";
    }

    /// <summary>
    /// 골드 구매
    /// </summary>
    //골드 구매 버튼//
    public void GoldBtn()
    {
        if (playerMoneyCount >= MaxGold)
        {
            GoldAlert.gameObject.SetActive(true);
        }
        else
        {
            GoldAlert.gameObject.SetActive(false);
            BuyGoldPanel.gameObject.SetActive(true);
            ThankAlert.gameObject.SetActive(false);
            BuyAlert.gameObject.SetActive(false);
        }
    }

    //골드 구매 시 , 상황별 알림창 띄우는 메소드//
    public void BuyGoldAlertMethod()
    {
        if (playerDiamondCount >= DiamondPriceForGold)
        {
            BuyAlert.gameObject.SetActive(true);
            CanBuyGoldAndDiamondText.gameObject.SetActive(true);
            CantBuyGoldAndDiamondText.gameObject.SetActive(false);
        }
        else
        {
            BuyAlert.gameObject.SetActive(true);
            CantBuyGoldAndDiamondText.gameObject.SetActive(true);
            CanBuyGoldAndDiamondText.gameObject.SetActive(false);
        }
    }

    //골드 구매 시 : 정말로 구매하시겠습니까 창이 떴을때 Yes버튼을 누르면 작동하는 메소드//
    public void BuyGold()
    {
        if (playerDiamondCount >= DiamondPriceForGold)
        {
            playerMoneyCount += SaveGoldItemPrice;
            playerDiamondCount -= DiamondPriceForGold;
            CurrentPlayerDiamondText.text = playerDiamondCount.ToString() + " D";
            CurrentPlayerCashText.text = playerMoneyCount.ToString() + "G";
            ThankAlert.gameObject.SetActive(true);
        }
        else if(playerDiamondCount <= DiamondPriceForGold)
        {
            BuyDiamondPanel.gameObject.SetActive(true);
            BuyAlert.gameObject.SetActive(false);
            BuyGoldPanel.gameObject.SetActive(false);
        }
    }

   // 골드 구매 버튼 메소드
    public void SelectGoldButton0()
    {
        SaveGoldItemPrice = GoldPrice[0];
    }
    public void SelectGoldButton1()
    {
        SaveGoldItemPrice = GoldPrice[1];
    }
    public void SelectGoldButton2()
    {
        SaveGoldItemPrice = GoldPrice[2];
    }
    public void SelectGoldButton3()
    {
        SaveGoldItemPrice = GoldPrice[3];
    }
    public void SelectGoldButton4()
    {
        SaveGoldItemPrice = GoldPrice[4];
    }

   /// <summary>
   /// 다이아몬드 구매
   /// </summary>
    //다이아몬드 구매 버튼 눌렀을 시.
    public void DiamondBtn()
    {
        if (playerDiamondCount >= MaxDiamond)
        {
            //다이아몬드 알람으로 띄우기
            DiamondAlert.gameObject.SetActive(true);
        }
        else
        {
            DiamondAlert.gameObject.SetActive(false);
            BuyDiamondPanel.gameObject.SetActive(true);
            ThankAlert.gameObject.SetActive(false);
            BuyAlert.gameObject.SetActive(false);
        }
    }

    //다이아 구매 시 , 상황별 알림창 띄우는 메소드//
    public void BuyDiamondAlertMethod()
    { 
        BuyAlert.gameObject.SetActive(true);
        CanBuyGoldAndDiamondText.gameObject.SetActive(true);
         CantBuyGoldAndDiamondText.gameObject.SetActive(false);
        DiamondButtonPanel.gameObject.SetActive(true);

    }

    //다이아 구매 시 : 정말로 구매하시겠습니까 창이 떴을때 Yes버튼을 누르면 작동하는 메소드//
    public void BuyDiamond()
    {
        playerDiamondCount += SaveDiamondItemPrice;
        CurrentPlayerDiamondText.text = playerDiamondCount.ToString() + " D";
        DiamondButtonPanel.gameObject.SetActive(false);
        ThankAlert.gameObject.SetActive(true);
    }

    // 다이아몬드 구매 버튼 메소드
    public void SelectDiamondButton0()
    {
        SaveDiamondItemPrice = DiamondPrice[0];
    }
    public void SelectDiamondButton1()
    {
        SaveDiamondItemPrice = DiamondPrice[1];
    }
    public void SelectDiamondButton2()
    {
        SaveDiamondItemPrice = DiamondPrice[2];
    }
    public void SelectDiamondButton3()
    {
        SaveDiamondItemPrice = DiamondPrice[3];
    }
    public void SelectDiamondButton4()
    {
        SaveDiamondItemPrice = DiamondPrice[4];
    }


}
