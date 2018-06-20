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
<<<<<<< HEAD
    [SerializeField]
    PlayerStatus playerStatus;
    bool readyToBombSkill = false;
    
=======


    float time;

    [SerializeField]
    bool readyToBombSkill = true;

<<<<<<< HEAD

=======
=======
    [SerializeField]
    bool readyToBombSkill = true;
>>>>>>> edd095cb5ee9431a1557d974903a1cd0729bfa01
>>>>>>> 0f5d878fab3b5eb3759959908a77774675992a97
>>>>>>> c8af49f0746b4918f788ed0c6fcf62d5dbcd0e64

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
        playerStatus = gameObject.GetComponentInChildren<PlayerStatus>();

        bombSkill = GameObject.Find("GameObjectPool").GetComponent<BombObjectPool>();
        skillAnimator = gameObject.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        //playerState.Behavior();
    }

    private void FixedUpdate()
    {
        playerState.Behavior();

        if (Input.GetKey(KeyCode.Z))
        {
            bulletObjectPool.SetPlayerBulletOfPositionAndActive(bulletSpawn);
        }

        if (Input.GetKeyDown(KeyCode.Space)&& readyToBombSkill)
        {
            Debug.Log("필살기 사용!");

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

<<<<<<< HEAD
=======
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyPlane")
        {
            enemyObjectPool.EnemyPlaneEnqueue(other.gameObject);
            other.gameObject.SetActive(false);
<<<<<<< HEAD

=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
          
=======
>>>>>>> edd095cb5ee9431a1557d974903a1cd0729bfa01
>>>>>>> 0f5d878fab3b5eb3759959908a77774675992a97
>>>>>>> c8af49f0746b4918f788ed0c6fcf62d5dbcd0e64
        }

        if (other.tag == "EnemySpacePlane")
        {
            enemyObjectPool.EnemyPlaneSpaceEnqueue(other.gameObject);
            other.gameObject.SetActive(false);
<<<<<<< HEAD

          
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
          
=======
>>>>>>> edd095cb5ee9431a1557d974903a1cd0729bfa01
>>>>>>> 0f5d878fab3b5eb3759959908a77774675992a97
>>>>>>> c8af49f0746b4918f788ed0c6fcf62d5dbcd0e64
        }

        if(other.tag == "EnemyBullet")
        {
            bulletObjectPool.EnemyBulletsEnqueue(other.gameObject);
            other.gameObject.SetActive(false);
<<<<<<< HEAD

=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
           
=======
>>>>>>> edd095cb5ee9431a1557d974903a1cd0729bfa01
>>>>>>> 0f5d878fab3b5eb3759959908a77774675992a97
>>>>>>> c8af49f0746b4918f788ed0c6fcf62d5dbcd0e64
        }
    }

>>>>>>> 0f5d878fab3b5eb3759959908a77774675992a97
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
