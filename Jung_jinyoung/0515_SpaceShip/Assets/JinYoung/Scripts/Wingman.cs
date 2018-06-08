using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wingman : MonoBehaviour {
    public float moveStartDistance;
    public float rangeZ;
    public float speed;

    //Rigidbody rigidbody;
    Vector3 wingManPosition;
    Vector3 targetPosition;

    //float targetPointX;
    //bool facingRight = true;
    public float fireRate;
    private float nextFire;
    private float missileNextFire;
    public GameObject missiles;


    // Use this for initialization
    void Start () {
        //rigidbody = GetComponent<Rigidbody>();
        wingManPosition = transform.position;
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        //Vector3 screen_point = Camera.main.WorldToScreenPoint(transform.position);
        //targetPointX = screen_point.x;
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
        else
        {
            targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            wingManPosition = targetPosition;
            wingManPosition.z -= rangeZ;
        }
        
        //wingManPosition = targetPosition;
        //transform.position = targetPosition;

        if (Time.time > missileNextFire)
        {
            MissilesFire();
        }

    }

    // Update is called once per frame
    void FixedUpdate () {
        
        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, wingManPosition, speed * Time.deltaTime);
        //Debug.Log(wingManPosition);
        //Debug.Log(targetPosition);
        //Debug.Log("MoveToPlayer");
        
    }
    private void MissilesFire()
    {
        missileNextFire = Time.time + fireRate * 5;
        Instantiate(missiles, transform.position, transform.rotation);
        //fireSound.Play();
    }
}
