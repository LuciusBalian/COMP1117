using UnityEngine;

public class PlayerCrouchState : PlayerBaseState
{
    private CapsuleCollider2D playerCollider;
    private Vector2 originalColliderSize;
    public override void EnterState(Player player)
    {
        player.jumpsRemaining = player.data.maxJumps;
        player.anim.SetBool("IsCrouched", true);

        playerCollider = player.GetComponent<CapsuleCollider2D>();
        originalColliderSize = playerCollider.size;
        playerCollider.size = new Vector2(originalColliderSize.x, originalColliderSize.y * 0.5f);
    }

    public override void UpdateState(Player player)
    {
        player.anim.SetFloat("VerticalVelocity", player.rBody.linearVelocityY);
        //if (player.OnCrouch)
       
    }

    public override void FixedUpdateState(Player player)
    {
        player.rBody.linearVelocity = new Vector2(player.moveInput.x * player.data.moveSpeed * 0.5f, player.rBody.linearVelocityY);

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
            player.SwitchState(player.AirborneState);
        }
    }

    public override void OnCrouchReleased(Player player)
    {
        player.SwitchState(player.GroundedState);
    }

    public override void ExitState(Player player) 
    {
        playerCollider.size = originalColliderSize;
        Debug.Log("exited crouch");
    }
}
