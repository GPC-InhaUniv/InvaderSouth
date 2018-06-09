using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBoy : MonoBehaviour {

    public int Damege;
    public float explosiveTime;
    public GameObject explosion;
    
    void boom()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }
    private void Update()
    {
        explosiveTime -= Time.deltaTime;
        if(explosiveTime <= 0)
        {
            boom();
            Destroy(gameObject);
        }
    }
    //if (other.tag == "Boundary")
    //{
   
    //    return;
    //}

    //if (other.tag == "Player")
    //{
    //    Instantiate(plyerExplosion, other.transform.position, other.transform.rotation);
    //}
    //Instantiate(explosion, transform.position, transform.rotation);
    //Destroy(gameObject);
    //Destroy(other.gameObject);



}
