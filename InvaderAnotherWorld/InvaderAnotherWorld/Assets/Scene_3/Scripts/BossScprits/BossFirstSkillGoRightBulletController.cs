using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFirstSkillGoRightBulletController : MonoBehaviour
{

    [SerializeField]
    private GameObject smallBullet;
    private Rigidbody rigidbody;

    private float radius = 0.05f;
    private float runningTime = 0;
    private float speed = 1.0f;
    private int smallBulletCount = 0;
    private bool IsFinishMakeCircle;
    private GameObject tempbosssmallBullet;

    private float moveFowardTime = 0;
    private float fireRate = 0f;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        smallBulletCount = 0;
        speed = 1.0f;
        runningTime = 0;
    }

    public void Initialize()
    {
        smallBulletCount = 0;
        speed = 1.0f;
        runningTime = 0;
        fireRate = 0f;
        moveFowardTime = 0;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    private void FixedUpdate()
    {
        if (3.0f > moveFowardTime)
        {
            moveFowardTime += Time.deltaTime;
            rigidbody.transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }
        else if (fireRate > 0.1f)
        {
            runningTime += Time.deltaTime + 10.0f;
            float x = radius * Mathf.Sin(runningTime);

            tempbosssmallBullet = BossEnemyPool.BosssmallBullets.Dequeue();
            tempbosssmallBullet.SetActive(true);

            tempbosssmallBullet.transform.position = new Vector3(x + transform.position.x, 0, transform.position.z);
            tempbosssmallBullet.transform.rotation = Quaternion.Euler(0, -runningTime, 0);

            smallBulletCount++;
            if (smallBulletCount >= 40)
            {
                Initialize();
                BossEnemyPool.BossSecondRightMissiles.Enqueue(gameObject);
                gameObject.SetActive(false);

            }
            fireRate = 0;
        }

        fireRate += Time.deltaTime;
    }
}


