using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
    protected float fireRate = 1f;
    protected float nextFire = 0.0f;
    protected Transform enemySpawn;
    protected Transform bulletSpawn;
    protected EnemyObjectPool enemyObjectPool;
    protected MovingDecorator movingDecorator;
    protected BulletObjectPool bulletObjectPool;
    protected float speed = 0.05f;
    public static int Damage = 1;

    private void Awake()
    {
        bulletSpawn = this.transform.Find("BulletSpawn");
        bulletObjectPool = GameObject.Find("ObjectPool").GetComponent<BulletObjectPool>();
        enemyObjectPool = GameObject.Find("ObjectPool").GetComponent<EnemyObjectPool>();
    }

    public virtual void EnemyMove()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed);
    }
}
