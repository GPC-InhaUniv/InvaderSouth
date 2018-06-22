using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectEnemyPlane : Enemy
{
    private void Start()
    {
        life = 1;
        score = 10;
        gauge = 0.05f;
    }

    private void FixedUpdate()
    {
        EnemyMove();
        FireABullet();
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
        if (other.tag == "Bomb")
        {
            life = 1;
            EnemyObjectPool.enemyPlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            life = 1;
            EnemyObjectPool.enemyPlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void CollisionPlayerBullet(Collider other)
    {
        if (other.tag == "PetMissile")
        {
            life -= 0.5f;
            // 유도 미사일 꺼준다.
        }

        if (other.tag == "PlayerBullet")
        {
            life -= 1;
            BulletObjectPool.playerBullets.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }

        if (life <= 0)
        {
            life = 1;
            PlayerInfoDelegater(score, gauge);
            EnemyObjectPool.enemyPlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
