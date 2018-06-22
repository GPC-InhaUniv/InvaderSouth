using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkBombController : MonoBehaviour {

    [SerializeField]
    private GameObject particleSystem;
    [SerializeField]
    private GameObject sparkCapsule;

    private float bombTime;
    private float autoSetActiveFlaseTime = 0.0f;
    // Use this for initialization
	void Start () {

        bombTime = 0.0f;
        particleSystem.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		if(2.0f>bombTime)
        {
            bombTime += Time.deltaTime;
        }
        else
        {
            particleSystem.SetActive(true);
            sparkCapsule.SetActive(false);
            
                
        }
        if(particleSystem.activeInHierarchy)
        {
            autoSetActiveFlaseTime += Time.deltaTime;
        }
        if(autoSetActiveFlaseTime>=1f)
        {
<<<<<<< HEAD

            autoSetActiveFlaseTime = 0;
            bombTime = 0;
            EnemyObjectPool.SparkBoms.Enqueue(this.gameObject);
=======
            autoSetActiveFlaseTime = 0;
            bombTime = 0;
            EnemyObjectPool.SparkBoms.Enqueue(this.gameObject);

>>>>>>> 97984a709e0a06981b72517083b23da5f54396c8
            gameObject.SetActive(false);
        }

	}
}
