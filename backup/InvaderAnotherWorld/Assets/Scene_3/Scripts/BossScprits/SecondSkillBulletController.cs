using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSkillBulletController : MonoBehaviour
{

    private Rigidbody rigidbody;
    private float speed;
    [SerializeField]
    private GameObject warningPlane;
    [SerializeField]
    private GameObject lazerObject;
    private float moveFowardTime = 0;
    private float lazerRateTime = 0f;
    private float warningTime = 0f;
    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        speed = 1.0f;

    }

    public void Initialize()
    {
        lazerRateTime = 0f;
        warningTime = 0f;
        moveFowardTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (2.5f > moveFowardTime)
        {
            moveFowardTime += Time.deltaTime;
            rigidbody.transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }
        else if (!warningPlane.activeInHierarchy&&warningTime<1f)
        {
            warningPlane.SetActive(true);
           
        }
        else if (warningPlane.activeInHierarchy&&!lazerObject.activeInHierarchy)
        {
            warningTime += Time.deltaTime;
            if (warningTime > 2.0f)
            {
                warningPlane.SetActive(false);
                lazerObject.SetActive(true);
            }
        }
        else if (lazerObject.activeInHierarchy)
        {
            lazerRateTime += Time.deltaTime;
            if (lazerRateTime > 3.0f)
            {
                Initialize();
                gameObject.SetActive(false);
                lazerObject.SetActive(false);
                BossEnemyPool.BossThirdMissiles.Enqueue(gameObject);
                
            }


        }

    }
}