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
        FireABullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        CollisionPlayerBullet(other);

        if (other.tag == "Player")
        {
            life = 1;
            EnemyObjectPool.EnemyPlanes.Enqueue(this.gameObject);
            StageManager.KillEnemy();
            this.gameObject.SetActive(false);
        }
        if (other.tag == "Bomb")
        {
            life = 1;
            StageManager.KillEnemy();
            EnemyObjectPool.EnemyPlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            life = 1;
            StageManager.KillEnemy();
            EnemyObjectPool.EnemyPlanes.Enqueue(this.gameObject);
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
            StageManager.KillEnemy();
            PlayerInfoDelegater(score, gauge);
            EnemyObjectPool.EnemyPlanes.Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
