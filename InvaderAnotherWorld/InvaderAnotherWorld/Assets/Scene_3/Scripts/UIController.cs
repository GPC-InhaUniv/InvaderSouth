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
        skillBar.fillAmount = playerstatusComponent.SkillAmount/2;
        skillAmountText.text = (playerstatusComponent.SkillAmount*100).ToString() + "%";
        previousSkillAmount = 0.0f;

        ReFresh();
    }


    public void ReFresh()
    {
        hpBar.fillAmount = playerstatusComponent.PlayerHp/10f;

        if (hpBar.fillAmount >= 0.3f && hpBar.fillAmount <= 0.5f)
            hpBar.color = Color.yellow;
        else if (hpBar.fillAmount < 0.3f)
            hpBar.color = Color.red;


        if (playerstatusComponent.SkillAmount == 0)
        {
            skillBar.fillAmount = 0;
            skillAmountText.text = "0%";
            previousSkillAmount = 0.0f;
        }
        else if (previousSkillAmount < playerstatusComponent.SkillAmount/2
           && skillBar.fillAmount < 0.5f)
        {
            skillBar.fillAmount += 0.005f;
            previousSkillAmount += 0.005f;
            if (previousSkillAmount >= 0.5f ||
                skillBar.fillAmount >= 0.5f)
            {
                previousSkillAmount = 0.5f;
                skillBar.fillAmount = 0.5f;
            }

            skillAmountText.text = (Math.Truncate(skillBar.fillAmount*2 * 100)).ToString() + "%";
        }

        scoreText.text = playerstatusComponent.Score.ToString();

    }

    // Update is called once per frame
    void Update ()
    {

        ReFresh();
    }


}
