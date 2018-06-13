using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class MovingDecorator : Enemy
{
    public Enemy EnemyPlane;
    public override abstract void EnemyMove();
}
