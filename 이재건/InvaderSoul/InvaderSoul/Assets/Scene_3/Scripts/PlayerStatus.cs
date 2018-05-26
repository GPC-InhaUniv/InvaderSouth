using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

    public float PlayerHp;
    public int Money;
    public int Score;
    public float SkillAmount;
    public bool[] Items;
	// Use this for initialization
	void Start () {
        PlayerHp = 1.0f;
        Money = 0;
        Score = 0;
        SkillAmount = 0.0f;

	  	
	}
	public void Damaged(float damage)
    {
        PlayerHp -= damage;
    }
	// Update is called once per frame
	void Update ()
    {
		

	}
}
