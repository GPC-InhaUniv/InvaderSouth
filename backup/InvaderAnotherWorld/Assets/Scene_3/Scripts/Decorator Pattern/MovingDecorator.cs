using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class MovingDecorator : Enemy
{
    protected Enemy EnemyPlane;
    protected Rigidbody rigidbody3D;
    protected ParkBoundary parkBoundary;
    public override abstract void EnemyMove();
}
