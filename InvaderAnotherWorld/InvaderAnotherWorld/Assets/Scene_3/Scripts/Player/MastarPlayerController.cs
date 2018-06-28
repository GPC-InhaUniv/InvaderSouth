using System.Collections;
using UnityEngine;

public struct MastarBoundary
{
    public float boundaryXMax;
    public float boundaryXMin;
    public float boundaryZMax;
    public float boundaryZMin;

    public MastarBoundary(float XMax, float XMin, float ZMax, float ZMin)
    {
        boundaryXMax = XMax;
        boundaryXMin = XMin;
        boundaryZMax = ZMax;
        boundaryZMin = ZMin;
    }
}

public class MastarPlayerController : MonoBehaviour
{
    [SerializeField]
    private MastarBoundary mastarBoundary;
    private MeshCollider playerMeshCollider;
    private MeshRenderer playerMeshRenderer;
    private Transform bulletSpawn;
    private BulletObjectPool bulletObjectPool;
    private Rigidbody rigidbody3D;
    private EnemyObjectPool enemyObjectPool;
    private PlayerStatus playerStatusComponent;
    private IState playerState;
    

    public bool IsGameResult;


    public delegate void GameResult(bool isGameResult);
    public GameResult GameResultDelegate;


    //스킬 풀, 스킬애니메이션
    [SerializeField]
    private BombObjectPool bombSkill;
    [SerializeField]
    Animator skillAnimator;

    [SerializeField]
    PlayerStatus playerStatus;

    [SerializeField]
    ParticleSystem attacedEffect;

    [SerializeField]
    AudioClip fireClip;
    AudioSource fireAudio;



    private void Awake()
    {
        IsGameResult = true;
        playerStatusComponent = GetComponent<PlayerStatus>();
        //수정
        mastarBoundary = new MastarBoundary(6, -5, 12, -1);
        playerState = new LivingState();
        bulletSpawn = GameObject.Find("BoltSpawn").GetComponentInChildren<Transform>();
        playerMeshCollider = this.transform.Find("PlayerShip").GetComponentInChildren<MeshCollider>();
        playerMeshRenderer = this.transform.Find("PlayerShip").GetComponentInChildren<MeshRenderer>();
        rigidbody3D = this.gameObject.GetComponent<Rigidbody>();
        bulletObjectPool = GameObject.Find("GameObjectPool").GetComponent<BulletObjectPool>();
        enemyObjectPool = GameObject.Find("GameObjectPool").GetComponent<EnemyObjectPool>();

        bombSkill = GameObject.Find("GameObjectPool").GetComponent<BombObjectPool>();
        skillAnimator = gameObject.GetComponentInChildren<Animator>();

        playerStatus = gameObject.GetComponentInChildren<PlayerStatus>();

        attacedEffect = gameObject.GetComponentInChildren<ParticleSystem>();


        //플레이어 공격사운드
        //fireClip = 
        fireAudio = gameObject.AddComponent<AudioSource>();
        fireAudio.loop = false;
        fireAudio.clip = fireClip;

        //fireAudio = gameObject.AddComponent<AudioSource>();
        //fireAudio.loop = false;
        //fireAudio.clip = fireClip;

        //모바일 버전 공격
        StartCoroutine(MobileAttack());

    }
    IEnumerator MobileAttack()
    {
        yield return 1f;

        while(playerStatusComponent.PlayerHp > 0)
        {
            bulletObjectPool.SetPlayerBulletOfPositionAndActive(bulletSpawn);
            yield return new WaitForSeconds(0.4f);
        }
    }

    private void FixedUpdate()
    {

        playerState.Behavior();

        if (Input.GetKey(KeyCode.S))
        {
            bulletObjectPool.SetPlayerBulletOfPositionAndActive(bulletSpawn);
            //fireAudio.PlayOneShot(fireClip);
        }

       
        if (Input.GetKeyDown(KeyCode.Space) && playerStatus.SkillAmount >= 1.0f)
        {
            Debug.Log("필살기 사용!");
            playerStatus.SkillAmount = 0f;
            skillAnimator.Play("SkillAnim");
            bombSkill.StartBombing();


            SetState(new InvincibilityState());
            Invoke("SetMeshCollider", 1.2f);
        }

        if (IsGameResult == true)
        {
            GameResultDelegate(IsGameResult);

            if (playerStatusComponent.PlayerHp <= 0)
            {
                SetState(new DeadState());
                playerMeshRenderer.enabled = false;
                playerMeshCollider.enabled = false;
                IsGameResult = false;
                GameResultDelegate(IsGameResult);
                //Debug.Log("플레이어 죽음");
            }
        }

        // 플레이어가 화면 밖으로 나가는 것을 방지.
        rigidbody3D.position = new Vector3
        (
            Mathf.Clamp(rigidbody3D.position.x, mastarBoundary.boundaryXMin, mastarBoundary.boundaryXMax),
            0.0f,
            Mathf.Clamp(rigidbody3D.position.z, mastarBoundary.boundaryZMin, mastarBoundary.boundaryZMax)
        );
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            playerStatusComponent.Damaged();
        }

        if (other.tag == "EnemyBullet")
        {
            playerStatusComponent.Damaged();
            BulletObjectPool.enemyBullets.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);

            attacedEffect.Play(true);
        }

        if (other.tag == "SparkBomb")
        {
            StartCoroutine(SetSlowState());
        }

        if (other.tag == "BossSmallBullet")
        {
            playerStatusComponent.Damaged();
            BossEnemyPool.BosssmallBullets.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }

        if (other.tag == "BossNormalBullet")
        {
            playerStatusComponent.Damaged();
            BossEnemyPool.BossNormalbullets.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);
        }

    }

    private void SetState(IState state)
    {
        this.playerState = state;
    }

    private void SetMeshCollider()
    {
        playerMeshCollider.enabled = true;
        SetState(new LivingState());
    }


    private IEnumerator SetSlowState()
    {
        playerState = new SlowState();
        yield return new WaitForSeconds(3f);
        playerState = new LivingState();
    }

    public void UseSkill()
    {
        if (playerStatus.SkillAmount >= 1.0f)
        {
          //  Debug.Log("필살기 사용!");
            playerStatus.SkillAmount = 0f;
            skillAnimator.Play("SkillAnim");
            bombSkill.StartBombing();


            SetState(new InvincibilityState());
            Invoke("SetMeshCollider", 1.2f);
        }
    }
}
