﻿using UnityEngine;

public class EnemySpacePlane : Enemy
{

    private void Start()
    {
        life = 2;
        score = 20;
        gauge = 0.07f;
        movingDecorator = gameObject.AddComponent<ZigzagMovingDecorator>();
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        EnemyMove();
        movingDecorator.EnemyMove();
    }

    private void Update()
    {
        FireABullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        CollisionPlayerBullet(other);

        if (other.tag == "Player")
        {
            life = 2;
            StageManager.KillEnemy();
            EnemyObjectPool.EnemySpacePlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
        if (other.tag == "Bomb")
        {
            life = 2;
            StageManager.KillEnemy();
            EnemyObjectPool.EnemySpacePlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            life = 2;

            StageManager.KillEnemy();
            EnemyObjectPool.EnemySpacePlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void CollisionPlayerBullet(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            life -= 1;
            BulletObjectPool.playerBullets.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }

        else if (other.tag == "PetMissile")
        {
            life -= 0.5f;

        }

        if (life <= 0)
        {
            life = 2;
            StageManager.KillEnemy();
            PlayerInfoDelegater(score, gauge);
            EnemyObjectPool.EnemySpacePlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
