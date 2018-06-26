using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
    protected int score;
    protected float life;
    protected float gauge;
    protected float speed = 0.12f;
    protected float fireRate = 2f;
    protected float nextFire = 0.0f;
    protected Transform bulletSpawn;
    protected EnemyObjectPool enemyObjectPool;
    protected MovingDecorator movingDecorator;
    protected BulletObjectPool bulletObjectPool;
    protected PlayerStatus playerStatus;
    public delegate void PlayerInfo(int score, float gauge);
    public PlayerInfo PlayerInfoDelegater;

    private void Awake()
    {
        bulletSpawn = this.transform.Find("BulletSpawn");
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
        bulletObjectPool = GameObject.FindGameObjectWithTag("ObjectPoolManager").GetComponent<BulletObjectPool>();
        enemyObjectPool = GameObject.FindGameObjectWithTag("ObjectPoolManager").GetComponent<EnemyObjectPool>();
        PlayerInfoDelegater += playerStatus.SetScoreSkill;
    }

    protected void FireABullet()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            bulletObjectPool.SetEnemyBulletOfPositionAndActive(bulletSpawn);
        }
    }

    public virtual void EnemyMove()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed);
    }
}
