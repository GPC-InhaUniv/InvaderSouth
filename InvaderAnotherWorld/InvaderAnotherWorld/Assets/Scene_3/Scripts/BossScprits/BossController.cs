using System.Collections;
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

    //[SerializeField]
    //private Image bossHpImage;
    public float BossHp = 30;
    public static bool IsBossAlive = true;

    //[SerializeField]
    //private Image bossHpImage;


    [SerializeField]
    private Transform shotposition;

    private float firstFireTime = 10.0f;
    private float secondFireTime = 15.0f;
    private float firstFiredelayTime = 10.0f;
    private float secondFiredelayTime = 15.0f;
    private bool isUseSkill;
    private BossState bossstate;
    private bool isAttackPlayerSkill = false;
    private float skillAttackedTimer = 0.0f;
    private BossEnemyPool bossEnemyPool;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        bossEnemyPool = GameObject.Find("GameObjectPool").GetComponent<BossEnemyPool>();
        //bossHpImage.fillAmount = BossHp / 30.0f;

        isUseSkill = false;
        bossstate = BossState.alive;
        firstMissleAngle = 30.0f;
        secondMissleAngle = 45.0f;
        firstFiredelayTime = Time.time + firstFireTime;
        secondFiredelayTime = Time.time + secondFireTime;
        StartCoroutine(MoveAfterGenerate());
        StartCoroutine(BossNormalAttack());
    }

    IEnumerator MoveAfterGenerate()
    {
        while (this.transform.position.z >= 12)
        {
            transform.Translate(new Vector3(0, 0, 1) * 0.01f);
            yield return new WaitForEndOfFrame();
        }

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
                bossEnemyPool.FireNormalBullet(shotposition.transform);
                yield return new WaitForSeconds(0.8f);
            }
        }

    }

    private void Update()
    {
        if (bossstate.Equals(BossState.alive))
        {
            UseSkill();
        }
    }

    void UseSkill()
    {
        if (Time.time > firstFiredelayTime && !isUseSkill)
        {
            UseFirstSkill();
        }
        else if (Time.time > secondFiredelayTime && !isUseSkill)
        {
            UseSecondSkill();
        }
        //수정
        if (isAttackPlayerSkill)
        {
            skillAttackedTimer += Time.deltaTime;
            if (skillAttackedTimer >= 2.0f)
            {
                skillAttackedTimer = 0;
                isAttackPlayerSkill = false;
            }
        }

    }

    void UseFirstSkill()
    {
        bossEnemyPool.FireSecondBullet(shotposition.transform, firstMissleAngle);
        firstFiredelayTime = Time.time + firstFireTime;
        isUseSkill = true;
    }

    void UseSecondSkill()
    {
        bossEnemyPool.FireThirdBullet(shotposition.transform, 0);
        bossEnemyPool.FireThirdBullet(shotposition.transform, -secondMissleAngle);
        bossEnemyPool.FireThirdBullet(shotposition.transform, secondMissleAngle);
        secondFiredelayTime = Time.time + secondFireTime;
        isUseSkill = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌");
        if (other.tag == "PlayerBullet")
        {
            BossHp -= 1;
            //bossHpImage.fillAmount = BossHp / 30;
            BulletObjectPool.playerBullets.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);

            if (BossHp <= 0)
            {
                IsBossAlive = false;
                BossEnemyPool.BossObjects.Enqueue(this.gameObject);
                this.gameObject.SetActive(false);
            }
        }

        //수정
        if (other.tag == "Bomb" && !isAttackPlayerSkill)
        {
            BossHp -= 5;
            isAttackPlayerSkill = true;
            if (BossHp <= 0)
            {
                IsBossAlive = false;
                BossEnemyPool.BossObjects.Enqueue(this.gameObject);
                this.gameObject.SetActive(false);
            }
        }
    }


}
