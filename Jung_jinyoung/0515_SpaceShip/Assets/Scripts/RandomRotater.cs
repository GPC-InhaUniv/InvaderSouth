using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotater : MonoBehaviour {

    public float tumble;
    private void Start()
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
