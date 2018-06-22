using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointPathEditor : MonoBehaviour {

    [SerializeField]
    Color rayColor = Color.white;
    //[SerializeField]
    public List<Transform> pathObjects = new List<Transform>();
    [SerializeField]
    Transform[] theArray;

    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform>();
        pathObjects.Clear();

        foreach (Transform pathObject in theArray)
        {
            if(pathObject != this.transform)
            {
                pathObjects.Add(pathObject);
            }
        }
        for(int i = 0; i <pathObjects.Count; i++)
        {
            Vector3 position = pathObjects[i].position;
            if (i>0)
            {
                Vector3 previous = pathObjects[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, 0.3f);
            }
        }
    }
}
