using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Movement Settings")]
    public float moveSpeed = 8f;
    public float jumpForce = 12f;
    public int maxJumps = 2;

    [Header("Combat Settings")]
    public float knockbackForce = 7f;
    public float iframeDuration = 1.5f;
    public float hurtStunTime = 0.3f;

    [Header("Detection")]
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
}
