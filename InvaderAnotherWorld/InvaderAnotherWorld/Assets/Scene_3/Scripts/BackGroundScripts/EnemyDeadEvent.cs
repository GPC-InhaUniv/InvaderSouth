using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadEvent : MonoBehaviour {

    private PlayerStatus playerstatusComponent;

	// Use this for initialization
	void Start () {
        playerstatusComponent = GameObject.Find("Player").GetComponent<PlayerStatus>();
	}
}
