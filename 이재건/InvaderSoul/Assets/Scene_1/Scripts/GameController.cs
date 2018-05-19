using UnityEngine;

public class GameController : Singleton<GameController>
{
    public string PlayerName;
    public int TotalAmount;
    public int CarryingAmount;
    public int Damage;
    //public bool[] StageClear = new bool[3];
    public int Life;
    
    private void Start()
    {
        TotalAmount = 0;
        CarryingAmount = 5000;
        Damage = 5;
        Life = 3;
    }

    // 상점용
    public void DamageUpAndDown(bool itemClick)
    {
        if (itemClick)
        {
            Damage += 1;
            TotalAmount += 500;
            Debug.Log("데미지 증가 : " + Damage);
            Debug.Log("아이템 토탈 금액 : " + TotalAmount);
        }
        else
        {
            Damage -= 1;
            TotalAmount -= 500;
            Debug.Log("데미지 감소 : " + Damage);
            Debug.Log("아이템 토탈 금액 : " + TotalAmount);
        }
    }

    public void LifeUpAndDown(bool itemClick)
    {
        if (itemClick)
        {
            Life += 1;
            TotalAmount += 500;
            Debug.Log("Life 증가 : " + Life);
            Debug.Log("아이템 토탈 금액 : " + TotalAmount);
        }

        else
        {
            Life -= 1;
            TotalAmount -= 500;
            Debug.Log("Life 감소 : " + Life);
            Debug.Log("아이템 토탈 금액 : " + TotalAmount);
        }
    }
}