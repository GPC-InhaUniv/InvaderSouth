using UnityEngine;

public class EnemySpawnStagePattern : MonoBehaviour
{
    private EnemyObjectPool enemyObjectPool;

    private void Start()
    {
        enemyObjectPool = GameObject.Find("GameObjectPool").GetComponent<EnemyObjectPool>();

        if (GameManager.Instance.CurrentStage == 0)
        {
            StartCoroutine(enemyObjectPool.StageOneEnemyPlaneAndDirectPlaneOfPosition(this.transform));
            StartCoroutine(enemyObjectPool.StageOneEnemyEnemySpacePlnaeOfPosition(this.transform));

        }

        if (GameManager.Instance.CurrentStage == 1)
        {
            StartCoroutine(enemyObjectPool.StageOneEnemyPlaneAndDirectPlaneOfPosition(this.transform));
            StartCoroutine(enemyObjectPool.StageTwoEnemySpacePlnaeOfPosition(this.transform));
            StartCoroutine(enemyObjectPool.StageTwoSparkBomOfPosition(this.transform));
        }
    }
}
