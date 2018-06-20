using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpacePlane : Enemy
{
    public PlayerInfo PlayerInfoDelegater;

    private void Start()
    {
        life = 2;
        damage = 1;
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
        if (other.tag == "PlayerBullet")
        {
            life -= 1;
            
            if(life <= 0)
            {
                life = 2;
                enemyObjectPool.EnemyPlaneSpaceEnqueue(this.gameObject);
                PlayerInfoDelegater(score, gauge);
            }
        }
    }
}
