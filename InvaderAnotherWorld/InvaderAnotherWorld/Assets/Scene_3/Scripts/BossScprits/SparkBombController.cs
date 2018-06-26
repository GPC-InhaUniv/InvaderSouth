
using UnityEngine;

public class SparkBombController : MonoBehaviour
{

    [SerializeField]
    private GameObject particleSystem;
    [SerializeField]
    private ParticleSystem particle;
    [SerializeField]
    private GameObject sparkCapsule;

    private float bombTime;
    private float autoSetActiveFlaseTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        particle.time = 0;
        bombTime = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (4.0f > bombTime)
        {
            bombTime += Time.deltaTime;
        }
        else
        {
            particleSystem.SetActive(true);
            particle.Play();
            sparkCapsule.SetActive(false);
        }

        if (particleSystem.activeInHierarchy)
        {
            autoSetActiveFlaseTime += Time.deltaTime;

        }

        if (autoSetActiveFlaseTime >= 1f)
        {

            autoSetActiveFlaseTime = 0;
            bombTime = 0;
            particle.time = 0;
            particle.Stop();
            particleSystem.SetActive(false);

            EnemyObjectPool.SparkBoms.Enqueue(this.gameObject);

            gameObject.SetActive(false);


        }
    }
}