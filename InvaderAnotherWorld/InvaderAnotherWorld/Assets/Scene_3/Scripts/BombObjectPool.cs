using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BombObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject Bomb;
    [SerializeField]
    private GameObject Bomber;
    private int BombCount=30;
    private List<GameObject> Bombs;
    private bool BombActive;


    private BombBoundary bombBoundary;
    private float spaqwnWait;
    private float endWait;
    private float startWait;
    private Vector3 spawnValue;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    public struct BombBoundary
    {
        public float boundaryXMax;
        public float boundaryXMin;
        public float boundaryZMax;
        public float boundaryZMin;

        public BombBoundary(float XMax, float XMin, float ZMax, float ZMin)
        {
            boundaryXMax = XMax;
            boundaryXMin = XMin;
            boundaryZMax = ZMax;
            boundaryZMin = ZMin;
        }
    }


    [SerializeField]
    private GameObject parent;
    
    private void Start()
    {
        bombBoundary = new BombBoundary(7, -7, 20, 0);
  
        spaqwnWait = 0.05f;
        endWait = 2.0f;
        startWait = 0.8f;
        spawnValue.x = 6.0f;
        spawnValue.y = 1.0f;

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
            obj.transform.parent = parent.transform;
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

    IEnumerator BombingCoroutine()
    {
        //Vector3 viewPos = Camera.WorldToViewportPoint();
        BombActive = true;
        if (BombActive)
        {
            //폭격기 오브젝트의 위치를 초기화 하고 동작시킨다
            Bombs[0].transform.position = new Vector3(0f, 0f, bombBoundary.boundaryZMin - 10f);
            Bombs[0].SetActive(true); 
        }

        yield return new WaitForSeconds(startWait);
        for (int i = 1; i < bombBoundary.boundaryZMax; i++)
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
