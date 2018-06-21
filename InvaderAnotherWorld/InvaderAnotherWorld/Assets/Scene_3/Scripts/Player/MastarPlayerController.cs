using System.Collections;
using System.Collections.Generic;
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
    private bool isGameOver;
    public bool IsGameOver
    {
        get { return isGameOver; }
        private set { }
    }

    //스킬 풀, 스킬애니메이션
    [SerializeField]
    private BombObjectPool bombSkill;
    [SerializeField]
    Animator skillAnimator;

    [SerializeField]
    PlayerStatus playerStatus;

    [SerializeField]
    ParticleSystem attacedEffect;

    private void Awake()
    {
        playerStatusComponent = GetComponent<PlayerStatus>();
        mastarBoundary = new MastarBoundary(6, -6, 8, -4);
        playerState = new LivingState();
        bulletSpawn = GameObject.Find("BoltSpawn").GetComponentInChildren<Transform>();
        playerMeshCollider = this.GetComponentInChildren<MeshCollider>();
        playerMeshRenderer = this.GetComponentInChildren<MeshRenderer>();
        rigidbody3D = this.gameObject.GetComponent<Rigidbody>();
        bulletObjectPool = GameObject.Find("GameObjectPool").GetComponent<BulletObjectPool>();
        enemyObjectPool = GameObject.Find("GameObjectPool").GetComponent<EnemyObjectPool>();
        
        

        bombSkill = GameObject.Find("GameObjectPool").GetComponent<BombObjectPool>();
        skillAnimator = gameObject.GetComponentInChildren<Animator>();

        playerStatus = gameObject.GetComponentInChildren<PlayerStatus>();

        attacedEffect = gameObject.GetComponentInChildren<ParticleSystem>();
        
    }
    
    private void FixedUpdate()
    {
        playerState.Behavior();

        if (Input.GetKey(KeyCode.Z))
        {
            bulletObjectPool.SetPlayerBulletOfPositionAndActive(bulletSpawn);
        }

        if (Input.GetKeyDown(KeyCode.Space)&& playerStatus.SkillAmount>=1.0f)
        {
            Debug.Log("필살기 사용!");
            playerStatus.SkillAmount = 0f;
            skillAnimator.Play("SkillAnim");
            bombSkill.StartBombing();
            

            SetState(new InvincibilityState());
            Invoke("SetMeshCollider", 1.2f);
        }

        if(isGameOver != true)
        {
            if (playerStatusComponent.PlayerHp <= 0)
            {
                SetState(new DeadState());
                playerMeshRenderer.enabled = false;
                playerMeshCollider.enabled = false;
                isGameOver = true;
                Debug.Log("플레이어 죽음");
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
}
