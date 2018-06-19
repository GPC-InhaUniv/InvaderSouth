using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wingman : MonoBehaviour {
    private float moveStartDistance = 2f;
    private float rangeZ = 1f;

    private float speed = 10f;

    //Rigidbody rigidbody;
    Vector3 wingManPosition;
    Vector3 targetPosition;

    //float targetPointX;
    //bool facingRight = true;
    public float fireRate = 3f;
    private float nextFire;
    private float missileNextFire =0;
    //public GameObject missiles;
    //private MissileObjectPool missileObjectPool;

    private GameObject Player;
    private Transform PetObject;
    private Quaternion rotateVelue;
    private Quaternion petObjectRotateVelue;

    PetObjectPool petObjectPool;

    // Use this for initialization
    void Start () {
        //rigidbody = GetComponent<Rigidbody>();
        wingManPosition = transform.position;
        Player = GameObject.FindGameObjectWithTag("Player");
        PetObject = transform.GetChild(0);

        petObjectPool = GameObject.Find("GameObjectPool").GetComponent<PetObjectPool>();
        Debug.Log(PetObject.ToString());

        //targetPosition = target.transform.position;

        //Vector3 screen_point = Camera.main.WorldToScreenPoint(transform.position);
        //targetPointX = screen_point.x;
    }

    void Update()
    {
        
        if (Player == null)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
        else 
        {
            targetPosition = Player.transform.position;
            wingManPosition = targetPosition;
            wingManPosition.z = targetPosition.z - rangeZ;
            if (Player.transform.position.x > 1)
            {
                //rotateVelue = new Vector3(0, 0, 0);
                rotateVelue = Quaternion.Euler(new Vector3(0, 0, 0));
                petObjectRotateVelue = Quaternion.Euler(new Vector3(0, 0, 0));
                //rotateVelue = Player.transform.rotation;

                //transform.Rotate(new Vector3(0, 0, 0) * Time.deltaTime * speed);
                //transform.Rotate(new Vector3(0,0,0),Space.Self);
            }
            else if (Player.transform.position.x < -1)
            {
                rotateVelue = Quaternion.Euler(new Vector3(0, 180f, 0));
                petObjectRotateVelue = Quaternion.Euler(new Vector3(0, 0, 0));
                //rotateVelue = Player.transform.rotation;
                //transform.Rotate(new Vector3(0, -180, 0)*Time.deltaTime*speed);
                //transform.rotation = Vector3.right.y
            }
            //else
            //{
            //    wingManPosition = targetPosition;
            //    wingManPosition.z -= rangeX;
            //}

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
        transform.position = Vector3.Lerp(transform.position, wingManPosition, 2*speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateVelue, (speed * Time.deltaTime)/speed);
        //PetObject.rotation = Quaternion.Slerp(PetObject.rotation, petObjectRotateVelue, speed * Time.deltaTime);
        PetObject.rotation = petObjectRotateVelue;
        Debug.Log(petObjectRotateVelue);
        //transform.rotation = 

        //Debug.Log(wingManPosition);
        //Debug.Log(targetPosition);
        //Debug.Log("MoveToPlayer");

    }
    private void MissilesFire()
    {
        missileNextFire = Time.time + fireRate;
        petObjectPool.SetPetMissileOfPositionAndActive(PetObject.transform);
    }
}
