using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    private const int enemyCount = 10;

    public GameObject EnemyPlanePrefab;
    private Queue<GameObject> enemyPlanes;
    private GameObject enemyPlane;

    public GameObject EnemySpacePlanePrefab;
    private Queue<GameObject> enemySpacePlanes;
    private GameObject enemySpacePlane;

    private void Awake()
    {
        enemyPlanes = new Queue<GameObject>();
        enemySpacePlanes = new Queue<GameObject>();

        for(int i = 0; i < enemyCount; i++)
        {
            GameObject EnemyPlaneObj = Instantiate(EnemyPlanePrefab);
            EnemyPlaneObj.SetActive(false);
            enemyPlanes.Enqueue(EnemyPlaneObj);

            GameObject EnemySpacePlaneObj = Instantiate(EnemySpacePlanePrefab);
            EnemySpacePlaneObj.SetActive(false);
            enemySpacePlanes.Enqueue(EnemySpacePlaneObj);
        }
    }

    public IEnumerator SetEnemyPlaneOfPositionAndActive(Transform p)
    {
        while (true)
        {
            if (enemyPlanes.Count > enemyCount)
                yield return null;
            if (enemyPlanes.Count != 0)
            {
                enemyPlane = enemyPlanes.Dequeue();
                enemyPlane.SetActive(true);
                enemyPlane.transform.position = p.position;
            }
            yield return new WaitForSeconds(3f);
        }
    }

    public IEnumerator SetEnemySpacePlaneOfPositionAndActive(Transform p)
    {
        while (true)
        {
            if (enemySpacePlanes.Count > enemyCount)
                yield return null;
            if (enemySpacePlanes.Count != 0)
            {
                enemySpacePlane = enemySpacePlanes.Dequeue();
                enemySpacePlane.SetActive(true);
                enemySpacePlane.transform.position = p.position;
            }
            yield return new WaitForSeconds(3f);
        }
    }

    public void EnemyPlaneEnqueue(GameObject other)
    {
        enemyPlanes.Enqueue(other);
    }

    public void EnemyPlaneSpaceEnqueue(GameObject other)
    {
        enemySpacePlanes.Enqueue(other);
    }
}
