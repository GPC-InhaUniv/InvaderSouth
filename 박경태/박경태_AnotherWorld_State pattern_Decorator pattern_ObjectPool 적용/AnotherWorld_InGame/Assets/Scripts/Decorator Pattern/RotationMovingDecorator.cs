using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovingDecorator : MovingDecorator
{
    private void Awake()
    {
        EnemyPlane = GetComponent<EnemyPlane>();
    }

    public override void EnemyMove()
    {
        EnemyPlane.gameObject.transform.Rotate(new Vector3(0, 0, 1) * 3);
    }
}
