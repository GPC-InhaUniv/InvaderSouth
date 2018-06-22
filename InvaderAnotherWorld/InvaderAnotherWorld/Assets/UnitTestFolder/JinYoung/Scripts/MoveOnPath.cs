using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour {

    [SerializeField]
    WayPointPathEditor pathToFollow;

    [SerializeField]
    int currentWayPointID = 0;
    [SerializeField]
    float speed;
    [SerializeField]
    float reachDistance = 1f;
    [SerializeField]
    float rotationSpeed = 5f;
    string pathName;

    Vector3 lastPosition;
    Vector3 currentPosition;

	// Use this for initialization
	void Start () {
        //pathToFollow = GameObject.Find(pathName).GetComponent<WayPointPathEditor>();
        lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(pathToFollow.pathObjects[currentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, pathToFollow.pathObjects[currentWayPointID].position, rotationSpeed * Time.deltaTime);
        
        //transform.position = Vector3.Lerp(transform.position, pathToFollow.pathObjects[currentWayPointID].position, rotationSpeed * Time.deltaTime);
        //transform.position = Vector3.SlerpUnclamped(transform.position, pathToFollow.pathObjects[currentWayPointID].position, rotationSpeed * Time.deltaTime);

        if (distance <=reachDistance)
        {
            currentWayPointID++;
        }
        if (currentWayPointID>=pathToFollow.pathObjects.Count)
        {
            gameObject.GetComponent<MoveOnPath>().enabled =false;
        }

    }
}
