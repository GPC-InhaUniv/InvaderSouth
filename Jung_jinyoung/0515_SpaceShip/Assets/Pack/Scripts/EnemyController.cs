using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject EnemyBolt;
    public Transform BoltSpawn;
    public int damage = 1;
    private GameObject BoltObject;

    private void Start()
    {
        StartCoroutine(EnemyShot());
    }

    private IEnumerator EnemyShot()
    {
        while (true)
        {
            BoltObject = Instantiate(EnemyBolt);
            EnemyBolt.transform.position = BoltSpawn.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bolt")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
