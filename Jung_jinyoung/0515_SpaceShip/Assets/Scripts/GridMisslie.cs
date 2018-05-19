using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMisslie : MonoBehaviour {
    public Transform target;
    public float speed = 15f;
    public float rotateSpeed = 5;
    //bool ifTarget = false;
    Rigidbody rb;
    
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
    //Update is called once per frame
    void Update () {
        //if(!ifTarget)
        //{
        //    rb.transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        //    SetTarget();
        //}
        //else if (ifTarget)
        //{
        //    Vector3 direction = target.position - rb.position;
        //    //direction.Normalize();
        //    Quaternion q = Quaternion.LookRotation(direction);
        //    Quaternion s = Quaternion.Slerp(transform.rotation, q, rotateSpeed * Time.deltaTime);
        //    rb.rotation = s;
        //    rb.transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);

        //}
        
        if (target!=null)
        {
            RuningForEnemy(target);
        }
        else
        {
            SetTarget();
            Debug.Log("settarget "+rb);
            rb.transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }
        Debug.Log(target);
        
    }
    void RuningForEnemy(Transform target)
    {
        Vector3 direction = target.position - rb.position;
        Quaternion q = Quaternion.LookRotation(direction);
        Quaternion s = Quaternion.Slerp(transform.rotation, q, rotateSpeed * Time.deltaTime);
        rb.rotation = s;
        rb.transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        
    }
    public void SetTarget()
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
}
