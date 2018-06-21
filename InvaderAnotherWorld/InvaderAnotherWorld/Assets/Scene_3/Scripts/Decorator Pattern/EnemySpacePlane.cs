using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpacePlane : Enemy
{

    private void Start()
    {
        life = 2;
        score = 20;
        gauge = 0.07f;
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
        CollisionPlayerBullet(other);

        if (other.tag == "Player")
        {
            life = 2;
            EnemyObjectPool.enemySpacePlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            life = 2;
            EnemyObjectPool.enemySpacePlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void CollisionPlayerBullet(Collider other)
    {
        if (other.tag == "PlayerBullet")
            life -= 1;
        else if (other.tag == "PetMissile")
            life -= 0.5f;
      

        if (life <= 0)
        {
            life = 2;
            PlayerInfoDelegater(score, gauge);
            EnemyObjectPool.enemySpacePlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
