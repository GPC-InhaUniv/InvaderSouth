using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
     
        if(other.tag=="PlayerBullet")
        {
            BulletObjectPool.playerBullets.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }

        if (other.tag == "EnemyBullet")
        {
            BulletObjectPool.enemyBullets.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }

        if (other.tag == "BossSmallBullet")
        {
            BossEnemyPool.BosssmallBullets.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }
        if(other.tag == "BackGroundElement")
        {
            other.gameObject.SetActive(false);
        }
    }
}
