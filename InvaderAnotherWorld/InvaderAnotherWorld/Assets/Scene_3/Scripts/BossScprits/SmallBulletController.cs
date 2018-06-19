using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBulletController : MonoBehaviour {
    private Rigidbody rigidbody;
    private float speed;
	// Use this for initialization
	void Start () {

        rigidbody = GetComponent<Rigidbody>();
        speed = 10.0f;
    }

    // Update is called once per frame
    void Update () {
        rigidbody.transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
    }
}
