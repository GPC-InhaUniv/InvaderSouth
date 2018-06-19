﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetObjectPool : MonoBehaviour {

    [SerializeField]
    private GameObject petObjectPrefab;
    [SerializeField]
    private GameObject petMissilePrefab;
    private Queue<GameObject> petMissiles;
    private GameObject petMissile;
    private const int petMissileCount = 10;
    //private const float fireTime = 0.25f;
    //private float nextFire = 1f;
    

    [SerializeField]
    private GameObject parent;

    private void Start()
    {
        petMissiles = new Queue<GameObject>();
        GameObject petObject = Instantiate(petObjectPrefab) as GameObject;
        petObject.SetActive(true);
        petObject.transform.parent = parent.transform;
        //petMissiles.Enqueue(petObject);
        


        for (int i = 1; i < petMissileCount; i++)
        {
            GameObject petMissileObjcet = Instantiate(petMissilePrefab) as GameObject;
            petMissileObjcet.SetActive(false);
            petMissileObjcet.transform.parent = parent.transform;
            petMissiles.Enqueue(petMissileObjcet);
        }

    }

    public void SetPetMissileOfPositionAndActive(Transform p)
    {
        petMissile = petMissiles.Dequeue();
        petMissile.SetActive(true);
        petMissile.transform.position = p.position;

        //if (petMissiles.Count > petMissileCount)
        //    return;
        //if (nextFire < Time.time + fireTime && petMissiles.Count != 0)
        //{
        //    petMissile = petMissiles.Dequeue();
        //    petMissile.SetActive(true);
        //    petMissile.transform.position = p.position;
        //    nextFire = Time.time;
        //}
    }

    public void PetMissilesEnqueue(GameObject other)
    {
        petMissiles.Enqueue(other.gameObject);
    }
}
