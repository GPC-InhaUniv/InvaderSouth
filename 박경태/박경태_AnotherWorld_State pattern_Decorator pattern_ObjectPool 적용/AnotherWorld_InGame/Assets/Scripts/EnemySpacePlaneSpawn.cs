using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpacePlaneSpawn : MonoBehaviour
{
    private EnemyObjectPool enemyObjectPool;

    private void Awake()
    {
        enemyObjectPool = GameObject.Find("ObjectPool").GetComponent<EnemyObjectPool>();
    }

    private void Start()
    {
        StartCoroutine(enemyObjectPool.SetEnemySpacePlaneOfPositionAndActive(this.transform));
    }
}
