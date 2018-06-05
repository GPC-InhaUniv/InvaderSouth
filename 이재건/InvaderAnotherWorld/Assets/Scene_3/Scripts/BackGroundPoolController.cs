using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundPoolController : MonoBehaviour {
    public BackGroundPool backGroundPool; 


    // Use this for initialization
    void Start () {
        Screen.SetResolution(700, 1080, true);
        backGroundPool = GameObject.Find("GameObjectPool").GetComponent<BackGroundPool>();
        backGroundPool.StartBackGround();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
