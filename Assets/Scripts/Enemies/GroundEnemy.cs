using UnityEngine;

public class GroundEnemy : Enemy
{
    [Header("Stats")]
    [SerializeField] private float moveSpeed = 3f; // Re-adding local moveSpeed

    [Header("Patrol Settings")]
    [SerializeField] private Transform leftBoundary;
    [SerializeField] private Transform rightBoundary;

    private bool isMovingLeft = true;

    protected virtual void Update()
    {
        if (IsDead) return;
        Move();
    }

    public override void Move()
    {
        float direction = isMovingLeft ? -1f : 1f;
        // Using capitalized Property RBody
        rBody.linearVelocity = new Vector2(direction * moveSpeed, rBody.linearVelocity.y);

        CheckBoundaries();
        FlipSprite(rBody.linearVelocity.x);
    }

    private void CheckBoundaries()
    {
        if (isMovingLeft && transform.position.x <= leftBoundary.position.x)
            isMovingLeft = false;
        else if (!isMovingLeft && transform.position.x >= rightBoundary.position.x)
            isMovingLeft = true;
    }
}