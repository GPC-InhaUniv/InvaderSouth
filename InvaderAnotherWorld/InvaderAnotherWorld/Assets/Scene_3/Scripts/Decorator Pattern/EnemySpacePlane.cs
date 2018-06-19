using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpacePlane : Enemy
{
    private void Start()
    {
        enemySpawn = GameObject.Find("EnemySpacePlaneSpawn").transform;
        movingDecorator = gameObject.AddComponent<ZigzagMovingDecorator>();
        StartCoroutine(bulletObjectPool.SetEnemyBulletOfPositionAndActive(bulletSpawn));
    }

    private void FixedUpdate()
    {
        EnemyMove();
        movingDecorator.EnemyMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            bulletObjectPool.PlayerBulletsEnqueue(other.gameObject);
            enemyObjectPool.EnemyPlaneSpaceEnqueue(this.gameObject);
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
