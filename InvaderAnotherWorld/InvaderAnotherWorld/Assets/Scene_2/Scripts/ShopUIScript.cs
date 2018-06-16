using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


public class ShopUIScript : MonoBehaviour
{

    [Header("<Shop>")]
    private GameObject shopPanel;
    [SerializeField]
    private List<Toggle> shopToggleList;
    [SerializeField]
    private List<Text> itemPriceText;

    const int NONE = -1;

    //싱글톤으로 연결 부탁드립니다. 값은 테스트를 위해 임시로 넣어놨어요!
    private int playerMoneyCount = NONE;   //계산하기 쉽도록 만든 변수. 아래서 사용하는 동안 형변환을 하지 않기 위해.
    private int playerDiamondCount =NONE;


    private int totalItemPrice;
    private Text showTotalItemPriceText;
    private Text currentPlayerCashText;

    [Header("<Gold>")]
    private Text goldAlert;

    private int maxGold = 9999999;
    [SerializeField]
    private List<Text> goldPriceText;
    [SerializeField]
    private List<int> goldPrice;    //이후에도 골드가격을 편하게 추가/변경할 수 있도록 배열로 생성
    private GameObject buyGoldPanel;
    private Image buyAlert;
    private Text canBuyGoldAndDiamondText;
    private Text cantBuyGoldAndDiamondText;

    public int DiamondPriceForGold; //골드당 다이아몬드 가격 나중에 배열로 바꿔서 각기 정해줄 예정////*********************/

    private int saveGoldItemPrice = 0;   //선택해준 골드를 기억할 수 있도록
    private int saveDiamondItemPrice = 0;   //선택해준 다이아몬드 개수를 기억할 수 있도록
    private Image thankAlert;


    [Header("<Diamond>")]
    private int maxDiamond = 999999;
    [SerializeField]
    private List<Text> diamondPriceText;
    [SerializeField]
    private List<int> diamondPrice; //이후에도 다이아몬드가격을 편하게 추가/변경할 수 있도록 배열로 생성
    private GameObject buyDiamondPanel;
    private Text diamondAlert;
    private GameObject diamondButtonPanel;
    private Text currentPlayerDiamondText;


    private GameObject startButtonWarningPanel;
    private Text warningText;



    void Start()
    {

        shopPanel = GameObject.Find("ShopPanel");
        showTotalItemPriceText = GameObject.Find("ShowTotalItemPriceText").GetComponent<Text>();

        currentPlayerCashText = GameObject.Find("CurrentPlayerCashText").GetComponent<Text>();
        goldAlert = GameObject.Find("GoldAlert").GetComponent<Text>();
        goldAlert.gameObject.SetActive(false);
        buyGoldPanel = GameObject.Find("BuyGoldPanel");
        buyAlert = GameObject.Find("BuyAlert").GetComponent<Image>();
        canBuyGoldAndDiamondText = GameObject.Find("CanBuyGoldAndDiamondText").GetComponent<Text>();
        cantBuyGoldAndDiamondText = GameObject.Find("CantBuyGoldAndDiamondText").GetComponent<Text>();
        thankAlert = GameObject.Find("ThankAlert").GetComponent<Image>();

        buyDiamondPanel = GameObject.Find("BuyDiamondPanel");
        diamondAlert = GameObject.Find("DiamondAlert").GetComponent<Text>();
        diamondButtonPanel = GameObject.Find("DiamondButtonPanel");
        currentPlayerDiamondText = GameObject.Find("CurrentPlayerDiamondText").GetComponent<Text>();

        startButtonWarningPanel = GameObject.Find("StartButtonWarningPanel");
        warningText = GameObject.Find("WarningText").GetComponent<Text>();


        startButtonWarningPanel.SetActive(false);
        diamondButtonPanel.gameObject.SetActive(false);
        diamondAlert.gameObject.SetActive(false);
        buyDiamondPanel.gameObject.SetActive(false);
        thankAlert.gameObject.SetActive(false);
        cantBuyGoldAndDiamondText.gameObject.SetActive(false);
        canBuyGoldAndDiamondText.gameObject.SetActive(false);
        buyAlert.gameObject.SetActive(false);
        buyGoldPanel.gameObject.SetActive(false);
        shopPanel.SetActive(false);

        currentPlayerCashText.text = playerMoneyCount.ToString() + "G";
        currentPlayerDiamondText.text = playerDiamondCount.ToString() + " D";
        ResetToggleOff();
        GetItemPrice();

        //배열로 받아온 골드 가격 텍스트에 골드 가격(마찬가지로 배열)을 넣어줌//
        for (int i = 0; i < goldPrice.Count; i++)
        {
            goldPriceText[i].text = goldPrice[i].ToString();
        }

        //배열로 받아온 다이아몬드 가격 텍스트에 다이아몬드 가격(마찬가지로 배열)을 넣어줌//
        for (int i = 0; i < diamondPrice.Count; i++)
        {
            diamondPriceText[i].text = diamondPrice[i].ToString();
        }




    }

