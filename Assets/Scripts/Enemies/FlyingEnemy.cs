using UnityEngine;

public abstract class FlyingEnemy : Enemy
{
    [Header("Stats")]
    [SerializeField] protected float moveSpeed = 4f;

    [Header("Flight Settings")]
    [SerializeField] protected Transform pointA;
    [SerializeField] protected Transform pointB;
    [SerializeField] protected float arrivalThreshold = 0.5f;

    protected Transform currentTarget;

    protected override void Awake()
    {
        base.Awake();
        rBody.gravityScale = 0; // Using capitalized RBody
        currentTarget = pointB;
    }

    protected virtual void Update()
    {
        if (IsDead) return;
        Move();
    }

    public override void Move()
    {
        Vector2 direction = (currentTarget.position - transform.position).normalized;
        rBody.linearVelocity = direction * moveSpeed;

        if (Vector2.Distance(transform.position, currentTarget.position) < arrivalThreshold)
        {
            SwitchTarget();
        }

        FlipSprite(rBody.linearVelocity.x);
    }

    protected virtual void SwitchTarget()
    {
        currentTarget = (currentTarget == pointA) ? pointB : pointA;
    }
}