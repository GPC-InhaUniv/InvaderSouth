using UnityEngine;

public class ZigzagMovingDecorator : MovingDecorator
{
    private float maxPositionEnemyX;
    private float minPositionEnemyX;
    private bool isBoundaryCollision = true;

    private void Awake()
    {
        parkBoundary = new ParkBoundary(5.5f, -5.5f, -2, 25);
        EnemyPlane = GetComponent<EnemySpacePlane>();
        rigidbody3D = GetComponent<Rigidbody>();
        maxPositionEnemyX = EnemyPlane.gameObject.transform.position.x + 3f;
        minPositionEnemyX = EnemyPlane.gameObject.transform.position.x - 3f;
    }

    public override void EnemyMove()
    {
        if (isBoundaryCollision == true)
        {
            EnemyPlane.gameObject.transform.Translate(new Vector3(1, 0, 0) * -base.speed);

            if (parkBoundary.boundaryXMax <= this.transform.position.x)
            {
                isBoundaryCollision = false;
            }

            if (EnemyPlane.gameObject.transform.position.x > maxPositionEnemyX)
            {
                isBoundaryCollision = false;
            }
        }

        else if (isBoundaryCollision == false)
        {
            EnemyPlane.gameObject.transform.Translate(new Vector3(1, 0, 0) * base.speed);

            if (parkBoundary.boundaryXMin >= this.transform.position.x)
            {
                isBoundaryCollision = true;
            }

            else if (EnemyPlane.gameObject.transform.position.x < minPositionEnemyX)
            {
                isBoundaryCollision = true;
            }
        }
    }
}