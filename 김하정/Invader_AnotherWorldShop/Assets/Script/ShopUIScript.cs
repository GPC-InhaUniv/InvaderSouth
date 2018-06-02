using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ShopUIScript : MonoBehaviour 
{

    public GameObject ShopPanel;
  
     
    public GameObject ItemInfoPanel;

    public List<Toggle> ShopToggleList;

    public List<Text> ItemPrice;


    // Use this for initialization
    void Start()
    {
        ResetToggleOff();

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
        for (int i = 0; i < ShopToggleList.Count; i++)
        {
            if (ShopToggleList[i].isOn)
            {
                Debug.Log(ShopToggleList[i]+"는 토글 켜졌음");
            }
            else 
            {
                Debug.Log(ShopToggleList[i] + "는 토글 꺼져있음");
            }
        }
    }


    public void CloseShopBtn()
    {
        ShopPanel.SetActive(false);
    }

    public void Show()
    {
        
        ItemInfoPanel.SetActive(true);
        
    }

    public void Hide()
    {
         
        ItemInfoPanel.SetActive(false);
    }

    

    // Update is called once per frame
    void Update()
    {
       
    }
}
