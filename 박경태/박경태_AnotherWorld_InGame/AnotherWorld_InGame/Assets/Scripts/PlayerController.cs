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
    }

    private void FixedUpdate()
    {
        playerState.Behavior();

        if (Input.GetKey(KeyCode.Z))
        {
            PlayerShot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetState(new MujuckState());
            Debug.Log("필살기 사용!");
            Invoke("SetMeshCollider", 3f);
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
        this.GetComponent<MeshCollider>().convex = true;
        SetState(new LivingState());
    }
}
