using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed;
    public void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * Speed;
    }
}
