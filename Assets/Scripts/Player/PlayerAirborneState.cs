using UnityEngine;

public class PlayerAirborneState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        player.anim.SetBool("IsGrounded", false);
    }

    public override void UpdateState(Player player)
    {
        player.anim.SetFloat("VerticalVelocity", player.rBody.linearVelocity.y);

        // Transition back to ground if we are falling and hit the floor
        if (player.CheckGrounded() && player.rBody.linearVelocity.y <= 0.1f)
        {
            player.SwitchState(player.GroundedState);
        }
    }

    public override void FixedUpdateState(Player player)
    {
        // Maintain horizontal control while in the air
        player.rBody.linearVelocity = new Vector2(player.moveInput.x * player.data.moveSpeed, player.rBody.linearVelocity.y);
        player.FlipSprite(player.moveInput.x);
    }

    public override void OnJumpPressed(Player player)
    {
        // Double Jump Logic
        if (player.jumpsRemaining > 0)
        {
            player.rBody.linearVelocity = new Vector2(player.rBody.linearVelocity.x, player.data.jumpForce);
            player.anim.SetTrigger("Jump");
            AudioManager.Instance.PlayJump();
            player.jumpsRemaining--;
        }
    }

    public override void ExitState(Player player) { }
}