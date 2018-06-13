using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MujuckState : State
{
    private MeshCollider playerCollider;
    private bool isBehavior;

    public MujuckState()
    {
        playerCollider = GameObject.Find("PlayerShipObject").GetComponentInChildren<MeshCollider>();
        //playerCollider = GameObject.Find("PlayerShipObject").GetComponent<MeshCollider>();
        isBehavior = true;
    }

    public void Behavior()
    {
        if(isBehavior == true)
        {
            isBehavior = false;
            playerCollider.convex = false;
            Debug.Log("필살기 발동과 필살기 애니메이션");
        }
    }
}
