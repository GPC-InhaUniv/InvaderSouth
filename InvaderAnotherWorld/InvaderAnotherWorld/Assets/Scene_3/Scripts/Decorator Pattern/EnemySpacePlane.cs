using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpacePlane : Enemy
{
    private void Start()
    {
        movingDecorator = gameObject.AddComponent<ZigzagMovingDecorator>();
    }

    private void FixedUpdate()
    {
        EnemyMove();
        movingDecorator.EnemyMove();
    }

    private void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            bulletObjectPool.SetEnemyBulletOfPositionAndActive(bulletSpawn);
        }
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
