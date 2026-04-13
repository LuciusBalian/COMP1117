using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Character
{
    [Header("Data Asset")]
    [SerializeField] public PlayerData data; // Holds stats like moveSpeed, jumpForce, etc.

    [Header("Detection & UI")]
    public Transform groundCheck;
    public Transform headHit;
    public GameOverUI gameOverUI;

    // --- State Pattern Variables ---
    public PlayerBaseState currentState;

    // Concrete state instances
    public PlayerGroundedState GroundedState = new PlayerGroundedState();
    public PlayerAirborneState AirborneState = new PlayerAirborneState();
    public PlayerHurtState HurtState = new PlayerHurtState();
    public PlayerDeathState DeathState = new PlayerDeathState();
    public PlayerCrouchState CrouchState = new PlayerCrouchState();
    public PlayerDashState DashState = new PlayerDashState();

    [HideInInspector] public Vector2 moveInput;
    [HideInInspector] public int jumpsRemaining;
    [HideInInspector] public bool isInvulnerable;

    private float dashCD = 0f;


    protected override void Awake()
    {
        base.Awake(); // Sets up RBody, Anim, and SRend from Character
        jumpsRemaining = data.maxJumps;
    }

    private void Start()
    {
        // INITIALIZATION LOGIC
        SwitchState(GroundedState);

    }

    private void Update()
    {
        if (dashCD > 0)
            dashCD -= Time.deltaTime;
        if (IsDead) return;

        // UPDATE CURRENT STATE
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        if (IsDead) return;

        // UPDATE CURRENT STATE
        currentState.FixedUpdateState(this);
    }

    public void SwitchState(PlayerBaseState newState)
    {
        // SWITCH STATE LOGIC
        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = newState;

        currentState.EnterState(this);


    }



    // --- Unity Input System Events ---
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
            currentState.OnJumpPressed(this); // Pass input intent to state
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        if (context.started)
            currentState.OnCrouchHeld(this);
        else if (context.canceled && !CheckHeadHit())
            currentState.OnCrouchReleased(this);
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started && dashCD <= 0f)
            currentState.OnDashPressed(this);
            dashCD = 4f;
    }

    // --- Shared Logic Helpers ---
    public bool CheckGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, data.groundCheckRadius, data.groundLayer);
    }

    public bool CheckHeadHit()
    {
        return Physics2D.OverlapCircle(headHit.position, data.groundCheckRadius, data.groundLayer);
    }

    public override void TakeDamage(int amount)
    {
        if (IsDead || isInvulnerable) return;

        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            SwitchState(DeathState);
        }
        else
        {
            SwitchState(HurtState);
        }
    }

    public override void Die()
    {
        // Handled within PlayerDeathState logic
    }

    public override void Move()
    {
        
    }

    public void ResetState(Vector3 resetPos)
    {
        // This acts as a global reset, but should ideally 
        // transition the player back to GroundedState.
        transform.position = resetPos;
        CurrentHealth = 3; // Or pull from data.maxHealth
        IsDead = false;
        SwitchState(GroundedState);
    }

    public void SetDead(bool deadStatus)
    {
        IsDead = deadStatus;
    }
}