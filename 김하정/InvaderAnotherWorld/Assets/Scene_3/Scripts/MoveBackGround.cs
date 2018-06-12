﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGround : MonoBehaviour {
    public Rigidbody rb;
    public float speed = 5f;
    public GameObject anotherBackGround;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = -transform.up* speed;
        
    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position.z<=-26.5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, anotherBackGround.transform.position.z + 30f);            
        }
	}
}