    void ResetToggleOff()
    {
        for (int i = 0; i < shopToggleList.Count; i++)
        {
            shopToggleList[i].isOn = false;
        }
    }

    public void GetItemPrice()
    {
        int itemPrice = 0;

        for (int i = 0; i < shopToggleList.Count; i++)
        {

            if (shopToggleList[i].isOn)
            {
                itemPrice += Convert.ToInt16(itemPriceText[i].text);
                Debug.Log(shopToggleList[i] + "는 토글 켜져있음-ON");
            }
            else
            {
                Debug.Log(shopToggleList[i] + "는 토글 꺼져있음-OFF");
            }

        }
        Debug.Log(itemPrice);
        if (itemPrice == 0)
        {
            showTotalItemPriceText.text = "0";
        }
        else
        {
            totalItemPrice = itemPrice;
            showTotalItemPriceText.text = "-" + totalItemPrice.ToString();
        }
    }

    public void CloseShopBtn()
    {
        shopPanel.SetActive(false);
        buyGoldPanel.SetActive(false);
        buyDiamondPanel.SetActive(false);
        buyAlert.gameObject.SetActive(false);
        startButtonWarningPanel.SetActive(false);
        ResetToggleOff();
    }

    public void BuyItem()
    {
        playerMoneyCount -= totalItemPrice;
        currentPlayerCashText.text = playerMoneyCount.ToString() + "G";
    }

    /// <summary>
    /// 골드 구매
    /// </summary>
    //골드 구매 버튼//
    public void GoldBtn()
    {
        if (playerMoneyCount >= maxGold)
        {
            goldAlert.gameObject.SetActive(true);

        }
        else
        {
            goldAlert.gameObject.SetActive(false);
            buyGoldPanel.gameObject.SetActive(true);
            thankAlert.gameObject.SetActive(false);
            buyAlert.gameObject.SetActive(false);
        }
    }

    //골드 구매 시 , 상황별 알림창 띄우는 메소드//
    public void BuyGoldAlertMethod()
    {
        if (playerDiamondCount >= DiamondPriceForGold)
        {
            buyAlert.gameObject.SetActive(true);
            canBuyGoldAndDiamondText.gameObject.SetActive(true);
            cantBuyGoldAndDiamondText.gameObject.SetActive(false);
        }
        else
        {
            buyAlert.gameObject.SetActive(true);
            cantBuyGoldAndDiamondText.gameObject.SetActive(true);
            canBuyGoldAndDiamondText.gameObject.SetActive(false);
        }
    }

    //골드 구매 시 : 정말로 구매하시겠습니까 창이 떴을때 Yes버튼을 누르면 작동하는 메소드//
    public void BuyGold()
    {
        if (playerDiamondCount >= DiamondPriceForGold)
        {
            DataManager.Instance.BuyMoney(saveGoldItemPrice);
            DataManager.Instance.UseDiaMond(DiamondPriceForGold);
            UpdatePlayerInformation();
            thankAlert.gameObject.SetActive(true);
        }
        else if (playerDiamondCount <= DiamondPriceForGold)
        {
            buyDiamondPanel.gameObject.SetActive(true);
            buyAlert.gameObject.SetActive(false);
            buyGoldPanel.gameObject.SetActive(false);
        }
    }

