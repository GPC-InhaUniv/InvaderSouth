using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Enemy : MonoBehaviour
{
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
        bulletObjectPool = GameObject.FindGameObjectWithTag("ObjectPoolManager").GetComponent<BulletObjectPool>();
        enemyObjectPool = GameObject.FindGameObjectWithTag("ObjectPoolManager").GetComponent<EnemyObjectPool>();
    }

    public virtual void EnemyMove()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed);
    }
}
