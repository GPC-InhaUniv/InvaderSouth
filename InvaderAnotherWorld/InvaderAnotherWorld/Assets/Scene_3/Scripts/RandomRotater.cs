using UnityEngine;

public class RandomRotater : MonoBehaviour
{

    public Rigidbody rb;
    public float tumble;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }

}
