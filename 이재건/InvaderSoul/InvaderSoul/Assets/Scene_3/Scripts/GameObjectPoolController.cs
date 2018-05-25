using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPoolController :MonoBehaviour
{

    private void OnLevelWasLoaded(int level)
    {
        if(LoadingSceneController.isMainSceneLoading)
        {
            Debug.Log("GameObjectPool 작동");
            gameObject.GetComponent<BulletPool>().enabled = true;
            gameObject.GetComponent<BackGroundPool>().enabled = true;
            DontDestroyOnLoad(gameObject);
        }
    }

}
