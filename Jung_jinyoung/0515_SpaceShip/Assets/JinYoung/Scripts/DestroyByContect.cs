using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContect : MonoBehaviour {
    public GameObject explosion;
    public GameObject plyerExplosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        
        if(other.tag == "Player")
        {
            Instantiate(plyerExplosion, other.transform.position, other.transform.rotation);
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        if(other.tag != "Bomb") Destroy(other.gameObject);
    }
}
