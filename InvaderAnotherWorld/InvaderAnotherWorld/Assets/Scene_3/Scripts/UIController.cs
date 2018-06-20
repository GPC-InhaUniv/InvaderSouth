using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour {

    [SerializeField]
    private Image hpBar;
    [SerializeField]
    private Image skillBar;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text skillAmountText;

    

    private PlayerStatus playerstatusComponent;
    private float previousSkillAmount;

    // Use this for initialization
    void Start()
    {
        playerstatusComponent = GameObject.Find("Player").GetComponent<PlayerStatus>();
        skillBar.fillAmount = playerstatusComponent.SkillAmount;
        previousSkillAmount = 0.0f;

        ReFresh();

    }

 
    public void ChangeStat()
    {
        playerstatusComponent.Damaged();

        playerstatusComponent.SkillAmount +=0.05f;
    }



    public void ReFresh()
    {
        hpBar.fillAmount = playerstatusComponent.PlayerHp/10f;
        if (hpBar.fillAmount >= 0.3f && hpBar.fillAmount <= 0.5f)
            hpBar.color = Color.yellow;
        else if (hpBar.fillAmount < 0.3f)
            hpBar.color = Color.red;
        Debug.Log(hpBar.fillAmount);

    }

    // Update is called once per frame
    void Update () {

        if(previousSkillAmount< playerstatusComponent.SkillAmount 
            &&skillBar.fillAmount<1.0f)
        {
            skillBar.fillAmount += 0.01f;
            previousSkillAmount += 0.01f;
            if(previousSkillAmount>=1.0f ||
                skillBar.fillAmount>=1.0f)
            {
                previousSkillAmount = 1.0f;
                skillBar.fillAmount = 1.0f;
            }

            skillAmountText.text = (Math.Truncate(skillBar.fillAmount * 100)).ToString()+"%";
        }
        scoreText.text = playerstatusComponent.Score.ToString();


    }


}
