using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    private float deathTimer;

    public override void EnterState(Player player)
    {
        player.SetDead(true); // Property from Character.cs
        player.anim.SetBool("IsDead", true);

        // Visual polish
        player.sRend.sortingLayerName = "Foreground";
        player.sRend.sortingOrder = 100;

        // The "Pop"
        player.GetComponent<Collider2D>().enabled = false;
        player.rBody.linearVelocity = new Vector2(0, 10f);
        player.rBody.gravityScale = 3f;

        deathTimer = 1.5f; // Wait for fall out of view
    }

    public override void UpdateState(Player player)
    {
        deathTimer -= Time.deltaTime;
        if (deathTimer <= 0)
        {
            player.gameOverUI.ShowGameOver();
        }
    }

    public override void FixedUpdateState(Player player) { }
    public override void ExitState(Player player) { }
}
