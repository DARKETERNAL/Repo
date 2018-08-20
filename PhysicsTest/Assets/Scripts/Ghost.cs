using UnityEngine;

public class Ghost : Enemy
{
    [SerializeField]
    private float moveRadius = 10F;

    private Vector3 currentPosition;
    private float minSideDisplacement = 0;
    private float maxSideDisplacement = 0;

    private bool movingLeftwards = false;
    private float sideMovementFactor = 0F;

    protected override void Start()
    {
        base.Start();

        Vector3 startPosition = transform.position;
        currentPosition = startPosition;
        minSideDisplacement = startPosition.x - moveRadius;
        maxSideDisplacement = startPosition.x + moveRadius;

        movingLeftwards = true; // Random.value <= 0.5F;
    }

    protected override void Move()
    {
        sideMovementFactor = movingLeftwards ? moveRadius * -1F : moveRadius;
        currentPosition += new Vector3(sideMovementFactor * Time.deltaTime, 0F, MovementSpeed * -1F * Time.deltaTime);
        transform.position = currentPosition;

        if (movingLeftwards)
        {
            if (currentPosition.x <= minSideDisplacement)
            {
                movingLeftwards = false;
            }
        }
        else
        {
            if (currentPosition.x >= maxSideDisplacement)
            {
                movingLeftwards = true;
            }
        }
    }
}