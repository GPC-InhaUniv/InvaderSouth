using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// 질문 : 경태님께 오브젝트 불러와지는지 물어보기 =>한단계 아래밖에 불러와지지 않음.
/// 질문2 : 오브젝트 false/true나눠서 메소드 만들어야하는지 물어보기 => 묶어서 따로 만들기.
/// 작업1 : 리스트 일정 개수 이상 늘어나면 경고창 띄우기
/// 작업2 : 형변환 생각해보기
/// 작업3 : 오브젝트 불러오기
/// 작업4 : 
/// </summary>
public class ShopUIScript_Test : MonoBehaviour
{
    [Header("<Shop>")]
    private GameObject shopPanel;
    //[SerializeField]
    //private List<Toggle> shopToggleList;
    private int itemCount = 3;
    //[SerializeField]
    //private List<Text> itemPriceText;

    //싱글톤으로 연결 부탁드립니다. 값은 테스트를 위해 임시로 넣어놨어요!
    private int playerMoneyCount = 5000;   //계산하기 쉽도록 만든 변수. 아래서 사용하는 동안 형변환을 하지 않기 위해.
    private int playerDiamondCount = 20;


    private int totalItemPrice;
    private Text showTotalItemPriceText;
    private Text currentPlayerCashText;

    [Header("<Gold>")]
    private Text goldAlert;

    private int maxGold = 9999999;
    //[SerializeField]
    //private List<Text> goldPriceText;
    //[SerializeField]
   /* private List<int> goldPrice;  */  //이후에도 골드가격을 편하게 추가/변경할 수 있도록 배열로 생성
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
    //[SerializeField]
    //private List<Text> diamondPriceText;
    //[SerializeField]
    /*private List<int> diamondPrice;*/ //이후에도 다이아몬드가격을 편하게 추가/변경할 수 있도록 배열로 생성
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

        //goldAlert.gameObject.SetActive(false);
        //startButtonWarningPanel.SetActive(false);
        ////////diamondButtonPanel.gameObject.SetActive(false);
        //diamondAlert.gameObject.SetActive(false);
        //buyDiamondPanel.gameObject.SetActive(false);
        //thankAlert.gameObject.SetActive(false);
        //cantBuyGoldAndDiamondText.gameObject.SetActive(false);
        //canBuyGoldAndDiamondText.gameObject.SetActive(false);
        //buyAlert.gameObject.SetActive(false);
        //buyGoldPanel.gameObject.SetActive(false);
        //shopPanel.SetActive(false);

        currentPlayerCashText.text = playerMoneyCount.ToString() + "G";
        currentPlayerDiamondText.text = playerDiamondCount.ToString() + " D";
        SetAllToggleOff();
        OnClickedItemButton();

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

    private void ListAlert()
    {
        if (itemInfo.Count > itemCount)
        {
            Debug.Log("아이템 개수를 초과하였습니다. 작업자여 인스펙터 창을 다시 보시길....ㅠㅠ");
        }
    }



    private void SetBuyGoldUIPanel()
    {
        buyGoldPanel = GameObject.Find("BuyGoldPanel");
        goldAlert = GameObject.Find("GoldAlert").GetComponent<Text>();
        
    }

    private void SetBuyDiamondUIPanel()
    {
        //diamondButtonPanel = GameObject.Find("DiamondButtonPanel");
        buyDiamondPanel = GameObject.Find("BuyDiamondPanel");
        diamondAlert = GameObject.Find("DiamondAlert").GetComponent<Text>();

    }

    private void SetShopUIPanel()
    {
        shopPanel = GameObject.Find("LobbyUICanvas").transform.Find("ShopPanel").gameObject;


        showTotalItemPriceText = GameObject.Find("ShowTotalItemPriceText").GetComponent<Text>();    //위에 있는걸 불러오는게 아니라 얘 하나만 필요해서 그냥 사용
        currentPlayerCashText = GameObject.Find("CurrentPlayerCashText").GetComponent<Text>();
        currentPlayerDiamondText = GameObject.Find("CurrentPlayerDiamondText").GetComponent<Text>();
        //buyAlert = GameObject.Find("BuyAlert").GetComponent<Image>();


        thankAlert = GameObject.Find("ThankAlert").GetComponent<Image>();
        canBuyGoldAndDiamondText = GameObject.Find("CanBuyGoldAndDiamondText").GetComponent<Text>();
        cantBuyGoldAndDiamondText = GameObject.Find("CantBuyGoldAndDiamondText").GetComponent<Text>();


        startButtonWarningPanel = GameObject.Find("StartButtonWarningPanel");
        warningText = GameObject.Find("WarningText").GetComponent<Text>();

         


        buyAlert = shopPanel.transform.Find("BuyAlert").GetComponent<Image>();

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
                itemPrice += Convert.ToInt16(itemInfo[i].ItempriceText.text);   //형변환 다시 생각해보기
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

    //false/true 메소드 제작후 나눠서 사용하기
    public void OnClickedCloseShopButton()
    {
        shopPanel.SetActive(false);
        buyGoldPanel.SetActive(false);
        buyDiamondPanel.SetActive(false);
        buyAlert.gameObject.SetActive(false);
        startButtonWarningPanel.SetActive(false);
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
            goldAlert.gameObject.SetActive(false);
            buyGoldPanel.gameObject.SetActive(true);
            thankAlert.gameObject.SetActive(false);
            buyAlert.gameObject.SetActive(false);
        }
    }

    //골드 구매 시 , 상황별 알림창 띄우는 메소드//
    private void BuyGoldAlertMethod()
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
    public void OnClickedBuyGold()
    {
        if (playerDiamondCount >= DiamondPriceForGold)
        {
            DataManager.Instance.BuyMoney(saveGoldItemPrice);
            DataManager.Instance.UseDiaMond(DiamondPriceForGold);
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
            diamondAlert.gameObject.SetActive(false);
            buyDiamondPanel.gameObject.SetActive(true);
            thankAlert.gameObject.SetActive(false);
            buyAlert.gameObject.SetActive(false);
        }
    }

    //다이아 구매 시 , 상황별 알림창 띄우는 메소드//
    private void BuyDiamondAlertMethod()
    {
        buyAlert.gameObject.SetActive(true);
        canBuyGoldAndDiamondText.gameObject.SetActive(true);
        cantBuyGoldAndDiamondText.gameObject.SetActive(false);
        //diamondButtonPanel.gameObject.SetActive(true);

    }

    //다이아 구매 시 : 정말로 구매하시겠습니까 창이 떴을때 Yes버튼을 누르면 작동하는 메소드//
    public void OnClickedBuyDiamond()
    {
        DataManager.Instance.BuyDiaMond(saveDiamondItemPrice);
        //diamondButtonPanel.gameObject.SetActive(false);
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
        currentPlayerCashText.text = playerMoneyCount.ToString() + "G";
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
        //playerMoneyCount = int.Parse(GameManager.Instance.PlayerMoneyCount);
        //playerDiamondCount = int.Parse(GameManager.Instance.PlayerDiamondCount);
        //currentPlayerCashText.text = playerMoneyCount.ToString() + " G";
        //currentPlayerDiamondText.text = playerDiamondCount.ToString() + "D";

    }

}
