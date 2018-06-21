using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct JinBoundary
{
    public float boundaryXMax;
    public float boundaryXMin;
    public float boundaryZMax;
    public float boundaryZMin;

    public JinBoundary(float XMax, float XMin, float ZMax, float ZMin)
    {
        boundaryXMax = XMax;
        boundaryXMin = XMin;
        boundaryZMax = ZMax;
        boundaryZMin = ZMin;
    }
}

public class PlayerControllerState_Jin : MonoBehaviour
{
    private PlayerStatus playerStatusComponent;
    private JinBoundary jinBoundary;
    private MeshCollider playerMeshCollider;
    private MeshRenderer playerMeshRenderer;
    private Transform bulletSpawn;
    private BulletObjectPool bulletObjectPool;
    private Rigidbody rigidbody3D;
    private EnemyObjectPool enemyObjectPool;
    private IState playerState;
    private bool isGameOver;
    public bool IsGameOver
    {
        get { return isGameOver; }
        private set { }
    }

    private void Awake()
    {
        playerStatusComponent = GetComponent<PlayerStatus>();
        jinBoundary = new JinBoundary(6, -6, 1, -9);
        playerState = new LivingState();
        bulletSpawn = this.transform.Find("BulletSpawn");
        playerMeshCollider = this.GetComponent<MeshCollider>();
        playerMeshRenderer = this.GetComponent<MeshRenderer>();
        rigidbody3D = this.gameObject.GetComponent<Rigidbody>();
        bulletObjectPool = GameObject.FindGameObjectWithTag("ObjectPoolManager").GetComponent<BulletObjectPool>();
        enemyObjectPool = GameObject.FindGameObjectWithTag("ObjectPoolManager").GetComponent<EnemyObjectPool>();
    }

    private void FixedUpdate()
    {
        playerState.Behavior();

        if (Input.GetKey(KeyCode.Z))
        {
            bulletObjectPool.SetPlayerBulletOfPositionAndActive(bulletSpawn);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetState(new InvincibilityState());
            Invoke("SetMeshCollider", 2f);
            Debug.Log("필살기 사용!");
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
            Mathf.Clamp(rigidbody3D.position.x, jinBoundary.boundaryXMin, jinBoundary.boundaryXMax),
            0.0f,
            Mathf.Clamp(rigidbody3D.position.z, jinBoundary.boundaryZMin, jinBoundary.boundaryZMax)
        );
    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "EnemyPlane")
    //    {
    //        enemyObjectPool.EnemyPlaneEnqueue(other.gameObject);
    //        other.gameObject.SetActive(false);


    //        if (other.tag == "EnemySpacePlane")
    //        {
    //            enemyObjectPool.EnemyPlaneSpaceEnqueue(other.gameObject);
    //            other.gameObject.SetActive(false);

    //        }

    //        if (other.tag == "EnemyBullet")
    //        {
    //            bulletObjectPool.EnemyBulletsEnqueue(other.gameObject);
    //            other.gameObject.SetActive(false);

    //        }


    //    }

    //    if (other.tag == "EnemySpacePlane")
    //    {
    //        enemyObjectPool.EnemyPlaneSpaceEnqueue(other.gameObject);
    //        other.gameObject.SetActive(false);

            
    //    }

    //    if(other.tag == "EnemyBullet")
    //    {
    //        bulletObjectPool.EnemyBulletsEnqueue(other.gameObject);
    //        other.gameObject.SetActive(false);

    //    }
    //}

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
