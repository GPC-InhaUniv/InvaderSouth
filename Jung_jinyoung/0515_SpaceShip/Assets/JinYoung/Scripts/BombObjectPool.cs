using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObjectPool : MonoBehaviour {

    public GameObject Bomb;
    public GameObject Bomber;
    public int BombCount;
    List<GameObject> Bombs;
    public bool BombActive;
    

    public Boundary boundary;
    public float spaqwnWait;
    public float endWait;
    public float startWait;
    public Vector3 spawnValue;
    Vector3 spawnPosition;
    Quaternion spawnRotation;
    
    
    void Awake()
    {
        
        boundary.xMax = 7;
        boundary.xMin = -7;
        boundary.zMax = 20;
        boundary.zMin = 0;

        //object pool 생성
        Bombs = new List<GameObject>();
        
        //폭격기 오브젝트 생성
        Bomber.SetActive(false);
        Bombs.Add(Instantiate(Bomber));
        
        //폭탄 생성
        for (int i = 1; i < BombCount+1; i++)
        {
            GameObject obj = Instantiate(Bomb);
            obj.SetActive(false);
            Bombs.Add(obj);
        }
        //Object Pool 생성 끝
    }
    
    //폭격시작 메소드(폭격중인지 확인하고 아니면 폭격코루틴을 동작시킨다)
    public void StartBombing()
    {
        if (!BombActive)
        {
            StartCoroutine(BombingCoroutine());
        }
    }
    //void OnWillRenderObject()
    //{
    //    Debug.Log("OnWillRenderObject");
    //    if (tag == "Enemy")
    //    {
    //        gameObject.SetActive(false);
    //        Debug.Log("OnWillRenderObject23232");
    //    }
    //}

    IEnumerator BombingCoroutine()
    {
        //Vector3 viewPos = Camera.WorldToViewportPoint();
        BombActive = true;
        if (BombActive)
        {
            //폭격기 오브젝트의 위치를 초기화 하고 동작시킨다
            Bombs[0].transform.position = new Vector3(0f, 0f, boundary.zMin - 10f);
            Bombs[0].SetActive(true); 
        }

        yield return new WaitForSeconds(startWait);
        for (int i = 1; i < boundary.zMax; i++)
        {
            spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), 0f, i);
            //Debug.Log(spawnPosition);
            spawnRotation = Quaternion.identity;
            Bombs[i].transform.position = spawnPosition;
            Bombs[i].transform.rotation = spawnRotation;
            Bombs[i].SetActive(true);
            yield return new WaitForSeconds(spaqwnWait);
        }

        yield return new WaitForSeconds(endWait);
        BombActive = false;
        //Debug.Log("Bombing over");
    }
}
