using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*delegate*/
    public delegate void GameResult();
    public GameResult GameOverResult;
    public GameResult GameClearResult;





    public GameObject Bolt;
    public GameObject BoltSpawn;
    private float fireTime = 0.25f;
    private float nextFire = 0f;
    private State playerState;
    public bool isGameOver;
    public bool isGameClear;


    private void Awake()
    {
        playerState = new LivingState();
    }

    private void FixedUpdate()
    {
        playerState.behavior();

        if (Input.GetKey(KeyCode.Z))
        {
            PlayerShot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetState(new MujuckState());
            Debug.Log("필살기 사용!");
            //playerState.behavior();
            Invoke("SetMeshCollider", 3f);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            SetState(new DeadState());
            playerState.behavior();
            isGameOver = true;
            GameOverResult();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            //SetState(new DeadState());
            //playerState.behavior();
            isGameClear = true;
            GameClearResult();
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
            this.gameObject.SetActive(false);
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
