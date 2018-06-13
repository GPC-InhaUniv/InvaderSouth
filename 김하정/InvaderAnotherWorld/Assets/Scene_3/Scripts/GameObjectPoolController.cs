using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPoolController : MonoBehaviour
{
    public LoadingSceneController LoadingSceneController;

    private void Start()
    {
        LoadingSceneController = GameObject.Find("LoadingSceneManager").GetComponent<LoadingSceneController>();
        LoadingSceneController.loadInGameSceneDelegater += new LoadingSceneController.LoadInGameScene(MakeObjectPoolAtStage1);

    }
    public void MakeObjectPoolAtStage1()
    {
        GetComponent<BulletPool>().enabled = true;
        GetComponent<BackGroundPool>().enabled = true;
        DontDestroyOnLoad(gameObject);
        Debug.Log("GameObjectPool 작동");

    }


}
