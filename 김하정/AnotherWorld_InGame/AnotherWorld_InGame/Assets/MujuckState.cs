using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MujuckState : State
{
    private MeshCollider playerCollider;

    public MujuckState()
    {
        playerCollider = GameObject.Find("PlayerShip").GetComponent<MeshCollider>();
    }

    public void behavior()
    {
        playerCollider.convex = false;
        Debug.Log("필살기 발동과 필살기 애니메이션");
    }
}
