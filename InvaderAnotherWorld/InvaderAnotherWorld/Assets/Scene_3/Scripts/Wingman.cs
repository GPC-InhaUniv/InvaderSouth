using UnityEngine;

public class Wingman : MonoBehaviour
{
    private float moveStartDistance = 2f;
    private float rangeZ = 1f;
    private float speed = 10f;

    Vector3 wingManPosition;
    Vector3 targetPosition;

    public float fireRate = 3f;
    private float nextFire;
    private float missileNextFire = 0;

    private GameObject Player;
    private Transform PetObject;
    private Quaternion rotateVelue;
    private Quaternion petObjectRotateVelue;

    PetObjectPool petObjectPool;

    // Use this for initialization
    void Start()
    {
        wingManPosition = transform.position;
        Player = GameObject.FindGameObjectWithTag("Player");
        PetObject = transform.GetChild(0);

        petObjectPool = GameObject.Find("GameObjectPool").GetComponent<PetObjectPool>();
        //Debug.Log(PetObject.ToString());

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

                rotateVelue = Quaternion.Euler(new Vector3(0, 0, 0));
                petObjectRotateVelue = Quaternion.Euler(new Vector3(0, 0, 0));

            }
            else if (Player.transform.position.x < -1)
            {
                rotateVelue = Quaternion.Euler(new Vector3(0, 180f, 0));
                petObjectRotateVelue = Quaternion.Euler(new Vector3(0, 0, 0));

            }

        }

        if (Time.time > missileNextFire)
        {
            //Debug.Log("미사일이 발사됨");
            MissilesFire();
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        MoveToPlayer();
    }

    void MoveToPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, wingManPosition, 2 * speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateVelue, (speed * Time.deltaTime) / speed);
        PetObject.rotation = petObjectRotateVelue;


    }
    private void MissilesFire()
    {
        missileNextFire = Time.time + fireRate;
        petObjectPool.SetPetMissileOfPositionAndActive(PetObject.transform);
    }
}
