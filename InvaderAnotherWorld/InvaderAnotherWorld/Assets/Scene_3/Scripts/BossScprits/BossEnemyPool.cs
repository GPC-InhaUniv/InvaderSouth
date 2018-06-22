using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyPool : MonoBehaviour
{
    [SerializeField]
    private GameObject bossObject;
    private int bossObjectAmount = 1;
    public static Queue<GameObject> BossObjects;
    GameObject tempBoss;


    [SerializeField]
    private GameObject bossNormalBullet;
    private int NormalBulletCount = 15;
    public static Queue<GameObject> BossNormalbullets;
    GameObject tempBullet;

    [SerializeField]
    private GameObject bossSecondLeftMissile;
    private int secondLeftMissileCount = 10;
    public static Queue<GameObject> BossSecondLeftMissiles;
    GameObject tempSecondLeftMissile;

    [SerializeField]
    private GameObject bossSecondRightMissile;
    private int secondRightMissileCount = 10;
    public static Queue<GameObject> BossSecondRightMissiles;
    private GameObject tempSecondRightMissile;

    [SerializeField]
    private GameObject bossThirdMissile;
    private int thirdMissileCount = 3;
    public static Queue<GameObject> BossThirdMissiles;
    private GameObject tempThirdMissile;

    [SerializeField]
    private GameObject bosssmallBullet;
    private int bosssmallBulletCount = 100;
    public static Queue<GameObject> BosssmallBullets;
    private GameObject tempbosssmallBullet;

    [SerializeField]
    private GameObject parent;

    private BossBulletController bossBulletController;
    private BossFirstSkillGoLeftBulletController bossFirstSkillGoLeftBullet;
    private BossFirstSkillGoRightBulletController bossFirstSkillGoRightBulletController;

    // Use this for initialization
    void Start()
    {
        GameObject obj;

        BossObjects = new Queue<GameObject>();
        obj = Instantiate(bossObject);
        obj.transform.parent = parent.transform;
        obj.SetActive(false);
        BossObjects.Enqueue(obj);

        BossNormalbullets = new Queue<GameObject>();
        for (int i = 0; i < NormalBulletCount; i++)
        {
            obj = Instantiate(bossNormalBullet);
            obj.transform.parent = parent.transform;
            obj.SetActive(false);
            BossNormalbullets.Enqueue(obj);

        }

        BossSecondLeftMissiles = new Queue<GameObject>();
        for (int i = 0; i < secondLeftMissileCount; i++)
        {
            obj = Instantiate(bossSecondLeftMissile);
            obj.transform.parent = parent.transform;
            obj.SetActive(false);
            BossSecondLeftMissiles.Enqueue(obj);

        }

        BossSecondRightMissiles = new Queue<GameObject>();
        for (int i = 0; i < secondRightMissileCount; i++)
        {
            obj = Instantiate(bossSecondRightMissile);
            obj.transform.parent = parent.transform;
            obj.SetActive(false);
            BossSecondRightMissiles.Enqueue(obj);

        }

        BossThirdMissiles = new Queue<GameObject>();
        for (int i = 0; i < thirdMissileCount; i++)
        {
            obj = Instantiate(bossThirdMissile);
            obj.transform.parent = parent.transform;
            obj.SetActive(false);
            BossThirdMissiles.Enqueue(obj);

        }

        BosssmallBullets = new Queue<GameObject>();
        for (int i = 0; i < bosssmallBulletCount; i++)
        {
            obj = Instantiate(bosssmallBullet);
            obj.transform.parent = parent.transform;
            obj.SetActive(false);
            BosssmallBullets.Enqueue(obj);
        }


    }
    public void FireNormalBullet(Transform transform)
    {

        tempBullet = BossNormalbullets.Dequeue();
        tempBullet.SetActive(true);
        tempBullet.transform.position = transform.position;
    }

    public void FireSecondBullet(Transform transform, float Angle)
    {
        tempSecondLeftMissile = BossSecondLeftMissiles.Dequeue();
        tempSecondRightMissile = BossSecondRightMissiles.Dequeue();
        tempSecondLeftMissile.SetActive(true);
        tempSecondRightMissile.SetActive(true);

        tempSecondLeftMissile.transform.position = transform.position;
        tempSecondLeftMissile.transform.rotation = Quaternion.Euler(0, Angle, 0);
        tempSecondRightMissile.transform.position = transform.position;
        tempSecondRightMissile.transform.rotation = Quaternion.Euler(0, -Angle, 0);
    }

    public void FireThirdBullet(Transform transform,float Angle)
    {
        tempThirdMissile = BossThirdMissiles.Dequeue();
        tempThirdMissile.SetActive(true);
        tempThirdMissile.transform.position = transform.position;
        tempThirdMissile.transform.rotation = Quaternion.Euler(0, Angle, 0);



    }

    public void FireSmallBullet(Transform transform, float Angle)
    {
        tempbosssmallBullet = BosssmallBullets.Dequeue();
        tempbosssmallBullet.SetActive(true);
        tempbosssmallBullet.transform.position = transform.position;
        tempbosssmallBullet.transform.rotation = Quaternion.Euler(0, Angle, 0);
    }

    public void GenerateBoss(Transform transform)
    {
        tempBoss = BossObjects.Dequeue();
        tempBoss.SetActive(true);
        tempBoss.transform.position = transform.position;
        tempBoss.transform.rotation = Quaternion.identity;
    }


    public void WithdrawNormalBullet()
    {

    }
}
