using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionCheck : MonoBehaviour
{
    private BulletObjectPool bulletObjectPool;
    private EnemyObjectPool enemyObjectPool;

    private void Awake()
    {
        bulletObjectPool = GameObject.Find("ObjectPool").GetComponent<BulletObjectPool>();
        enemyObjectPool = GameObject.Find("ObjectPool").GetComponent<EnemyObjectPool>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            bulletObjectPool.PlayerBulletsEnqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }

        if (other.tag == "EnemyBullet")
        {
            bulletObjectPool.EnemyBulletsEnqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }

        if(other.tag == "EnemyPlane")
        {
            enemyObjectPool.EnemyPlaneEnqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }

        if(other.tag == "EnemySpacePlane")
        {
            enemyObjectPool.EnemyPlaneSpaceEnqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
