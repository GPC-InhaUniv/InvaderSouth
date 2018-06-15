using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundPool : MonoBehaviour
{

    public GameObject BackGround;
    public int EnemyCount = 30;
    List<GameObject> backgroundObjects;
    public float spaqwnWait;
    public float startWait;
    public float waveWait;
    public Vector3 spawnValue;
    Vector3 spawnPosition;
    Quaternion spawnRotation;
    public GameObject parent;

    // Use this for initialization
    void Start()
    {
        
            //object pool 생성
            backgroundObjects = new List<GameObject>();
            for (int i = 0; i < EnemyCount; i++)
            {
                GameObject obj = Instantiate(BackGround);
                obj.transform.parent = parent.transform;
                obj.SetActive(false);
                backgroundObjects.Add(obj);
              //  DontDestroyOnLoad(obj);
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
