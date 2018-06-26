using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin = -6, xMax = 6, zMin = -4, zMax = 8;
}

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 10;
    public float tilit;
    public Boundary boundary;
    public Transform shotSpawn;
    public float fireRate = 0.5f;
    public float nextFire = 0.0f;
    public BulletPool bulletPool;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        bulletPool = GameObject.Find("GameObjectPool").GetComponent<BulletPool>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            bulletPool.Fire(shotSpawn.transform);

        }
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            3.46f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilit);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            Debug.Log("레이저맞음");
        if (other.tag == "SparkBomb")
        {
            Debug.Log("상태이상 걸림");
        }
    }


}
