using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovingDecorator : MovingDecorator
{
    private void Awake()
    {
        parkBoundary = new ParkBoundary(5.5f, -5.5f, 50, -20);
        EnemyPlane = GetComponent<EnemyPlane>();
        rigidbody3D = GetComponent<Rigidbody>();
    }

    public override void EnemyMove()
    {
        EnemyPlane.gameObject.transform.Rotate(new Vector3(0, 0, 1) * 3);

        rigidbody3D.position = new Vector3
        (
            Mathf.Clamp(rigidbody3D.position.x, parkBoundary.boundaryXMin, parkBoundary.boundaryXMax),
            0.0f,
            Mathf.Clamp(rigidbody3D.position.z, parkBoundary.boundaryZMin, parkBoundary.boundaryZMax)
        );
    }
}
