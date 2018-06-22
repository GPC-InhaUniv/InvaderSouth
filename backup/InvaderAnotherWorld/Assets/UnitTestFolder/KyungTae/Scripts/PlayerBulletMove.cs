using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    private float Speed = 10;

    public void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * Speed;
    }
}
