using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigzagMovingDecorator : MovingDecorator
{
    private float maxEnemyX;
    private float minEnemyX;
    private bool isBoundaryTouch = true;

    private void Awake()
    {
        EnemyPlane = GetComponent<EnemySpacePlane>();
        maxEnemyX = EnemyPlane.gameObject.transform.position.x + 3f;
        minEnemyX = EnemyPlane.gameObject.transform.position.x - 3f;
    }

    public override void EnemyMove()
    {
        if (isBoundaryTouch == true)
        {
            EnemyPlane.gameObject.transform.Translate(new Vector3(1, 0, 0) * -base.speed);

            if (EnemyPlane.gameObject.transform.position.x > maxEnemyX)
            {
                isBoundaryTouch = false;
            }
        }

        else if (isBoundaryTouch == false)
        {
            EnemyPlane.gameObject.transform.Translate(new Vector3(1, 0, 0) * base.speed);

            if (EnemyPlane.gameObject.transform.position.x < minEnemyX)
            {
                isBoundaryTouch = true;
            }
        }
    }
}
