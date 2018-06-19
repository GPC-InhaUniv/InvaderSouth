﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPoolController : MonoBehaviour
{
    private LoadingSceneController LoadingSceneController;

    private void Start()
    { 
        LoadingSceneController = GameObject.Find("LoadingSceneManager").GetComponent<LoadingSceneController>();
        switch (GameManager.Instance.CurrentStage)
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
            case 4:
                break;
            default:
                Debug.Log("error!");
                break;
        }
     

    }

    public void MakeObjectPoolAtStage0()
    {
        GetComponent<BulletPool>().enabled = true;
        GetComponent<BackGroundPool>().enabled = true;
        GetComponent<BulletObjectPool>().enabled = true;
        GetComponent<EnemyObjectPool>().enabled = true;
        DontDestroyOnLoad(gameObject);
        Debug.Log("GameObjectPool 0스테이지 작동");

    }

    public void MakeObjectPoolAtStage1()
    {
        GetComponent<BulletPool>().enabled = true;
        GetComponent<BackGroundPool>().enabled = true;
        GetComponent<BossEnemyPool>().enabled = true;
        DontDestroyOnLoad(gameObject);
        Debug.Log("GameObjectPool 1 스테이지 작동");

    }

    public void MakeObjectPoolAtStage2()
    {
        GetComponent<BulletPool>().enabled = true;
        GetComponent<BackGroundPool>().enabled = true;
        GetComponent<BossEnemyPool>().enabled = true;
        DontDestroyOnLoad(gameObject);
        Debug.Log("GameObjectPool 2 스테이지 작동");
    }




}
