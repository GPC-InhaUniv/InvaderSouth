using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour {

    public GameObject Enemy;
    public int EnemyCount = 30;
    List<GameObject> enemies;
    public float spaqwnWait;
    public float startWait;
    public float waveWait;
    public Vector3 spawnValue;
    Vector3 spawnPosition;
    Quaternion spawnRotation;

    // Use this for initialization
    void Awake ()
    {
        
        //object pool 생성
        enemies = new List<GameObject>();
        for(int i=0;i<EnemyCount;i++)
        {
            GameObject obj =Instantiate(Enemy);
            obj.SetActive(false);
            enemies.Add(obj);
        }
        //Object Pool 생성 끝
        StartCoroutine(SpawnWaves());
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
              spawnRotation = Quaternion.identity;

                enemies[i].SetActive(true);
                enemies[i].transform.position = spawnPosition;
                enemies[i].transform.rotation = spawnRotation;
                yield return new WaitForSeconds(spaqwnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }


}
