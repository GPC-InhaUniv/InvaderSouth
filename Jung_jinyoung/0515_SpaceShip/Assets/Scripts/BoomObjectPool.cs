using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomObjectPool : MonoBehaviour {

    public GameObject Bomb;
    public int BombCount;
    List<GameObject> Bombs;
    public bool boomActive;
    public GameObject bomber;

    public Boundary boundary;
    public float spaqwnWait;
    public float endWait;
    public float startWait;
    public Vector3 spawnValue;
    Vector3 spawnPosition;
    Quaternion spawnRotation;
    

    // Use this for initialization
    void Awake()
    {
        
        boundary.xMax = 7;
        boundary.xMin = -7;
        boundary.zMax = 20;
        boundary.zMin = 0;

        //object pool 생성
        Bombs = new List<GameObject>();
        for (int i = 0; i < BombCount; i++)
        {
            GameObject obj = Instantiate(Bomb);
            obj.SetActive(false);
            //obj.transform.position = new Vector3()
            Bombs.Add(obj);
        }
        //Object Pool 생성 끝
        Debug.Log("objpool");
        //Random.state = 3;


    }
    
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Instantiate(bomber);
    //        Debug.Log("spacebar");
    //        boomActive = true;
    //    }
    //    if (boomActive)
    //    {
    //        Debug.Log("if in");
    //        StartCoroutine(Bombing());
    //    }
    //}

    public void StartBombing()
    {
        boomActive = true;
        Instantiate(bomber);
        StartCoroutine(Bombing());
    }

    IEnumerator Bombing()
    {
        
        yield return new WaitForSeconds(startWait);
        boomActive = false;

        //Debug.Log("Bombing");

        for (int i = 0; i < boundary.zMax; i++)
        {
            spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), 0f, i);
            //Debug.Log(spawnPosition);
            spawnRotation = Quaternion.identity;
            Bombs[i].transform.position = spawnPosition;
            Bombs[i].transform.rotation = spawnRotation;
            Bombs[i].SetActive(true);
            yield return new WaitForSeconds(spaqwnWait);
        }
        
        //Debug.Log("Bombing over");
    }
}
