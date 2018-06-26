using UnityEngine;

public class InvincibilityState : IState
{
    private MeshCollider playerCollider;
    private bool isBehavior;

    public InvincibilityState()
    {
        playerCollider = GameObject.Find("Player").GetComponentInChildren<MeshCollider>();
        isBehavior = true;
    }

    public void Behavior()
    {
        if (isBehavior == true)
        {
            isBehavior = false;
            playerCollider.enabled = false;
            Debug.Log("필살기 발동과 필살기 애니메이션");
        }
    }
}
