using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float rotateSpeed = 5.0f;
    public float autoActiveFalseTime;
    public float aliveMissleTime;
    // Use this for initialization

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        autoActiveFalseTime = 2.0f;
        aliveMissleTime = 0.0f;

    }

    public void Initialize()
    {
        aliveMissleTime = 0.0f;
        gameObject.transform.rotation = Quaternion.identity;
        gameObject.transform.position = new Vector3(0, 0, 0);
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            RuningForEnemy(target);
        }
        else
        {
            SetTarget();
            rb.transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }

        if (aliveMissleTime > autoActiveFalseTime)
        {
            Initialize();
            BossEnemyPool.BossNormalbullets.Enqueue(this.gameObject);
            gameObject.SetActive(false);
        }
        else
            aliveMissleTime += Time.deltaTime;
    }

    void RuningForEnemy(Transform target)
    {
        Vector3 direction = -(target.position - rb.position);
        Quaternion q = Quaternion.LookRotation(direction);
        Quaternion s = Quaternion.Slerp(transform.rotation, q, rotateSpeed * Time.deltaTime);
        rb.rotation = s;
        rb.transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);

    }
    public void SetTarget()
    {

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            float distance = Mathf.Infinity;

            Vector3 diff = player.transform.position - rb.position;
            float curDistance = diff.sqrMagnitude;

            if (curDistance < distance)
            {
                target = player.transform;
                distance = curDistance;
            }

        }
    }

}
