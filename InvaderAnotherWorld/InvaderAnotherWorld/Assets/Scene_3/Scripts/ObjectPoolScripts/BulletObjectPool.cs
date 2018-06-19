using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerBulletPrefab;
    private Queue<GameObject> playerBullets;
    private GameObject playerBullet;
    private const int playerBulletCount = 10;
    private const float fireTime = 0.25f;
    private float nextFire = 0f;

    [SerializeField]
    private GameObject EnemyBulletPrefab;
    private Queue<GameObject> enemyBullets;
    private GameObject enemyBullet;
    private const int enemyBulletCount = 50;

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
        if (nextFire < Time.time + fireTime && playerBullets.Count != 0)
        {
            playerBullet = playerBullets.Dequeue();
            playerBullet.SetActive(true);
            playerBullet.transform.position = transform.position;
            nextFire = Time.time;
        }
    }

<<<<<<< HEAD:InvaderAnotherWorld/InvaderAnotherWorld/Assets/UnitTestFolder/KyungTae/Scripts/Objectpool Pattern/BulletObjectPool.cs
    public void SetEnemyBulletOfPositionAndActive(Transform p)
=======
    public IEnumerator SetEnemyBulletOfPositionAndActive(Transform transform)
>>>>>>> 66acb102c810a0ae19e2601e7c4a7e5d2cbae1b1:InvaderAnotherWorld/InvaderAnotherWorld/Assets/Scene_3/Scripts/ObjectPoolScripts/BulletObjectPool.cs
    {
            enemyBullet = enemyBullets.Dequeue();
            enemyBullet.SetActive(true);
<<<<<<< HEAD:InvaderAnotherWorld/InvaderAnotherWorld/Assets/UnitTestFolder/KyungTae/Scripts/Objectpool Pattern/BulletObjectPool.cs
            enemyBullet.transform.position = p.position;
=======
            enemyBullet.transform.position = transform.position;
            yield return new WaitForSeconds(1);
        }
>>>>>>> 66acb102c810a0ae19e2601e7c4a7e5d2cbae1b1:InvaderAnotherWorld/InvaderAnotherWorld/Assets/Scene_3/Scripts/ObjectPoolScripts/BulletObjectPool.cs
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