using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public int PlayerHp;
    public int Money;
    public int Score;
    public int SkillAmount;
    public bool[] Items;
	// Use this for initialization
	void Start () {
        PlayerHp = 100;
        Money = 0;
        Score = 0;
        SkillAmount = 0;

	  	
	}
	
	// Update is called once per frame
	void Update ()
    {
		

	}
}
