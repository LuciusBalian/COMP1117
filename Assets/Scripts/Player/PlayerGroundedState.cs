using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        player.jumpsRemaining = player.data.maxJumps;
        player.anim.SetBool("IsGrounded", true);
    }

    public override void UpdateState(Player player)
    {
        player.anim.SetFloat("HorizontalSpeed", Mathf.Abs(player.rBody.linearVelocity.x));

        if (!player.CheckGrounded())
        {
            player.SwitchState(player.AirborneState);
        }
    }

    public override void FixedUpdateState(Player player)
    {
        player.rBody.linearVelocity = new Vector2(player.moveInput.x * player.data.moveSpeed, player.rBody.linearVelocity.y);
        player.FlipSprite(player.moveInput.x);
    }

    public override void OnJumpPressed(Player player)
    {
        player.rBody.linearVelocity = new Vector2(player.rBody.linearVelocity.x, player.data.jumpForce);
        player.anim.SetTrigger("Jump");
        AudioManager.Instance.PlayJump();
        player.jumpsRemaining--;
        player.SwitchState(player.AirborneState);
    }

    public override void ExitState(Player player) { }
}