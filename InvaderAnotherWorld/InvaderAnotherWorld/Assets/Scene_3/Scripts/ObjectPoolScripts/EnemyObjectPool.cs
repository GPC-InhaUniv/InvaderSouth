using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    private const int enemyCount = 20;

    [SerializeField]
    private GameObject enemyPlanePrefab;
    public static Queue<GameObject> EnemyPlanes;
    private GameObject enemyPlane;


    [SerializeField]
    private GameObject enemySpacePlanePrefab;
    public static Queue<GameObject> EnemySpacePlanes;
    private GameObject enemySpacePlane;

    [SerializeField]
    private GameObject enemyDirectPlanePrefab;
    public static Queue<GameObject> EnemyDirectPlanes;
    private GameObject enemyDirectPlane;

    [SerializeField]
    private GameObject sparkBomPrefab;
    public static Queue<GameObject> SparkBoms;
    private GameObject sparkBom;

    [SerializeField]
    private GameObject parent;

    private void Start()
    {
        GameObject EnemyPlaneObj;
        GameObject SparkBobObj;

        EnemyPlanes = new Queue<GameObject>();
        EnemySpacePlanes = new Queue<GameObject>();
        EnemyDirectPlanes = new Queue<GameObject>();
        SparkBoms = new Queue<GameObject>();

        for (int i = 0; i < enemyCount; i++)
        {
            EnemyPlaneObj = Instantiate(enemyPlanePrefab);
            EnemyPlaneObj.SetActive(false);
            EnemyPlaneObj.transform.parent = parent.transform;
            EnemyPlanes.Enqueue(EnemyPlaneObj);

            EnemyPlaneObj = Instantiate(enemySpacePlanePrefab);
            EnemyPlaneObj.SetActive(false);
            EnemyPlaneObj.transform.parent = parent.transform;
            EnemySpacePlanes.Enqueue(EnemyPlaneObj);

            EnemyPlaneObj = Instantiate(enemyDirectPlanePrefab);
            EnemyPlaneObj.SetActive(false);
            EnemyPlaneObj.transform.parent = parent.transform;
            EnemyDirectPlanes.Enqueue(EnemyPlaneObj);

            if (GameManager.Instance.CurrentStage == 1)
            {
                SparkBobObj = Instantiate(sparkBomPrefab);
                SparkBobObj.SetActive(false);
                SparkBobObj.transform.parent = parent.transform;
                SparkBoms.Enqueue(SparkBobObj);
            }
        }
    }

    public IEnumerator StageOneEnemyPlaneAndDirectPlaneOfPosition(Transform transform)
    {
        Vector3 position1 = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
        Vector3 position2 = new Vector3(transform.position.x - 4, transform.position.y, transform.position.z);
        Vector3 position3 = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        Vector3 position4 = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);

        while (true)
        {
            if (StageManager.time == 0)
            {
                yield return null;
            }

            if (EnemyPlanes.Count > enemyCount)
                yield return null;

            if (StageManager.time <= 10)
            {
                enemyPlane = EnemyPlanes.Dequeue();
                enemyPlane.SetActive(true);
                enemyPlane.transform.position = transform.position;
                yield return new WaitForSeconds(1f);

                enemyDirectPlane = EnemyDirectPlanes.Dequeue();
                enemyDirectPlane.SetActive(true);
                enemyDirectPlane.transform.position = position1;
                yield return new WaitForSeconds(1f);

                enemyDirectPlane = EnemyDirectPlanes.Dequeue();
                enemyDirectPlane.SetActive(true);
                enemyDirectPlane.transform.position = position2;
                yield return new WaitForSeconds(1f);
            }

            if (StageManager.time > 10 && StageManager.time <= 90)
            {
                enemyPlane = EnemyPlanes.Dequeue();
                enemyPlane.SetActive(true);
                enemyPlane.transform.position = transform.position;
                yield return new WaitForSeconds(2f);

                enemyDirectPlane = EnemyDirectPlanes.Dequeue();
                enemyDirectPlane.SetActive(true);
                enemyDirectPlane.transform.position = position1;
                yield return new WaitForSeconds(2f);

                enemyDirectPlane = EnemyDirectPlanes.Dequeue();
                enemyDirectPlane.SetActive(true);
                enemyDirectPlane.transform.position = position2;
                yield return new WaitForSeconds(2f);

                enemyPlane = EnemyPlanes.Dequeue();
                enemyPlane.SetActive(true);
                enemyPlane.transform.position = transform.position;
                yield return new WaitForSeconds(2f);

                enemyDirectPlane = EnemyDirectPlanes.Dequeue();
                enemyDirectPlane.SetActive(true);
                enemyDirectPlane.transform.position = position3;
                yield return new WaitForSeconds(2f);

                enemyDirectPlane = EnemyDirectPlanes.Dequeue();
                enemyDirectPlane.SetActive(true);
                enemyDirectPlane.transform.position = position4;
                yield return new WaitForSeconds(2f);
            }

            if (StageManager.time > 90)
            {
                break;
            }
        }
    }

    public IEnumerator StageOneEnemyEnemySpacePlnaeOfPosition(Transform transform)
    {
        Vector3 SecondPosition = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);

        while (true)
        {
            if (StageManager.time <= 10)
                yield return null;

            if (EnemySpacePlanes.Count > enemyCount)
                yield return null;

            if (StageManager.time > 10 && StageManager.time <= 65)
            {
                enemySpacePlane = EnemySpacePlanes.Dequeue();
                enemySpacePlane.SetActive(true);
                enemySpacePlane.transform.position = transform.position;
                yield return new WaitForSeconds(8f);

                enemySpacePlane = EnemySpacePlanes.Dequeue();
                enemySpacePlane.SetActive(true);
                enemySpacePlane.transform.position = SecondPosition;
                yield return new WaitForSeconds(8f);
            }

            if (StageManager.time > 65 && StageManager.time <= 90)
            {

                enemySpacePlane = EnemySpacePlanes.Dequeue();
                enemySpacePlane.SetActive(true);
                enemySpacePlane.transform.position = transform.position;
                yield return new WaitForSeconds(2f);

                enemySpacePlane = EnemySpacePlanes.Dequeue();
                enemySpacePlane.SetActive(true);
                enemySpacePlane.transform.position = SecondPosition;
                yield return new WaitForSeconds(4f);
            }

            if (StageManager.time > 90)
            {
                break;
            }
        }
    }

    public IEnumerator StageTwoEnemyPlaneAndDirectPlaneOfPosition(Transform transform)
    {
        Vector3 position1 = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);
        Vector3 position2 = new Vector3(transform.position.x - 4, transform.position.y, transform.position.z);
        Vector3 position3 = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        Vector3 position4 = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);

        while (true)
        {
            if (StageManager.time == 0)
            {
                yield return null;
            }

            if (EnemyPlanes.Count > enemyCount)
                yield return null;

            if (StageManager.time <= 10)
            {
                enemyPlane = EnemyPlanes.Dequeue();
                enemyPlane.SetActive(true);
                enemyPlane.transform.position = transform.position;
                yield return new WaitForSeconds(1f);

                enemyDirectPlane = EnemyDirectPlanes.Dequeue();
                enemyDirectPlane.SetActive(true);
                enemyDirectPlane.transform.position = position1;
                yield return new WaitForSeconds(1f);

                enemyDirectPlane = EnemyDirectPlanes.Dequeue();
                enemyDirectPlane.SetActive(true);
                enemyDirectPlane.transform.position = position2;
                yield return new WaitForSeconds(1f);
            }

            if (StageManager.time > 10)
            {
                enemyPlane = EnemyPlanes.Dequeue();
                enemyPlane.SetActive(true);
                enemyPlane.transform.position = transform.position;
                yield return new WaitForSeconds(2f);

                enemyDirectPlane = EnemyDirectPlanes.Dequeue();
                enemyDirectPlane.SetActive(true);
                enemyDirectPlane.transform.position = position1;
                yield return new WaitForSeconds(2f);

                enemyDirectPlane = EnemyDirectPlanes.Dequeue();
                enemyDirectPlane.SetActive(true);
                enemyDirectPlane.transform.position = position2;
                yield return new WaitForSeconds(2f);

                enemyPlane = EnemyPlanes.Dequeue();
                enemyPlane.SetActive(true);
                enemyPlane.transform.position = transform.position;
                yield return new WaitForSeconds(2f);

                enemyDirectPlane = EnemyDirectPlanes.Dequeue();
                enemyDirectPlane.SetActive(true);
                enemyDirectPlane.transform.position = position3;
                yield return new WaitForSeconds(2f);

                enemyDirectPlane = EnemyDirectPlanes.Dequeue();
                enemyDirectPlane.SetActive(true);
                enemyDirectPlane.transform.position = position4;
                yield return new WaitForSeconds(2f);
            }

            if (BossController.IsBossAlive == false)
            {
                break;
            }
        }
    }

    public IEnumerator StageTwoEnemySpacePlnaeOfPosition(Transform transform)
    {
        Vector3 SecondPosition = new Vector3(transform.position.x + 4, transform.position.y, transform.position.z);

        while (true)
        {
            if (StageManager.time <= 10)
                yield return null;

            if (EnemySpacePlanes.Count > enemyCount)
                yield return null;

            if (StageManager.time > 10 && StageManager.time <= 65)
            {
                enemySpacePlane = EnemySpacePlanes.Dequeue();
                enemySpacePlane.SetActive(true);
                enemySpacePlane.transform.position = transform.position;
                yield return new WaitForSeconds(5f);

                enemySpacePlane = EnemySpacePlanes.Dequeue();
                enemySpacePlane.SetActive(true);
                enemySpacePlane.transform.position = SecondPosition;
                yield return new WaitForSeconds(5f);
            }

            if (StageManager.time > 65)
            {

                enemySpacePlane = EnemySpacePlanes.Dequeue();
                enemySpacePlane.SetActive(true);
                enemySpacePlane.transform.position = transform.position;
                yield return new WaitForSeconds(3f);

                enemySpacePlane = EnemySpacePlanes.Dequeue();
                enemySpacePlane.SetActive(true);
                enemySpacePlane.transform.position = SecondPosition;
                yield return new WaitForSeconds(3f);
            }

            if (BossController.IsBossAlive == false)
            {
                break;
            }
        }
    }

    public IEnumerator StageTwoSparkBomOfPosition(Transform transform)
    {
        Vector3 Position1 = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
        Vector3 Position2 = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);

        while (true)
        {
            if (StageManager.time <= 10)
                yield return null;

            if (SparkBoms.Count > enemyCount)
                yield return null;

            if (StageManager.time > 10 && StageManager.time <= 30)
            {
                sparkBom = SparkBoms.Dequeue();
                sparkBom.SetActive(true);
                sparkBom.transform.position = Position1;
                yield return new WaitForSeconds(5f);

                sparkBom = SparkBoms.Dequeue();
                sparkBom.SetActive(true);
                sparkBom.transform.position = Position1;
                yield return new WaitForSeconds(5f);
            }

            if (StageManager.time > 30 && StageManager.time <= 60)
            {
                sparkBom = SparkBoms.Dequeue();
                sparkBom.SetActive(true);
                sparkBom.transform.position = transform.position;
                yield return new WaitForSeconds(10f);

                sparkBom = SparkBoms.Dequeue();
                sparkBom.SetActive(true);
                sparkBom.transform.position = Position1;
                yield return new WaitForSeconds(10f);

                sparkBom = SparkBoms.Dequeue();
                sparkBom.SetActive(true);
                sparkBom.transform.position = Position2;
                yield return new WaitForSeconds(10f);
            }

            if (StageManager.time > 60)
            {
                sparkBom = SparkBoms.Dequeue();
                sparkBom.SetActive(true);
                sparkBom.transform.position = Position2;
                yield return new WaitForSeconds(20f);
            }

            if (BossController.IsBossAlive == false)
            {
                break;
            }
        }
    }
}