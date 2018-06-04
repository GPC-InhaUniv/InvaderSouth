using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadEvent : MonoBehaviour {

    public PlayerStatus playerStatus;

	// Use this for initialization
	void Start () {
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Bullet")
        {
            playerStatus.GetScoreSkill();
            Destroy(other.gameObject);
            Destroy(gameObject);
          
        }
    }
}
