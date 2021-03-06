﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// 질문 : 경태님께 오브젝트 불러와지는지 물어보기 =>한단계 아래밖에 불러와지지 않음.
/// 질문2 : 오브젝트 false/true나눠서 메소드 만들어야하는지 물어보기 => 묶어서 따로 만들기.
/// 작업2 : 형변환 생각해보기
/// 작업3 : false랑 true랑 묶기... -> //메소드에 다른 애들도 묶여있는데... 이거 하나를 끄기위해 메소드를 사용하는게 옳은걸까?
/// DataManager는 왜 null reference exception이 나는거지.
/// </summary>
public class ShopUIScript_Test : MonoBehaviour
{
    [Header("<Shop>")]
    private GameObject shopPanel;
    private int itemCount = 3;
    private int goldItemCount = 10;
    private int diamondItemCount = 10;
    //싱글톤으로 연결 부탁드립니다. 값은 테스트를 위해 임시로 넣어놨어요!
    private int playerMoneyCount = 5000;   //계산하기 쉽도록 만든 변수. 아래서 사용하는 동안 형변환을 하지 않기 위해.
    private int playerDiamondCount = 20;

    private int totalItemPrice;
    private Text showTotalItemPriceText;
    private Text currentPlayerMoneyText;

    [Header("<Gold>")]
    private Text goldAlert;

    private int maxGold = 999999;
    private GameObject buyGoldPanel;
    private Image buyAlert;
    private Text canBuyGoldAndDiamondText;
    private Text cantBuyGoldAndDiamondText;

    public int DiamondPriceForGold; //골드당 다이아몬드 가격 나중에 배열로 바꿔서 각기 정해줄 예정////
    private int saveGoldItemPrice = 0;   //선택해준 골드를 기억할 수 있도록
    private int saveDiamondItemPrice = 0;   //선택해준 다이아몬드 개수를 기억할 수 있도록
    private Image thankAlert;


    [Header("<Diamond>")]
    private int maxDiamond = 999999;
    private GameObject buyDiamondPanel;
    private Text diamondAlert;
    //private GameObject diamondButtonPanel;
    private Text currentPlayerDiamondText;

    private GameObject startButtonWarningPanel;
    private Text warningText;



    void Start()
    {
        SetBuyGoldUIPanel();
        SetBuyDiamondUIPanel();
        SetShopUIPanel();

        SetDiamondUIOff();
        SetGoldUIOff();
        SetShopUIOff();
        SetAlertMessageOff();

        currentPlayerMoneyText.text = playerMoneyCount.ToString() + "G";
        currentPlayerDiamondText.text = playerDiamondCount.ToString() + " D";
        SetAllToggleOff();
        OnClickedItemButton();
        CheckedListCount();    //유니티 플레이 중에는 수정이 불가하기 때문에 start에만 넣어준다.

        //배열로 받아온 골드 가격 텍스트에 골드 가격(마찬가지로 배열)을 넣어줌//
        for (int i = 0; i < goldinfo.Count; i++)
        {
            goldinfo[i].GoldPriceText.text = goldinfo[i].GoldPrice.ToString();
        }

        //배열로 받아온 다이아몬드 가격 텍스트에 다이아몬드 가격(마찬가지로 배열)을 넣어줌//
        for (int i = 0; i < diamondinfo.Count; i++)
        {
            diamondinfo[i].DiamondPriceText.text = diamondinfo[i].DiamondPrice.ToString();
        }

    }

    private void SetBuyGoldUIPanel()
    {
        buyGoldPanel = GameObject.Find("BuyGoldPanel");
        goldAlert = GameObject.Find("GoldAlert").GetComponent<Text>();
    }

    private void SetBuyDiamondUIPanel()
    {
        buyDiamondPanel = GameObject.Find("BuyDiamondPanel");
        diamondAlert = GameObject.Find("DiamondAlert").GetComponent<Text>();
       
    }

