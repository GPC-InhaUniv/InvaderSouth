using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    public GameObject PlayerBulletPrefab;
    private Queue<GameObject> playerBullets;
    private GameObject playerBullet;
    private const int playerBulletCount = 10;
    private const float fireTime = 0.25f;
    private float nextFire = 0f;

    public GameObject EnemyBulletPrefab;
    private Queue<GameObject> enemyBullets;
    private GameObject enemyBullet;
    private const int enemyBulletCount = 50;

    private void Start()
    {
        playerBullets = new Queue<GameObject>();
        enemyBullets = new Queue<GameObject>();

        for (int i = 0; i < playerBulletCount; i++)
        {
            GameObject PlayerBulletObj = Instantiate(PlayerBulletPrefab) as GameObject;
            PlayerBulletObj.SetActive(false);
            playerBullets.Enqueue(PlayerBulletObj);
        }

        for(int i = 0; i < enemyBulletCount; i++)
        {
            GameObject EnemyBulletObj = Instantiate(EnemyBulletPrefab) as GameObject;
            EnemyBulletObj.SetActive(false);
            enemyBullets.Enqueue(EnemyBulletObj);
        }
    }

    public void SetPlayerBulletOfPositionAndActive(Transform p)
    {
        if (playerBullets.Count > playerBulletCount)
            return;
        if (nextFire < Time.time + fireTime && playerBullets.Count != 0)
        {
            playerBullet = playerBullets.Dequeue();
            playerBullet.SetActive(true);
            playerBullet.transform.position = p.position;
            nextFire = Time.time;
        }
    }

    public IEnumerator SetEnemyBulletOfPositionAndActive(Transform p)
    {
        while (true)
        {
            enemyBullet = enemyBullets.Dequeue();
            enemyBullet.SetActive(true);
            enemyBullet.transform.position = p.position;
            yield return new WaitForSeconds(1);
        }
    }

    public void PlayerBulletsEnqueue(GameObject other)
    {
        playerBullets.Enqueue(other.gameObject);
    }

    public void EnemyBulletsEnqueue(GameObject other)
    {
        enemyBullets.Enqueue(other.gameObject);
    }
}