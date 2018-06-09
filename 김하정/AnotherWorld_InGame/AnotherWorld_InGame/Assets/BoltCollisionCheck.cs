using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltCollisionCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bolt" || other.tag == "EnemyBolt")
        {
            Destroy(other.gameObject);
        }
    }
}