    private void SetShopUIPanel()
    {
        shopPanel = GameObject.Find("LobbyUICanvas").transform.Find("ShopPanel").gameObject;
        startButtonWarningPanel = shopPanel.transform.Find("StartButtonWarningPanel").gameObject;

        warningText = GameObject.Find("WarningText").GetComponent<Text>();
        showTotalItemPriceText = GameObject.Find("ShowTotalItemPriceText").GetComponent<Text>();    //위에 있는걸 불러오는게 아니라 얘 하나만 필요해서 그냥 사용
        currentPlayerMoneyText = GameObject.Find("CurrentPlayerCashText").GetComponent<Text>();  //위에 있는걸 불러오는게 아니라 얘 하나만 필요해서 그냥 사용
        currentPlayerDiamondText = GameObject.Find("CurrentPlayerDiamondText").GetComponent<Text>(); //위에 있는걸 불러오는게 아니라 얘 하나만 필요해서 그냥 사용

        buyAlert = GameObject.Find("BuyAlert").GetComponent<Image>();
        thankAlert = buyAlert.transform.Find("ThankAlert").GetComponent<Image>();
        canBuyGoldAndDiamondText = buyAlert.transform.Find("CanBuyGoldAndDiamondText").GetComponent<Text>();
        cantBuyGoldAndDiamondText = buyAlert.transform.Find("CantBuyGoldAndDiamondText").GetComponent<Text>();

       
    }

    private void SetShopUIOff()
    {
        startButtonWarningPanel.SetActive(false);
        thankAlert.gameObject.SetActive(false);
        cantBuyGoldAndDiamondText.gameObject.SetActive(false);
        canBuyGoldAndDiamondText.gameObject.SetActive(false);
        buyAlert.gameObject.SetActive(false);
        buyGoldPanel.gameObject.SetActive(false);
        shopPanel.SetActive(false);
    }

    private void SetGoldUIOff()
    {
        buyGoldPanel.gameObject.SetActive(false);
    }

    private void SetDiamondUIOff()
    {
        buyDiamondPanel.gameObject.SetActive(false);
    }
    private void SetDiamondUIOn()
    {
        buyDiamondPanel.gameObject.SetActive(true);
    }

    private void SetAlertMessageOff()
    {
        thankAlert.gameObject.SetActive(false);
        buyAlert.gameObject.SetActive(false);
        goldAlert.gameObject.SetActive(false);
        diamondAlert.gameObject.SetActive(false);
    }

    private void CheckedListCount()
    {
        if (itemInfo.Count > itemCount)
        {
            Debug.Log("<color=red>아이템 개수를 초과하였습니다. 작업자님 인스펙터 창을 다시 확인해주세요...ㅠㅠ</color>");
        }

        if (goldinfo.Count > goldItemCount)
        {
            Debug.Log("<color=red>골드 아이템 개수를 초과하였습니다. 작업자님 인스펙터 창을 다시 확인해 주세요..8_8</color>");
        }

       if (diamondinfo.Count > diamondItemCount)
        {
            Debug.Log("<color=red>다이아 아이템 개수를 초과하였습니다. 작업자님 인스펙터 창을 다시 확인해 주세요ㅠ0ㅠ</color>");
        }
    }


    [Serializable]
    private struct Item
    {
        public Toggle ItemToggle;   //shopToggleList
        public Text ItempriceText;
    }
    [SerializeField]
    private List<Item> itemInfo;


    [Serializable]
    private struct GoldPriceInfo
    {
        public Text GoldPriceText;
        public int GoldPrice;
    }
    [SerializeField]
    private List<GoldPriceInfo> goldinfo;


    [Serializable]
    private struct DiamondPriceInfo
    {
        public Text DiamondPriceText;
        public int DiamondPrice;
    }
    [SerializeField]
    private List<DiamondPriceInfo> diamondinfo;





    void SetAllToggleOff()
    {
        for (int i = 0; i < itemInfo.Count; i++)
        {
            itemInfo[i].ItemToggle.isOn = false;
        }
    }

