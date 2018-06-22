using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomActiveTime : MonoBehaviour {

    public float lifeTime;
    // Use this for initialization
    //void Start()
    //{
    //    //Destroy(gameObject, lifeTime);
    //    //gameObject.SetActive(true);
        
    //}
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(exobjSetActive());
        }
    }


    IEnumerator exobjSetActive()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            BulletObjectPool.enemyBullets.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }
}
