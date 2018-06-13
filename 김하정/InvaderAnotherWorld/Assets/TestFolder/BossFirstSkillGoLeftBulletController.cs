using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFirstSkillGoLeftBulletController : MonoBehaviour {

    [SerializeField]
    private GameObject smallBullet;
    private Rigidbody rigidbody;

    private float radius = 0.05f;
    private float runningTime = 0;
    private float speed = 1.0f;
    private int smallBulletCount = 0;
    private bool IsFinishMakeCircle;
    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(StartSperate());

    }
	IEnumerator StartSperate()
    {
        yield return new WaitForSeconds(5.0f);
        IsFinishMakeCircle = false;
        speed = 0.0f;
        runningTime = 0.0f;
        while(!IsFinishMakeCircle)
        {
            runningTime +=Time.deltaTime+10.0f;
            float x =radius * Mathf.Sin(runningTime);
            Instantiate(smallBullet, new Vector3(x+transform.position.x, 3.6f,transform.position.z ), Quaternion.Euler(0,runningTime,0));
            smallBulletCount++;
            if (smallBulletCount >= 60)
            {
                IsFinishMakeCircle = true;
                this.gameObject.SetActive(false);
                yield return null;
            }
            else
                yield return new WaitForSeconds(0.1f);
        }
        yield return null;

    }

    private void FixedUpdate()
    {
        rigidbody.transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
    }

}
