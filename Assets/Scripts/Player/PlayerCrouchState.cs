using UnityEngine;

public class PlayerCrouchState : PlayerBaseState
{
    private bool isCrouched = false;
    public override void EnterState(Player player)
    {
        player.jumpsRemaining = player.data.maxJumps;
        player.anim.SetBool("IsCrouched", true);
    }

    public override void UpdateState(Player player)
    {
        player.anim.SetFloat("VerticalVelocity", player.rBody.linearVelocityY);

        if (player.CheckGrounded() && player.rBody.linearVelocityY <= 0.1f)
        {
            player.SwitchState(player.GroundedState);
        }
    }

    public override void FixedUpdateState(Player player)
    {
        player.rBody.linearVelocity = new Vector2(player.moveInput.x * player.data.moveSpeed, player.rBody.linearVelocityY);

        player.FlipSprite(player.moveInput.x);
    }

    public override void OnJumpPressed(Player player)
    {
        // double jump logic
        if (player.jumpsRemaining > 0)
        {
            player.rBody.linearVelocity = new Vector2(player.rBody.linearVelocityX, player.data.jumpForce);
            player.anim.SetTrigger("Jump");

            AudioManager.Instance.PlayJump();

            player.jumpsRemaining--;
        }
    }



    public override void ExitState(Player player) { }
}
