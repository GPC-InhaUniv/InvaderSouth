using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField]
    Image hpBar;
    [SerializeField]
    Image skillBar;
    [SerializeField]
    Text scoreText;

    public PlayerStatus playerstatus;


    // Use this for initialization
    void Start()
    {
        playerstatus = GameObject.Find("Player").GetComponent<PlayerStatus>();

        ReFresh();

    }
    public void ChangeStat()
    {
        playerstatus.Damaged(0.1f);
        
    }

    public void ReFresh()
    {
        hpBar.fillAmount = playerstatus.PlayerHp;
        if (hpBar.fillAmount <= 0.5f && hpBar.fillAmount >= 0.3f)
            hpBar.color = Color.yellow;
        else if (hpBar.fillAmount < 0.3f)
            hpBar.color = Color.red;

        scoreText.text = playerstatus.Score.ToString();
        skillBar.fillAmount = playerstatus.SkillAmount;
        

    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
            ChangeStat();
	}
}
