using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {
    private GameObject backgroundObject;
    private GameObject bulletObject;
    private GameObject gameobjectPool;
    [SerializeField]
    private GameObject sparkBomb;

    private int stageAmount = 3;
    private int currentStage = 0;

    /*Load Enemy1*/
    [SerializeField]
    private GameObject enemy1GeneratePosition;
    [SerializeField]
    private GameObject enemy2GeneratePosition;
    private EnemyPool enemyPool; 

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
        gameobjectPool = GameObject.FindGameObjectWithTag("ObjectPoolManager").gameObject;

        MakeGameRule();

        //  StartCoroutine(MakeSparkBomb());
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            ReStartThisStage();
        }
    }

    void MakeGameRule()
    {
        switch (currentStage)
        {
            case 0:
                {
                    enemy1GeneratePosition.SetActive(true);
                    enemy2GeneratePosition.SetActive(true);
                    break;
                }
            case 1:
                {
                    break;
                }
            case 2:
                {
                    bossEnemyPool = gameobjectPool.GetComponent<BossEnemyPool>();
                    StartCoroutine(MakeBossEnmey());
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

    void ReStartThisStage()
    {
        Destroy(backgroundObject);
        Destroy(bulletObject);
        Destroy(gameobjectPool);
        LoadingSceneController.LoadScene("Main");
    }


    
}
