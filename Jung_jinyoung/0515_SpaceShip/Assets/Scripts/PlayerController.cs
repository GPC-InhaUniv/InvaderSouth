using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
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
    
    public float fireRate;
    private float nextFire;
    //public float missileFireRate;
    private float missileNextFire;

    private void Start()
    {
        rigidbodyShip = gameObject.GetComponent<Rigidbody>();
        fireSound = gameObject.GetComponent<AudioSource>();
        //missileShotSpot = shotSpot;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(weapons, shotSpot.position, shotSpot.rotation);
            fireSound.Play();
        }
        if (Input.GetButton("Fire1") && Time.time > missileNextFire)
        {
            //var pos = transform.position;
            //pos.x += 1;
            //transform.position = pos;
            
            //var tmp = missileShotSpot.position;
            //tmp.x = 2;
            //missileShotSpot.position = tmp; //Obviously don't x1 if you really want 1 :)
            //Transform missileTF = shotSpot;
            //missileTF.position.x = shotSpot.position.x;
            //shotSpot.position.x = shotSpot.position.x - 7;
            missileNextFire = Time.time + fireRate * 5;
            Instantiate(missiles, missileShotSpot.position, shotSpot.rotation);
            Instantiate(missiles, missileShotSpot2.position, shotSpot.rotation);
            fireSound.Play();
        }

    }


    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

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
