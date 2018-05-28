using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
     
        if(other.tag=="Bullet")
        {
            BulletPool.bullets.Enqueue(other.gameObject);
        }
        other.gameObject.SetActive(false);
    }
}
