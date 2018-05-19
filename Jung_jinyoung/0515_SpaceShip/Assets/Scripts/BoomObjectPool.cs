using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomObjectPool : MonoBehaviour {

    public GameObject Boom;
    public int BoomCount = 30;
    List<GameObject> Booms;


    public Boundary boundary;
    public float spaqwnWait;
    public float startWait;
    public float waveWait;
    public Vector3 spawnValue;
    Vector3 spawnPosition;
    Quaternion spawnRotation;

    // Use this for initialization
    void Start()
    {
        Screen.SetResolution(700, 1080, true);
        //boundary.xMax = 700;
        //boundary.zMax = (1080/3)*2;
        boundary.xMax = 7;
        boundary.zMax = 20;
        Debug.Log(boundary.xMax);
        Debug.Log(boundary.zMax);



        //object pool 생성
        Booms = new List<GameObject>();
        for (int i = 0; i < BoomCount; i++)
        {
            GameObject obj = Instantiate(Boom);
            obj.SetActive(false);
            //obj.transform.position = new Vector3()
            Booms.Add(obj);
        }
        //Object Pool 생성 끝
        //StartCoroutine(Boomming());
        Boomming();
    }

    private void Boomming()
    {
        foreach(GameObject boom in Booms)
        {
            Debug.Log(boundary.xMax);
            Debug.Log(boundary.zMax);
            spawnPosition = new Vector3(boundary.xMax, 0f, boundary.zMax);
            spawnRotation = Quaternion.identity;
            boom.transform.position = spawnPosition;
            boom.transform.rotation = spawnRotation;
            boom.SetActive(true);
        }
    }

    //IEnumerator Boomming()
    //{
    //    yield return new WaitForSeconds(startWait);
    //    foreach (GameObject boom in Booms)
    //    {
    //        spawnPosition = new Vector3();
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
