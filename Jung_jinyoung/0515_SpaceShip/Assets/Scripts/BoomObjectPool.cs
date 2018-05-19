using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomObjectPool : MonoBehaviour {

    public GameObject Boom;
    public int BoomCount = 30;
    List<GameObject> Booms;
    public float spaqwnWait;
    public float startWait;
    public float waveWait;
    public Vector3 spawnValue;
    Vector3 spawnPosition;
    Quaternion spawnRotation;

    // Use this for initialization
    void Start()
    {

        //object pool 생성
        Booms = new List<GameObject>();
        for (int i = 0; i < BoomCount; i++)
        {
            GameObject obj = Instantiate(Boom);
            obj.SetActive(false);
            Booms.Add(obj);
        }
        //Object Pool 생성 끝
        // StartCoroutine(SpawnWaves());
    }

    //IEnumerator SpawnWaves()
    //{
    //    yield return new WaitForSeconds(startWait);
    //    foreach(GameObject boom in Booms)
    //    {
    //        spawnPosition = new Vector3()
    //    }
    //    while (true)
    //    {
    //        for (int i = 0; i < Booms.Count; i++)
    //        {
    //            spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
    //            spawnRotation = Quaternion.identity;

    //            Booms[i].SetActive(true);
    //            Booms[i].transform.position = spawnPosition;
    //            Booms[i].transform.rotation = spawnRotation;
    //            yield return new WaitForSeconds(spaqwnWait);
    //        }
    //        yield return new WaitForSeconds(waveWait);
    //    }
    //}
}
