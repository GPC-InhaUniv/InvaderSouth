using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {
    private GameObject backgroundObject;
    
    [SerializeField]
    private GameObject sparkBomb;
    private int maxEnemyCount = 0;
    public static int KillEnemyCount = 0;
    private int stageAmount = 3;
    private int currentStage = 0;
    public static float time;

    /*Load BossEnemy*/
    private BossEnemyPool bossEnemyPool;
    [SerializeField]
    private Transform bossGeneratePosition;

    // Use this for initialization
    void Start()
    {
        currentStage=CheckPlayerStage(GameManager.Instance.CurrentStage);
        //backgroundObject = GameObject.Find("BackGroundElemtns").gameObject;
        //bulletObject = GameObject.Find("Bullets").gameObject;

        //MakeGameRule();

        //  StartCoroutine(MakeSparkBomb());
    }

    // Update is called once per frame
    void Update()
    {
        if(time <= 100)
        {
            time += Time.deltaTime;
            //Debug.Log(time);

            if(Input.GetKey(KeyCode.S) == true)
            {
                time += 10;
            }
        }

        //if (KillEnemyCount>=maxEnemyCount)
        //    Debug.Log("게임 클리어");
    
      
    }

    public static void KillEnemy()
    {
        KillEnemyCount++;
        Debug.Log(KillEnemyCount);
    }
    void MakeGameRule()
    {
        switch (currentStage)
        {
            case 0:
                {
                    KillEnemyCount = 0;
                    maxEnemyCount = 51;
                    break;
                }
            case 1:
                {
                    break;
                }
            case 2:
                {
                    
                    break;
                }
            case 4:
                {
                    break;
                }
            default:
                {
                    Debug.Log("error stage load");
                    break;
                }
        }
    }

    int CheckPlayerStage(int playerCurrentStage)
    {
        int currentStage = 0;

        for (int i = 0; i < stageAmount; i++)
        {
            if (playerCurrentStage == currentStage)
            {
                return currentStage;

            }
            else
                currentStage = (1 << currentStage);
        }

        return -1;
    }

    IEnumerator MakeEnemyOne()
    {
        yield return new WaitForSeconds(5.0f);
       
    }

    IEnumerator MakeBossEnmey()
    {
        yield return new WaitForSeconds(5.0f);
        bossEnemyPool.GenerateBoss(bossGeneratePosition);

    }
	
    IEnumerator MakeSparkBomb()
    {
        while(true)
        {
            Instantiate(sparkBomb, new Vector3(Random.Range(-5,5),3.6f,Random.Range(18,23)),Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }

    //void ReStartThisStage()
    //{
    //    Destroy(backgroundObject);
    //    Destroy(bulletObject);
    //    Destroy(gameobjectPool);
    //    LoadingSceneController.LoadScene("Main");
    //}


    
}
