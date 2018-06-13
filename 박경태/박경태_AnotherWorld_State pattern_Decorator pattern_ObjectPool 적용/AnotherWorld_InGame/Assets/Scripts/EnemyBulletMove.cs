using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    private float Speed = -10;

    public void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * Speed;
    }
}
