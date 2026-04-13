using Unity.VisualScripting;
using UnityEngine;

public class PlayerDashState : PlayerBaseState
{
    private float dashTimer;

    public override void EnterState(Player player)
    {
        dashTimer = 0.2f;
        Debug.Log("entered dash state");
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
        player.rBody.linearVelocity = new Vector2(5.0f * player.data.moveSpeed * Mathf.Sign(player.anim.transform.localScale.x), player.rBody.linearVelocityY);

        player.FlipSprite(player.moveInput.x);
    }

    public override void ExitState(Player player)
    {

    }
}
