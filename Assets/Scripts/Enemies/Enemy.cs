using UnityEngine;

public abstract class Enemy : Character
{
    [Header("Enemy Interaction")]
    [SerializeField] protected int contactDamage = 1;
    [SerializeField] protected float stompBounceForce = 12f;

    [Header("Death Effects")]
    [SerializeField] private GameObject deathEffectPrefab;

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Vector2 contactNormal = collision.contacts[0].normal;

            if (contactNormal.y <= -0.5f)
            {
                OnStomped(player);
            }
            else
            {
                player.TakeDamage(contactDamage);
            }
        }
    }

    protected virtual void OnStomped(Player player)
    {
        // Accessing the Player's Rigidbody (assuming Player also updated to RBody)
        if (player.rBody != null)
        {
            player.rBody.linearVelocity = new Vector2(player.rBody.linearVelocity.x, stompBounceForce);
        }

        Die();
    }

    public override void Die()
    {
        if (IsDead) return; // Using capitalized Property from Character.cs
                            // Note: You may need a 'protected set' in Character or a local IsDead = true;

        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        if (sRend != null)
        {
            sRend.enabled = false;
        }

        rBody.simulated = false;
        rBody.linearVelocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject, 0.1f);
    }
}