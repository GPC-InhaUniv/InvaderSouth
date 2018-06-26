using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkBombPool : MonoBehaviour
{

    [SerializeField]
    private GameObject sparkBombObject;

    private int enemyCount = 30;
    List<GameObject> backgroundObjects;
    private float spaqwnWait;
    private float startWait;
    private float waveWait;
    private Vector3 spawnValue;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    [SerializeField]
    private GameObject parent;

    // Use this for initialization
    void Start()
    {

        //object pool 생성
        backgroundObjects = new List<GameObject>();
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject obj = Instantiate(sparkBombObject);
            obj.transform.parent = parent.transform;
            obj.SetActive(false);
            backgroundObjects.Add(obj);
           
        }

    }

    public void StartBackGround()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < backgroundObjects.Count; i++)
            {
                spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                spawnRotation = Quaternion.identity;

                backgroundObjects[i].SetActive(true);
                backgroundObjects[i].transform.position = spawnPosition;
                backgroundObjects[i].transform.rotation = spawnRotation;
                yield return new WaitForSeconds(spaqwnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
