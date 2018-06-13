using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Bolt;
    public GameObject BoltSpawn;
    private int hp = 5;
    private float fireTime = 0.25f;
    private float nextFire = 0f;
    private State playerState;
    private EnemyController enemyController;

    public BombObjectPool BombSkill;
    Animator animator;

    private bool isGameOver;
    public bool IsGameOver
    {
        get { return isGameOver; }
        private set { }
    }
    
    private void Awake()
    {
        playerState = new LivingState();
        enemyController = GameObject.Find("EnemyShip1").GetComponent<EnemyController>();
        BombSkill = GameObject.Find("GameObjectPool").GetComponent<BombObjectPool>();
        animator = gameObject.GetComponentInChildren<Animator>();
        Debug.Log(playerState);
    }
    private void Update()
    {
        playerState.Behavior();
        Debug.Log(playerState);
    }

    private void FixedUpdate()
    {
        //Debug.Log(playerState);
        

        if (Input.GetKey(KeyCode.Z))
        {
            PlayerShot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            BombSkill.StartBombing();
            animator.Play("SkillAnim");
            SetState(new MujuckState());
            Debug.Log("필살기 사용!");
            Invoke("SetMeshCollider", 1f);
        }

        if(isGameOver != true)
        {
            if (this.hp <= 0)
            {
                SetState(new DeadState());
                this.GetComponent<MeshRenderer>().enabled = false;
                isGameOver = true;
            }
        }
    }

    private void PlayerShot()
    {
        if(nextFire < Time.time + fireTime)
        {
            //현재 총알을 생성중 -> 풀 적용해야함
            GameObject bolt = Instantiate(Bolt);
            bolt.transform.position = BoltSpawn.transform.position;
            nextFire = Time.time;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" || other.tag == "EnemyBolt")
        {
            Destroy(other.gameObject);
            if(this.hp > 0)
            {
                this.hp -= enemyController.damage;
            }
        }
    }

    private void SetState(State state)
    {
        this.playerState = state;
    }

    private void SetMeshCollider()
    {
        this.GetComponentInChildren<MeshCollider>().convex = true;
        
        //this.GetComponent<MeshCollider>().convex = true;
        SetState(new LivingState());
    }
}
