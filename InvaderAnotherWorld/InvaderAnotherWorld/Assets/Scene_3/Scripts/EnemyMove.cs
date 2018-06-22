
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    private Rigidbody rb;
    [SerializeField]
    private float speed = -10f;

	void Awake ()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
	}
}
