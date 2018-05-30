using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPoolController :MonoBehaviour
{

    private void OnLevelWasLoaded(int level)
    {
        if(LoadingSceneController.isMainSceneLoading)
        {
            GetComponent<BulletPool>().enabled = true;
            GetComponent<BackGroundPool>().enabled = true;
            DontDestroyOnLoad(gameObject);
            Debug.Log("GameObjectPool 작동");
        } 
    }

}
