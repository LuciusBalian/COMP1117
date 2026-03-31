using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class Character : MonoBehaviour, IDamageable
{
    [Header("Visual Settings")]
    [SerializeField] protected bool facesLeftByDefault = false;

    // State tracking
    public bool IsDead { get; protected set; }
    public int CurrentHealth { get; protected set; }

    // Component references (Made public so States can access them easily)
    [HideInInspector] public Animator anim;
    [HideInInspector] public Rigidbody2D rBody;
    [HideInInspector] public SpriteRenderer sRend;

    protected virtual void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();

        // Components are on children for better organization
        anim = GetComponentInChildren<Animator>();
        sRend = GetComponentInChildren<SpriteRenderer>();
    }

    // This handles the "Standard" damage logic. 
    // Player/Enemies can override this to add Flashing or Stun states.
    public virtual void TakeDamage(int amount)
    {
        if (IsDead) return;

        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    // Flip logic is shared by all characters (Player and Enemies)
    public void FlipSprite(float horizontalVelocity)
    {
        if (Mathf.Abs(horizontalVelocity) > 0.1f)
        {
            float direction = horizontalVelocity > 0 ? 1f : -1f;
            Vector3 newScale = anim.transform.localScale;

            // Adjust scale based on the default sprite orientation
            newScale.x = facesLeftByDefault ? (direction * -1f) : direction;
            anim.transform.localScale = newScale;
        }
    }

    // These remain abstract so Player and Enemy can implement 
    // their specific State Machine logic.
    public abstract void Die();
    public abstract void Move();
}
