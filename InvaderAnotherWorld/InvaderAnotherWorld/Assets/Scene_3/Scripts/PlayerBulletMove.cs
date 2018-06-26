using UnityEngine;

public class PlayerBulletMover : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
