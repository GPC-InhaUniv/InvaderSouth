﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float boundaryXMax = 6;
    private float boundaryXMin = -6;
    private float boundaryZMax = 1;
    private float boundaryZMin = -9;

    private MeshCollider playerMeshCollider;
    private MeshRenderer playerMeshRenderer;
    private Transform bulletSpawn;
    private BulletObjectPool bulletObjectPool;
    private Rigidbody rigidbody3D;
    private EnemyObjectPool enemyObjectPool;
    private IState playerState;
    private int hp = 5;
    private bool isGameOver;
    public bool IsGameOver
    {
        get { return isGameOver; }
        private set { }
    }

    private void Awake()
    {
        playerState = new LivingState();
        bulletSpawn = this.transform.Find("BulletSpawn");
        playerMeshCollider = this.GetComponent<MeshCollider>();
        playerMeshRenderer = this.GetComponent<MeshRenderer>();
        rigidbody3D = this.gameObject.GetComponent<Rigidbody>();
        bulletObjectPool = GameObject.Find("ObjectPool").GetComponent<BulletObjectPool>();
        enemyObjectPool = GameObject.Find("ObjectPool").GetComponent<EnemyObjectPool>();
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
            if (this.hp <= 0)
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
            Mathf.Clamp(rigidbody3D.position.x, boundaryXMin, boundaryXMax),
            0.0f,
            Mathf.Clamp(rigidbody3D.position.z, boundaryZMin, boundaryZMax)
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyPlane")
        {
            enemyObjectPool.EnemyPlaneEnqueue(other.gameObject);
            other.gameObject.SetActive(false);
            if (this.hp > 0)
            {
                this.hp -= Enemy.Damage;
            }
        }

        if (other.tag == "EnemySpacePlane")
        {
            enemyObjectPool.EnemyPlaneSpaceEnqueue(other.gameObject);
            other.gameObject.SetActive(false);
            if (this.hp > 0)
            {
                this.hp -= Enemy.Damage;
            }
        }

        if(other.tag == "EnemyBullet")
        {
            bulletObjectPool.EnemyBulletsEnqueue(other.gameObject);
            other.gameObject.SetActive(false);
            if(this.hp > 0)
            {
                this.hp -= Enemy.Damage;
            }
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
