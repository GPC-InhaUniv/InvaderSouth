using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject Bullet;
    public int BulletCount = 10;
    public static Queue<GameObject> bullets;
    public float fireTime = 0.25f;
    public float nextFire = 0f;
    GameObject tempBullet;

    private void Start()
    {
        if (bullets == null)
        {
            bullets = new Queue<GameObject>();
            for (int i = 0; i < BulletCount; i++)
            {
                GameObject obj = Instantiate(Bullet);
                obj.SetActive(false);
                bullets.Enqueue(obj);
                DontDestroyOnLoad(obj);
            }

        }

    }

    public void Fire(Transform p)
    {
        if (bullets.Count>BulletCount)
            return;

        if (nextFire < Time.time + fireTime&& bullets.Count != 0)
        {
          
                tempBullet = bullets.Dequeue();
                tempBullet.SetActive(true);
             tempBullet.transform.position = p.position;
                nextFire = Time.time;
          
        }

    }


}
