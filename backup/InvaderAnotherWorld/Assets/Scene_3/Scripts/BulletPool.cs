using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;
    private int BulletCount = 10;
    private float fireTime = 0.25f;
    private float nextFire = 0f;
    private  GameObject tempBullet;
    [SerializeField]
    private GameObject parent;

    public static Queue<GameObject> bullets;

    private void Start()
    {
      
            bullets = new Queue<GameObject>();
            for (int i = 0; i < BulletCount; i++)
            {
                GameObject obj = Instantiate(Bullet);
                obj.transform.parent = parent.transform;
                obj.SetActive(false);
                bullets.Enqueue(obj);
              
            }
    }

    public void Fire(Transform t)
    {
        if (bullets.Count > BulletCount)
            return;

        if (nextFire < Time.time + fireTime && bullets.Count != 0)
        {
            tempBullet = bullets.Dequeue();
            tempBullet.SetActive(true);
            tempBullet.transform.position = t.position;
            nextFire = Time.time;
        }

    }

    public static void EnqeueBullet(GameObject bullet)
    {
        bullets.Enqueue(bullet);
    }

    public void OnDisable()
    {
        Debug.Log("객체 setactive false");
    }

    public void OnEnable()
    {
        Debug.Log("객체 setactvie true");
    }


}
