using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController_jin : MonoBehaviour
{
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject weapons;
    public GameObject missiles;
    public Transform shotSpot;
    public Transform missileShotSpot;
    public Transform missileShotSpot2;
    Rigidbody rigidbodyShip;
    AudioSource fireSound;
    public BombObjectPool BombSkill;
    public float fireRate;
    private float nextFire;
    private float missileNextFire;

    Animator animation;

    private void Awake()
    {
        rigidbodyShip = gameObject.GetComponent<Rigidbody>();
        fireSound = gameObject.GetComponent<AudioSource>();
        BombSkill = GameObject.Find("GameObjectPool").GetComponent<BombObjectPool>();
        animation = GetComponent<Animator>();
        animation.enabled = false;
    }
    private void Update()
    {
        InputManger_test();
    }
    void FixedUpdate()
    {
        MovingShip();
    }
    
    

    private void InputManger_test()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            GunsFire();
        }
        if (Input.GetButton("Fire1") && Time.time > missileNextFire)
        {
            MissilesFire();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BombSkill.StartBombing();
            //animation.enabled = true;
            //animation.SetBool("SkillActive", true);
            //animation.Play(0);
        }
    }
    private void MissilesFire()
    {
        missileNextFire = Time.time + fireRate * 5;
        Instantiate(missiles, missileShotSpot.position, shotSpot.rotation);
        Instantiate(missiles, missileShotSpot2.position, shotSpot.rotation);
        fireSound.Play();
    }

    private void GunsFire()
    {
        nextFire = Time.time + fireRate;
        Instantiate(weapons, shotSpot.position, shotSpot.rotation);
        fireSound.Play();
    }
    private void MovingShip()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //Debug.Log(Input.GetAxis("Vertical"));

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbodyShip.velocity = movement * speed;

        rigidbodyShip.position = new Vector3
        (
            Mathf.Clamp(rigidbodyShip.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbodyShip.position.z, boundary.zMin, boundary.zMax)
        );
        rigidbodyShip.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbodyShip.velocity.x * -tilt);
    }
}
