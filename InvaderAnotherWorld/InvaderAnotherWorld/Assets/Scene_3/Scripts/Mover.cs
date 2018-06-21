
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    public Rigidbody rb;
    public float speed = 5f;

	void Awake ()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
	}
}
