using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnPosition : MonoBehaviour
{
    private BossEnemyPool bossEnemyPool;
    private GameObject bossStats;

    private void Start()
    {
        bossEnemyPool = GameObject.Find("GameObjectPool").GetComponent<BossEnemyPool>();
        bossStats = GameObject.Find("InGameUI").transform.Find("BossStats").gameObject;

        if (GameManager.Instance.CurrentStage == 1)
        {
            StartCoroutine(bossEnemyPool.SetBossOfPosition(this.transform, bossStats));
        }
    }
}
