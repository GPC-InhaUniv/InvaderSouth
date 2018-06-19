using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    private float Speed = 10;

    public void Start()
    {
        if (gameObject.transform.position.z <= 8)
            GetComponent<Rigidbody>().velocity = Vector3.forward * Speed;
    }
}
