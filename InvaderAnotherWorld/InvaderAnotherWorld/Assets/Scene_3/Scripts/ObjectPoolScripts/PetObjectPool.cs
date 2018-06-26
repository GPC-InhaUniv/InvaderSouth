using System.Collections.Generic;
using UnityEngine;

public class PetObjectPool : MonoBehaviour
{

    [SerializeField]
    private GameObject petObjectPrefab;
    [SerializeField]
    private GameObject petMissilePrefab;
    public static Queue<GameObject> petMissiles;
    private GameObject petMissile;
    private const int petMissileCount = 3;


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
        petMissile.transform.rotation = p.rotation;
        petMissile.transform.position = p.position;
        petMissile.SetActive(true);
    }

    public static void PetMissilesEnqueue(GameObject other)
    {
        petMissiles.Enqueue(other.gameObject);
        other.SetActive(false);
    }
}
