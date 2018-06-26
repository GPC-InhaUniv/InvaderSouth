using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour
{

    [SerializeField]
    WayPointPathEditor pathToFollow;
    WayPointPathEditor firstPath;
    WayPointPathEditor secondPath;
    WayPointPathEditor thirdPath;
    WayPointPathEditor normalPath;

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

    public bool firstMove = false;
    public bool secondMove = false;
    public bool thirdMove = false;
    bool normalMove = false;

    // Use this for initialization
    void Start()
    {
        //pathToFollow = GameObject.Find(pathName).GetComponent<WayPointPathEditor>();
        firstPath = GameObject.Find("WayPointPathsHolder1").GetComponent<WayPointPathEditor>();
        secondPath = GameObject.Find("WayPointPathsHolder2").GetComponent<WayPointPathEditor>();
        thirdPath = GameObject.Find("WayPointPathsHolder3").GetComponent<WayPointPathEditor>();
        normalPath = GameObject.Find("WayPointPathsHolder_Normal").GetComponent<WayPointPathEditor>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstMove)
        {
            PathToFollowing(firstPath);
            //firstMove = false;
        }
        else if (secondMove)
        {
            PathToFollowing(secondPath);
            //secondMove = false;
        }
        else if (thirdMove)
        {
            PathToFollowing(thirdPath);
            //thirdMove = false;
        }
        else if (normalMove)
        {
            PathToFollowing(normalPath);
        }
    }


    void PathToFollowing(WayPointPathEditor path)
    {
        pathToFollow = path;
        if (currentWayPointID >= pathToFollow.pathObjects.Count)
        {
            currentWayPointID = 0;
        }
        float distance = Vector3.Distance(pathToFollow.pathObjects[currentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, pathToFollow.pathObjects[currentWayPointID].position, rotationSpeed * Time.deltaTime);
        if (distance <= reachDistance)
        {
            currentWayPointID++;
        }
        if (currentWayPointID >= pathToFollow.pathObjects.Count)
        {
            ResetToPath();
        }
    }
    void ResetToPath()
    {
        currentWayPointID = 0;
        firstMove = false;
        secondMove = false;
        thirdMove = false;
        normalMove = true;
    }

}
