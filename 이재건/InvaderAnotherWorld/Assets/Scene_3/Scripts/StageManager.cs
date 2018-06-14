using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {
    private GameObject backgroundObject;
    private GameObject bulletObject;
    private GameObject gameobjectPool;
    [SerializeField]
    private GameObject sparkBomb; 

	// Use this for initialization
	void Start () {
        //backgroundObject = GameObject.Find("BackGroundElemtns").gameObject;
        //bulletObject = GameObject.Find("Bullets").gameObject;
        //gameobjectPool = GameObject.Find("GameObjectPool").gameObject;
        StartCoroutine(makeSparkBomb());
    }
	
    IEnumerator makeSparkBomb()
    {
        while(true)
        {
            Instantiate(sparkBomb, new Vector3(Random.Range(-5,5),3.6f,Random.Range(18,23)),Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Destroy(backgroundObject);
            Destroy(bulletObject);
            Destroy(gameobjectPool);
            LoadingSceneController.LoadScene("Main");
        }
    }

    
}
