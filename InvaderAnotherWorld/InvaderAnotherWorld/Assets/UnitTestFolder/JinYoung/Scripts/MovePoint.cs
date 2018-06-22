using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour {

    [SerializeField]
    float speed;
    [SerializeField]
    Vector3[] movePoints;
    
    Vector3 objectPosition;
    int movePointIndex;

    


    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame
    void Update()
    {
        objectPosition = transform.position;

        if (movePointIndex < movePoints.Length)
        {
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(objectPosition, movePoints[movePointIndex], step);

            if (Vector3.Distance(movePoints[movePointIndex], objectPosition) == 0f)
                movePointIndex++;
        }
        Gizmos.DrawLine(Vector3.zero, new Vector3(1, 0, 0));
        
    }
}
