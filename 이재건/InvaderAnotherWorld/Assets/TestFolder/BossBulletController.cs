using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : MonoBehaviour {
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float rotateSpeed = 5.0f;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody>();
        SetTarget();

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
            //Debug.Log("settarget "+rb);
            rb.transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }

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
