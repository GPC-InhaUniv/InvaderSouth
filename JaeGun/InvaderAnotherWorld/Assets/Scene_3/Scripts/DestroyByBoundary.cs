using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
     
        if(other.tag=="Bullet")
        {
            BulletPool.EnqeueBullet(other.gameObject);
            other.gameObject.SetActive(false);
        }

        if(other.tag=="BossSmallBullet")
        {
            BossBulletPool.BosssmallBullets.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }
        if(other.tag=="BackGroundElement")
        {
            other.gameObject.SetActive(false);
        }
        
    }
}
