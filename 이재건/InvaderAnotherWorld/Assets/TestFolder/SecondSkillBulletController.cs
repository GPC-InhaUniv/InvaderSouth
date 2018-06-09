using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSkillBulletController : MonoBehaviour {

    private Rigidbody rigidbody;
    private float speed;
    [SerializeField]
    private GameObject warningPlane;
    [SerializeField]
    private GameObject lazerObject;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        speed = 1.0f;
        StartCoroutine(StartSecondSkill());
	}
	IEnumerator StartSecondSkill()
    {
        yield return new WaitForSeconds(2.0f);
        speed = 0.0f;
        warningPlane.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        warningPlane.SetActive(false);
        lazerObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        lazerObject.SetActive(false);
        this.gameObject.SetActive(false);
        yield return null;
     

    }
	// Update is called once per frame
	void Update () {
        rigidbody.transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
    }
}
