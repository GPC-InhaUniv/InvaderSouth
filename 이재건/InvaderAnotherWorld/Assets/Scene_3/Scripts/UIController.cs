using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour {

    [SerializeField]
    Image hpBar;
    [SerializeField]
    Image skillBar;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text skillAmountText;


    public PlayerStatus playerstatus;
    private float PreviousSkillAmount;

    // Use this for initialization
    void Start()
    {
        playerstatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
        skillBar.fillAmount = 0.0f;
        PreviousSkillAmount = 0.0f;

        ReFresh();

    }

 
    public void ChangeStat()
    {
        playerstatus.Damaged(0.1f);

        playerstatus.SkillAmount +=0.05f;
    }



    public void ReFresh()
    {
        hpBar.fillAmount = playerstatus.PlayerHp;
        if (hpBar.fillAmount <= 0.5f && hpBar.fillAmount >= 0.3f)
            hpBar.color = Color.yellow;
        else if (hpBar.fillAmount < 0.3f)
            hpBar.color = Color.red;   

    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeStat();
           
        }

        if(PreviousSkillAmount<playerstatus.SkillAmount&&skillBar.fillAmount<1.0f)
        {
            skillBar.fillAmount += 0.01f;
            PreviousSkillAmount += 0.01f;
            if(PreviousSkillAmount>=1.0f||skillBar.fillAmount>=1.0f)
            {
                PreviousSkillAmount = 1.0f;
                skillBar.fillAmount = 1.0f;
            }

            skillAmountText.text = (Math.Truncate(skillBar.fillAmount * 100)).ToString()+"%";
        }
        scoreText.text = playerstatus.Score.ToString();


    }


}
