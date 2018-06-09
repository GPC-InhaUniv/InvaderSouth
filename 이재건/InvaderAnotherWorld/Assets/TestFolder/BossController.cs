using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossState
{
    alive,
    dead,
}
public class BossController : MonoBehaviour
{

    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject firstSkillLeftBullet;
    [SerializeField]
    private GameObject firstSkillRightBullet;
    [SerializeField]
    private GameObject SecondSkillBullet;

    [SerializeField]
    private Transform shotposition;

    private float firstFireTime = 10.0f;
    private float secondFireTime = 15.0f;
    private float firstFiredelayTime = 10.0f;
    private float secondFiredelayTime = 15.0f;
    private bool isUseSkill;
    private BossState bossstate;

    

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        isUseSkill = false;
        bossstate = BossState.alive;

        StartCoroutine(BossNormalAttack());
    }

    IEnumerator BossNormalAttack()
    {
        while (BossState.alive.Equals(bossstate))
        {
            if (isUseSkill)
            {
                yield return new WaitForSeconds(2.5f);
                isUseSkill = false;

            }
            else
            {
                Instantiate(bullet, new Vector3(shotposition.transform.position.x, 3.6f, shotposition.transform.position.z), bullet.transform.rotation);
                yield return new WaitForSeconds(1.0f);
            }



        }

    }
    private void Update()
    {
        if (bossstate.Equals(BossState.alive))
        {

            if (Time.time > firstFiredelayTime && !isUseSkill)
            {
                isUseSkill = true;
                UseFirstSkill();
                firstFiredelayTime = Time.time + firstFireTime;
            }
            else if (Time.time > secondFiredelayTime && !isUseSkill)
            {
                isUseSkill = true;
                UseSecondSkill();
                secondFiredelayTime = Time.time + secondFireTime;
            }


        }
    }

    void UseFirstSkill()
    {
        Instantiate(firstSkillLeftBullet, new Vector3(shotposition.transform.position.x - 1f, 3.6f, shotposition.transform.position.z), firstSkillLeftBullet.transform.rotation);

        Instantiate(firstSkillRightBullet, new Vector3(shotposition.transform.position.x + 1f, 3.6f, shotposition.transform.position.z), firstSkillRightBullet.transform.rotation);

    }

    void UseSecondSkill()
    {
        Instantiate(SecondSkillBullet, new Vector3(shotposition.transform.position.x - 1f, 3.6f, shotposition.transform.position.z), Quaternion.Euler(0, 0, 0));

    }


}
