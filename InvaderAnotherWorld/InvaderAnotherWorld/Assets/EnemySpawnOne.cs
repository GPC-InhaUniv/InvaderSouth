using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnOne : MonoBehaviour
{
    private EnemyObjectPool enemyObjectPool;

    private void Start()
    {
        enemyObjectPool = GameObject.Find("GameObjectPool").GetComponent<EnemyObjectPool>();
        StartCoroutine(enemyObjectPool.SetEnemyPlaneOfPositionAndActive(this.transform));
    }
}
