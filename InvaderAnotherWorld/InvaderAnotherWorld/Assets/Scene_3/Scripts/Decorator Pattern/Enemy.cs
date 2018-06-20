using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
    protected float speed = 0.05f;
    protected float fireRate = 1f;
    protected float nextFire = 0.0f;
    protected Transform bulletSpawn;
    protected EnemyObjectPool enemyObjectPool;
    protected MovingDecorator movingDecorator;
    protected BulletObjectPool bulletObjectPool;

    private void Awake()
    {
        bulletSpawn = this.transform.Find("BulletSpawn");
        bulletObjectPool = GameObject.FindGameObjectWithTag("ObjectPoolManager").GetComponent<BulletObjectPool>();
        enemyObjectPool = GameObject.FindGameObjectWithTag("ObjectPoolManager").GetComponent<EnemyObjectPool>();
    }

    public virtual void EnemyMove()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed);
    }
}
