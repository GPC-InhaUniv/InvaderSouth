using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltObjectPool : MonoBehaviour
{
    public GameObject Bolt;
    private int boltCount = 10;
    public static Queue<GameObject> Bolts;
    private float fireTime = 0.25f;
    private float nextFire = 0f;
    private GameObject tempbolt;

    private void Awake()
    {
        Bolts = new Queue<GameObject>();
        for(int i = 0; 0 < boltCount; i++)
        {
            GameObject obj = Instantiate(Bolt);
            obj.SetActive(false);
            Bolts.Enqueue(obj);
        }
    }

    public void Fire(Transform p)
    {
        if (Bolts.Count > boltCount)
            return;

        if (nextFire < Time.time + fireTime && Bolts.Count != 0)
        {
            tempbolt = Bolts.Dequeue();
            tempbolt.SetActive(true);
            tempbolt.transform.position = p.position;
            nextFire = Time.time;
        }
    }
}