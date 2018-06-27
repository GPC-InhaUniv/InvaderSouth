using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickObject:Singleton<JoyStickObject> {

	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update ()
    {
        if (StageManager.time > 0)
            gameObject.SetActive(true);

        else if (StageManager.time == 0)
            gameObject.SetActive(false);
	}
}
