using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerBulletPrefab;
    public static Queue<GameObject> playerBullets;
    private GameObject playerBullet;
<<<<<<< HEAD
    private const int playerBulletCount = 20;
    //private const float fireRate = 0.25f;
    //private float nextFire = 0f;
=======
    private const int playerBulletCount = 10;
    private const float fireRate = 0.25f;
    private float nextFire = 0f;
>>>>>>> 2b08154109aad59b18096110877c9f76530cad70

    [SerializeField]
    private GameObject EnemyBulletPrefab;
    public static Queue<GameObject> enemyBullets;
    private GameObject enemyBullet;
    private const int enemyBulletCount = 150;

    [SerializeField]
    private GameObject parent;

    private void Start()
    {
        playerBullets = new Queue<GameObject>();
        enemyBullets = new Queue<GameObject>();

        for (int i = 0; i < playerBulletCount; i++)
        {
            GameObject PlayerBulletObj = Instantiate(PlayerBulletPrefab) as GameObject;
            PlayerBulletObj.SetActive(false);
            PlayerBulletObj.transform.parent = parent.transform;
            playerBullets.Enqueue(PlayerBulletObj);
        }

        for(int i = 0; i < enemyBulletCount; i++)
        {
            GameObject EnemyBulletObj = Instantiate(EnemyBulletPrefab) as GameObject;
            EnemyBulletObj.SetActive(false);
            EnemyBulletObj.transform.parent = parent.transform;
            enemyBullets.Enqueue(EnemyBulletObj);
        }
    }

    public void SetPlayerBulletOfPositionAndActive(Transform transform)
    {
        if (playerBullets.Count > playerBulletCount)
            return;
        if (Time.time > nextFire && playerBullets.Count != 0)
        {
            playerBullet = playerBullets.Dequeue();
            playerBullet.SetActive(true);
            playerBullet.transform.position = transform.position;
            nextFire = Time.time + fireRate;
        }
    }

    public void SetEnemyBulletOfPositionAndActive(Transform transform)
    {
        if(transform.position.z < 20)
        {
            enemyBullet = enemyBullets.Dequeue();
            enemyBullet.SetActive(true);
            enemyBullet.transform.position = transform.position;
        }
    }
}