using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigzagMovingDecorator : MovingDecorator
{
    private float maxPositionEnemyX;
    private float minPositionEnemyX;
    private bool isBoundaryTouch = true;
    private float timer;

    private void Awake()
    {
        parkBoundary = new ParkBoundary(5.5f, -5.5f, 14, -20);
        EnemyPlane = GetComponent<EnemySpacePlane>();
        rigidbody3D = GetComponent<Rigidbody>();
        maxPositionEnemyX = EnemyPlane.gameObject.transform.position.x + 3f;
        minPositionEnemyX = EnemyPlane.gameObject.transform.position.x - 3f;
    }

    public override void EnemyMove()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);

        if (isBoundaryTouch == true)
        {
            EnemyPlane.gameObject.transform.Translate(new Vector3(1, 0, 0) * -base.speed);

            if(parkBoundary.boundaryXMax <= this.transform.position.x)
            {
                isBoundaryTouch = false;
            }

            if (EnemyPlane.gameObject.transform.position.x > maxPositionEnemyX)
            {
                isBoundaryTouch = false;
            }
        }

        else if (isBoundaryTouch == false)
        {
            EnemyPlane.gameObject.transform.Translate(new Vector3(1, 0, 0) * base.speed);

            if(parkBoundary.boundaryXMin >= this.transform.position.x)
            {
                isBoundaryTouch = true;
            }

            else if (EnemyPlane.gameObject.transform.position.x < minPositionEnemyX)
            {
                isBoundaryTouch = true;
            }
        }
    }
}