    // 골드 구매 버튼 메소드
    public void SelectGoldButton0()
    {
        saveGoldItemPrice = goldPrice[0];
    }
    public void SelectGoldButton1()
    {
        saveGoldItemPrice = goldPrice[1];
    }
    public void SelectGoldButton2()
    {
        saveGoldItemPrice = goldPrice[2];
    }
    public void SelectGoldButton3()
    {
        saveGoldItemPrice = goldPrice[3];
    }
    public void SelectGoldButton4()
    {
        saveGoldItemPrice = goldPrice[4];
    }

    /// <summary>
    /// 다이아몬드 구매
    /// </summary>
    //다이아몬드 구매 버튼 눌렀을 시.
    public void DiamondBtn()
    {
        if (playerDiamondCount >= maxDiamond)
        {
            //다이아몬드 알람으로 띄우기
            diamondAlert.gameObject.SetActive(true);
        }
        else
        {
            diamondAlert.gameObject.SetActive(false);
            buyDiamondPanel.gameObject.SetActive(true);
            thankAlert.gameObject.SetActive(false);
            buyAlert.gameObject.SetActive(false);
        }
    }


    //다이아 구매 시 , 상황별 알림창 띄우는 메소드//
    public void BuyDiamondAlertMethod()
    {
        buyAlert.gameObject.SetActive(true);
        canBuyGoldAndDiamondText.gameObject.SetActive(true);
        cantBuyGoldAndDiamondText.gameObject.SetActive(false);
        diamondButtonPanel.gameObject.SetActive(true);

    }

    //다이아 구매 시 : 정말로 구매하시겠습니까 창이 떴을때 Yes버튼을 누르면 작동하는 메소드//
    public void BuyDiamond()
    {
        DataManager.Instance.BuyDiaMond(saveDiamondItemPrice);
        diamondButtonPanel.gameObject.SetActive(false);
        thankAlert.gameObject.SetActive(true);
        UpdatePlayerInformation();
    }

    // 다이아몬드 구매 버튼 메소드
    public void SelectDiamondButton0()
    {
        saveDiamondItemPrice = diamondPrice[0];
    }
    public void SelectDiamondButton1()
    {
        saveDiamondItemPrice = diamondPrice[1];
    }
    public void SelectDiamondButton2()
    {
        saveDiamondItemPrice = diamondPrice[2];
    }
    public void SelectDiamondButton3()
    {
        saveDiamondItemPrice = diamondPrice[3];
    }
    public void SelectDiamondButton4()
    {
        saveDiamondItemPrice = diamondPrice[4];
    }


    public void OnClickStartBtn()   //재건님께 물어보기 //BuyItem메소드 기능 추가하기
    {
        totalItemPrice = Convert.ToInt32(showTotalItemPriceText.text);
        if (totalItemPrice < 0)
            totalItemPrice = totalItemPrice * -1;

        int calculateMoneyBeforeStart = Convert.ToInt32(GameManager.Instance.PlayerMoneyCount) - totalItemPrice;
        if (calculateMoneyBeforeStart < 0)
        {
            Debug.Log("소지 금액 부족");
            warningText.text = "소지금액 " + calculateMoneyBeforeStart.ToString() + " 원이 부족합니다.";
            startButtonWarningPanel.SetActive(true);


        }
        else
        {
            DataManager.Instance.UseMoney(totalItemPrice);
            LoadingSceneController.LoadScene("Main");
        }
    }


    private void Update()
    {
        if (playerMoneyCount == NONE || playerMoneyCount == NONE)
        {
            UpdatePlayerInformation();
        }

    }

    private void UpdatePlayerInformation()
    {
        playerMoneyCount = GameManager.Instance.PlayerMoneyCount;
        playerDiamondCount = GameManager.Instance.PlayerDiamondCount;
        currentPlayerCashText.text = playerMoneyCount.ToString() + " G";
        currentPlayerDiamondText.text = playerDiamondCount.ToString() + "D";
    }

}
