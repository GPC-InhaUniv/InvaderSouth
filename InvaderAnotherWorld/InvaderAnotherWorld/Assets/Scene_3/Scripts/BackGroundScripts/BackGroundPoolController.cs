using UnityEngine;

public class BackGroundPoolController : MonoBehaviour {

    private BackGroundPool backGroundPool; 

    // Use this for initialization
    void Start ()
    {
        Screen.SetResolution(700, 1080, true);
        backGroundPool = GameObject.Find("GameObjectPool").GetComponent<BackGroundPool>();

	}
}
