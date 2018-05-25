
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public Rigidbody rb;
    public float speed = 5f;
	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
