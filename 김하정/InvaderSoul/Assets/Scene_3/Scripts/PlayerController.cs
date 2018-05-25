using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public BulletPool PlayerBulletPool;
	// Use this for initialization
	void Awake () {
        PlayerBulletPool = GetComponentInChildren<BulletPool>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + 0.2f, 3.6f, transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - 0.2f, 3.6f, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerBulletPool.Fire();
        }

    }
}
