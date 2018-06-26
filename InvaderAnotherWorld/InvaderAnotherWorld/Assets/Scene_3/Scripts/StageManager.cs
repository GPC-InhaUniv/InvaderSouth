using UnityEngine;

public class StageManager : MonoBehaviour
{
    private GameObject backgroundObject;
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
        currentStage = CheckPlayerStage(GameManager.Instance.CurrentStage);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentStage == 0)
        {
            if (time <= 100)
            {
                time += Time.deltaTime;
                Debug.Log("Stage1 : " + time);

                if (Input.GetKeyDown(KeyCode.T) == true)
                {
                    time += 5;
                    Debug.Log(time);
                }
            }
        }

        else if (GameManager.Instance.CurrentStage == 1)
        {
            time += Time.deltaTime;
            Debug.Log("Stage2 : " + time);
        }


        if (Input.GetKeyDown(KeyCode.T) == true)
        {
            time += 5;
            Debug.Log(time);
        }
    }

    public static void KillEnemy()
    {
        KillEnemyCount++;
        Debug.Log(KillEnemyCount);
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

    //do not use yet
    //void MakeGameRule()
    //{
    //    switch (currentStage)
    //    {
    //        case 0:
    //            {
    //                KillEnemyCount = 0;
    //                maxEnemyCount = 51;
    //                break;
    //            }
    //        case 1:
    //            {
    //                break;
    //            }
    //        case 2:
    //            {

    //                break;
    //            }
    //        case 4:
    //            {
    //                break;
    //            }
    //        default:
    //            {
    //                Debug.Log("error stage load");
    //                break;
    //            }
    //    }
    //}

}
