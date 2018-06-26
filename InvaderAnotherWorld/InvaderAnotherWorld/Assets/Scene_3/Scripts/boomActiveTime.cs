using System.Collections;
using UnityEngine;

public class boomActiveTime : MonoBehaviour
{

    public float lifeTime;

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
