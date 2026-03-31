using UnityEngine;

public class PlayerHurtState : PlayerBaseState
{
    private float stunTimer;
    private float flashTimer;

    public override void EnterState(Player player)
    {
        Debug.Log("Entering Hurt State");

        // 1. Initial Impact
        player.anim.SetTrigger("Hurt");
        player.isInvulnerable = true;
        stunTimer = player.data.hurtStunTime;
        flashTimer = 0;

        // 2. Apply Knockback (Logic moved from Player.cs)
        ApplyKnockback(player);
    }

    public override void UpdateState(Player player)
    {
        // 3. Handle Stun Timer
        if (stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
        }
        else
        {
            // Once stun ends, we check if we should be Grounded or Airborne
            if (player.CheckGrounded())
                player.SwitchState(player.GroundedState);
            else
                player.SwitchState(player.AirborneState);
        }

        // 4. Handle Visual Flashing (Replaces the Coroutine loop)
        flashTimer += Time.deltaTime;
        if (flashTimer >= player.data.iframeDuration)
        {
            player.sRend.enabled = !player.sRend.enabled;
            flashTimer = 0;
        }
    }

    public override void FixedUpdateState(Player player)
    {
        // No movement input allowed while hurt!
        // We leave this empty to "lock" the player's controls.
    }

    public override void ExitState(Player player)
    {
        // 5. Cleanup
        player.sRend.enabled = true;

        // Note: You might want a separate timer for iFrames 
        // if they last longer than the stun.
        player.isInvulnerable = false;
    }

    private void ApplyKnockback(Player player)
    {
        float pushDirection = player.transform.localScale.x > 0 ? -1f : 1f;
        player.rBody.linearVelocity = Vector2.zero;
        player.rBody.AddForce(new Vector2(pushDirection * player.data.knockbackForce, player.data.knockbackForce), ForceMode2D.Impulse);
    }
}