    public void OnClickedItemButton()
    {
        int itemPrice = 0;

        for (int i = 0; i < itemInfo.Count; i++)
        {

            if   (itemInfo[i].ItemToggle.isOn)
            {
                int number;
                if (int.TryParse(itemInfo[i].ItempriceText.text, out number))
                {
                    itemPrice += number;
                }
                else
                {
                    Debug.Log("스트링 값이 들어오지 않음");
                }

                Debug.Log(itemInfo[i].ItemToggle + "는 토글 켜져있음-ON");
            }
            else
            {
                Debug.Log(itemInfo[i].ItemToggle + "는 토글 꺼져있음-OFF");
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

   
    public void OnClickedCloseShopButton()
    {
        SetDiamondUIOff();
        SetGoldUIOff();
        SetShopUIOff();
        SetAllToggleOff();
    }

    
    /// <summary>
    /// 골드 구매
    /// </summary>
    //골드 구매 버튼//
    public void OnClickedGoldButton()
    {
        if (playerMoneyCount >= maxGold)
        {
            goldAlert.gameObject.SetActive(true);
        }
        else
        {
            SetGoldUIOff();
            buyGoldPanel.gameObject.SetActive(true);
            thankAlert.gameObject.SetActive(false);
            buyAlert.gameObject.SetActive(false);

        }
    }

    //골드 구매 시 , 상황별 알림창 띄우는 메소드//
    public void OnClickedBuyGoldAlertMethod()
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
            canBuyGoldAndDiamondText.gameObject.SetActive(false);
            cantBuyGoldAndDiamondText.gameObject.SetActive(true);
        }
    }

    //골드 구매 시 : 정말로 구매하시겠습니까 창이 떴을때 Yes버튼을 누르면 작동하는 메소드//
    public void OnClickedBuyGold()
    {
        if (playerDiamondCount >= DiamondPriceForGold)
        {
            DataManager.Instance.BuyMoney(saveGoldItemPrice);
            DataManager.Instance.UseDiaMond(DiamondPriceForGold);
            currentPlayerMoneyText.text = GameManager.Instance.PlayerMoneyCount.ToString();
            currentPlayerDiamondText.text = GameManager.Instance.PlayerDiamondCount.ToString();
            thankAlert.gameObject.SetActive(true);
        }
        else if (playerDiamondCount <= DiamondPriceForGold)
        {
            SetDiamondUIOn();
            buyAlert.gameObject.SetActive(false);   //메소드에 다른 애들도 묶여있는데... 이거 하나를 끄기위해 메소드를 사용하는게 옳은걸까?
            buyGoldPanel.gameObject.SetActive(false);
        }
    }
   
    // 골드 아이템 버튼 메소드
    public void OnClickedSelectGoldItemButton(int clicked)
    {
         saveGoldItemPrice = goldinfo[clicked].GoldPrice;
    }

    
    /// <summary>
    /// 다이아몬드 구매
    /// </summary>
    //다이아몬드 구매 버튼 눌렀을 시.
    public void OnClickedDiamondButton()
    {
        if (playerDiamondCount >= maxDiamond)
        {
            //다이아몬드 알람으로 띄우기
            diamondAlert.gameObject.SetActive(true);
        }
        else
        {
            SetDiamondUIOn();
            SetAlertMessageOff();
        }
    }

    //다이아 구매 시 , 알림창 띄우는 메소드//
    public void OnClickedBuyDiamondAlertMethod()
    {
        buyAlert.gameObject.SetActive(true);
        canBuyGoldAndDiamondText.gameObject.SetActive(true);
    }

    //다이아 구매 시 : 정말로 구매하시겠습니까 창이 떴을때 Yes버튼을 누르면 작동하는 메소드//
    public void OnClickedBuyDiamond()
    {
        DataManager.Instance.BuyDiaMond(saveDiamondItemPrice);
        currentPlayerDiamondText.text = GameManager.Instance.PlayerDiamondCount.ToString();
        thankAlert.gameObject.SetActive(true);
    }

     
    // 다이아몬드 구매 버튼 메소드
    public void OnClickedSelectDiamondItemButton(int clicked)
    {
        saveDiamondItemPrice = diamondinfo[clicked].DiamondPrice;
    }






    /*******************************************************************************************************/
    public void BuyItem() //재건님 메소드로 넘어감 얘는 필요 없음//
    {
        playerMoneyCount -= totalItemPrice;
        currentPlayerMoneyText.text = playerMoneyCount.ToString() + "G";
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
        //playerMoneyCount =GameManager.Instance.PlayerMoneyCount;
        //playerDiamondCount = GameManager.Instance.PlayerDiamondCount ;
        //currentPlayerCashText.text = playerMoneyCount.ToString() + " G";
        //currentPlayerDiamondText.text = playerDiamondCount.ToString() + "D";

    }

}
