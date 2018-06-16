using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPoolController : MonoBehaviour
{
    private LoadingSceneController LoadingSceneController;

    private void Start()
    {
        GameManager.Instance.currentStage = 2;
        LoadingSceneController = GameObject.Find("LoadingSceneManager").GetComponent<LoadingSceneController>();
        switch (GameManager.Instance.currentStage)
        {
            
            case 0:            
                LoadingSceneController.LoadInGameSceneDelegater = new LoadingSceneController.LoadInGameScene(MakeObjectPoolAtStage0);
                break;
            case 1:      
                LoadingSceneController.LoadInGameSceneDelegater = new LoadingSceneController.LoadInGameScene(MakeObjectPoolAtStage1);
                break;
            case 2:
                LoadingSceneController.LoadInGameSceneDelegater = new LoadingSceneController.LoadInGameScene(MakeObjectPoolAtStage2);
                break;
            default:
                break;
        }
     

    }

    public void MakeObjectPoolAtStage0()
    {
        GetComponent<BulletPool>().enabled = true;
        GetComponent<BackGroundPool>().enabled = true;
        DontDestroyOnLoad(gameObject);
        Debug.Log("GameObjectPool 0스테이지 작동");

    }

    public void MakeObjectPoolAtStage1()
    {
        GetComponent<BulletPool>().enabled = true;
        GetComponent<BackGroundPool>().enabled = true;
        DontDestroyOnLoad(gameObject);
        Debug.Log("GameObjectPool 1 스테이지 작동");

    }

    public void MakeObjectPoolAtStage2()
    {
        GetComponent<BulletPool>().enabled = true;
        GetComponent<BackGroundPool>().enabled = true;
        GetComponent<BossBulletPool>().enabled = true;
        DontDestroyOnLoad(gameObject);
        Debug.Log("GameObjectPool 2 스테이지 작동");
    }




}
