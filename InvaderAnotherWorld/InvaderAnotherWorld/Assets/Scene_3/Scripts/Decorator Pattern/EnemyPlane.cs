using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : Enemy
{
    private void Start()
    {
        life = 1;
        score = 10;
        gauge = 0.05f;
        movingDecorator = gameObject.AddComponent<RotationMovingDecorator>();
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
            life = 1;
            EnemyObjectPool.enemyPlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Player")
        {
            life = 1;
            EnemyObjectPool.enemyPlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void CollisionPlayerBullet(Collider other)
    {
        if (other.tag == "PetMissile")
            life -= 0.5f;
        if (other.tag == "PlayerBullet")
            life -= 1;


        if (life <= 0)
        {
            life = 1;
            PlayerInfoDelegater(score, gauge);
            EnemyObjectPool.enemyPlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
