using Unity.VisualScripting;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    private float dashTimer;

    public override void EnterState(Player player)
    {
        dashTimer = 0.2f;
    }

    public override void UpdateState(Player player)
    {
        dashTimer -= Time.deltaTime;
    }

    public override void FixedUpdateState(Player player)
    {
        if (dashTimer <= 0)
            if (player.groundCheck)
                player.SwitchState(player.GroundedState);
            else
                player.SwitchState(player.AirborneState);

    }

    public override void ExitState(Player player)
    {

    }
}
