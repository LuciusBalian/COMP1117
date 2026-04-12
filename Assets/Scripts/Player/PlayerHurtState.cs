using UnityEngine;

public class PlayerHurtState : PlayerBaseState
{
    private float stunTimer;
    private float flashTimer;

    public override void EnterState(Player player)
    {
        
    }

    public override void UpdateState(Player player)
    {
        
    }

    public override void FixedUpdateState(Player player)
    {
        // No movement input allowed while hurt!
        // We leave this empty to "lock" the player's controls.
    }

    public override void ExitState(Player player)
    {
        
    }

    private void ApplyKnockback(Player player)
    {
        
    }
}