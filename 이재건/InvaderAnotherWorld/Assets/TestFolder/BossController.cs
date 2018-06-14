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
    private GameObject firstSkillRightBullet;
    [SerializeField]
    private GameObject SecondSkillBullet;

    private float firstMissleAngle;
    private float secondMissleAngle;


    [SerializeField]
    private Transform shotposition;

    private float firstFireTime = 10.0f;
    private float secondFireTime = 15.0f;
    private float firstFiredelayTime = 10.0f;
    private float secondFiredelayTime = 15.0f;

    //just for text
    //private float firstFireTime = 1.0f;
    //private float secondFireTime = 5.0f;
    //private float firstFiredelayTime = 1.0f;
    //private float secondFiredelayTime = 5.0f;

    private bool isUseSkill;
    private BossState bossstate;

    private BossBulletPool bossBulletPool;


    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        bossBulletPool = GameObject.Find("GameObjectPool").GetComponent<BossBulletPool>();

        isUseSkill = false;
        bossstate = BossState.alive;
        firstMissleAngle = 30.0f;
        secondMissleAngle = 45.0f;
        firstFiredelayTime = Time.time + firstFireTime;
         secondFiredelayTime = Time.time + secondFireTime;
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
                bossBulletPool.FireNormalBullet(shotposition.transform);
                yield return new WaitForSeconds(0.8f);
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
        bossBulletPool.FireSecondBullet(shotposition.transform, firstMissleAngle);
    }

    void UseSecondSkill()
    {
        bossBulletPool.FireThirdBullet(shotposition.transform, 0);
        bossBulletPool.FireThirdBullet(shotposition.transform, -secondMissleAngle);
        bossBulletPool.FireThirdBullet(shotposition.transform, secondMissleAngle);


    }


}
