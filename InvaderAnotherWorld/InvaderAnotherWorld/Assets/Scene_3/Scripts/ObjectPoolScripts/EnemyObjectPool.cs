using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    private float time;
    private const int enemyCount = 20;

    [SerializeField]
    private GameObject EnemyPlanePrefab;
    private Queue<GameObject> enemyPlanes;
    private GameObject enemyPlane;


    [SerializeField]
    private GameObject EnemySpacePlanePrefab;
    private Queue<GameObject> enemySpacePlanes;
    private GameObject enemySpacePlane;

    [SerializeField]
    private GameObject EnemyDirectPlanePrefab;
    private Queue<GameObject> enemyDirectPlanes;
    private GameObject enemyDirectPlane;

    [SerializeField]
    private GameObject parent;

    private void Start()
    {
        GameObject EnemyPlaneObj;

        enemyPlanes = new Queue<GameObject>();
        enemySpacePlanes = new Queue<GameObject>();

        for (int i = 0; i < enemyCount; i++)
        {
            EnemyPlaneObj = Instantiate(EnemyPlanePrefab);
            EnemyPlaneObj.SetActive(false);
            EnemyPlaneObj.transform.parent = parent.transform;
            enemyPlanes.Enqueue(EnemyPlaneObj);

            EnemyPlaneObj = Instantiate(EnemySpacePlanePrefab);
            EnemyPlaneObj.SetActive(false);
            EnemyPlaneObj.transform.parent = parent.transform;
            enemySpacePlanes.Enqueue(EnemyPlaneObj);

            //EnemyPlaneObj = Instantiate(EnemyDirectPlanePrefab);
            //EnemyPlaneObj.SetActive(false);
            //EnemyPlaneObj.transform.parent = parent.transform;
            //enemyDirectPlanes.Enqueue(EnemyPlaneObj);
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);
    }

    public IEnumerator SetEnemyPlaneOfPositionAndActive(Transform transform)
    {
        Vector3 position1 = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
        Vector3 position2 = new Vector3(transform.position.x - 4, transform.position.y, transform.position.z);

        while (true)
        {
            if (enemyPlanes.Count > enemyCount)
                yield return null;
            if (time <= 10)
            {
                enemyPlane = enemyPlanes.Dequeue();
                enemyPlane.SetActive(true);
                enemyPlane.transform.position = transform.position;
                yield return new WaitForSeconds(3f);

                enemyPlane = enemyPlanes.Dequeue();
                enemyPlane.SetActive(true);
                enemyPlane.transform.position = position1;
                yield return new WaitForSeconds(3f);

                enemyPlane = enemyPlanes.Dequeue();
                enemyPlane.SetActive(true);
                enemyPlane.transform.position = position2;
                yield return new WaitForSeconds(3f);
            }

            if(time > 10 && time < 90)
            {
                enemyPlane = enemyPlanes.Dequeue();
                enemyPlane.SetActive(true);
                enemyPlane.transform.position = transform.position;
                yield return new WaitForSeconds(3f);

                enemyPlane = enemyPlanes.Dequeue();
                enemyPlane.SetActive(true);
                enemyPlane.transform.position = position1;
                yield return new WaitForSeconds(2f);

                enemyPlane = enemyPlanes.Dequeue();
                enemyPlane.SetActive(true);
                enemyPlane.transform.position = position2;
                yield return new WaitForSeconds(2f);
            }
        }
    }

    public IEnumerator SetEnemySpacePlaneOfPositionAndActive(Transform transform)
    {
        while (true)
        {
            if (enemySpacePlanes.Count > enemyCount)
                yield return null;
            if (time > 10 && time < 65)
            {
                enemySpacePlane = enemySpacePlanes.Dequeue();
                enemySpacePlane.SetActive(true);
                enemySpacePlane.transform.position = transform.position;
            }
            yield return new WaitForSeconds(5f);
        }
    }

    public IEnumerator SetEnemyDirectPlaneOfPositionAndActive(Transform transform)
    {
        while (true)
        {
            if (enemyDirectPlanes.Count > enemyCount)
                yield return null;
            if (enemyDirectPlanes.Count != 0)
            {
                enemyDirectPlane = enemyDirectPlanes.Dequeue();
                enemyDirectPlane.SetActive(true);
                enemyDirectPlane.transform.position = transform.position;
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

    public void EnemyDirectPlaneEnqueue(GameObject other)
    {
        enemyDirectPlanes.Enqueue(other);
    }
}
