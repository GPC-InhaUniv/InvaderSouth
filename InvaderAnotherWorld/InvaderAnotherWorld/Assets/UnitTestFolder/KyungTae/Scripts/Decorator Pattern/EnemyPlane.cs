using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : Enemy
{
    private void Start()
    {
        enemySpawn = GameObject.Find("EnemyPlaneSpawn").transform;
        movingDecorator = gameObject.AddComponent<RotationMovingDecorator>();
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
            enemyObjectPool.EnemyPlaneEnqueue(this.gameObject);
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
