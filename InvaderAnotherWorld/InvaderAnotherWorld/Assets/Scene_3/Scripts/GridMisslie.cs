using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMisslie : MonoBehaviour {

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed = 15f;
    [SerializeField]
    private float rotateSpeed = 5;
    //bool ifTarget = false;
    Rigidbody rb;

    [SerializeField]
    private float autoActiveFalseTime;
    [SerializeField]
    private float aliveMissleTime;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        autoActiveFalseTime = 2f;
        aliveMissleTime = 0f;
    }
    private void Update()
    {
        if (aliveMissleTime > autoActiveFalseTime)
        {
            Initialize();
            EnqueueAndSetActiveToObject();
        }
        else
            aliveMissleTime += Time.deltaTime;
    }
    void FixedUpdate ()
    {
        if (target!=null)
        {
            RuningToEnemy(target);
        }
        else
        {
            SetTarget();
            rb.transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
    }
    void RuningToEnemy(Transform target)
    {
        Vector3 direction = target.position - rb.position;
        Quaternion q = Quaternion.LookRotation(direction);
        Quaternion s = Quaternion.Slerp(transform.rotation, q, rotateSpeed * Time.deltaTime);
        rb.rotation = s;
        rb.transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        Debug.Log(direction);
        //rb.transform.position = Vector3.Lerp(rb.transform.position, target.transform.position, speed * Time.deltaTime);
    }
    void SetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            float distance = Mathf.Infinity;
            //for돌리고 if로 다음배열로 넘김//
            foreach (GameObject enemy in enemys)
            {
                Vector3 diff = enemy.transform.position - rb.position;
                float curDistance = diff.sqrMagnitude;

                if (curDistance < distance)
                {
                    target = enemy.transform;
                    distance = curDistance;
                }
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("적과 충돌");
            Initialize();
            EnqueueAndSetActiveToObject();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            Debug.Log("바운더리 충돌");
            Initialize();
            EnqueueAndSetActiveToObject();
        }
    }
    public void Initialize()
    {
        aliveMissleTime = 0.0f;
        target = null;
    }
    void EnqueueAndSetActiveToObject()
    {
        PetObjectPool.PetMissilesEnqueue(gameObject);
        gameObject.SetActive(false);
    }
}
