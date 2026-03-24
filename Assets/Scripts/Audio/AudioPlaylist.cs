using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioPlaylist", menuName = "Scriptable Objects/Audio/Playlist")]
public class AudioPlaylist : ScriptableObject
{
    [Header("Music Tracks")]
    public AudioClip menuTheme;
    public AudioClip levelTheme;

    [Header("UI Sounds")]
    public AudioClip buttonClick;

    [Header("Player Movement")]
    public AudioClip walkStep;
    public AudioClip jump;
    public AudioClip doubleJump;

    [Header("Gameplay Events")]
    public AudioClip pickupItem; // The cherry!
    public AudioClip enemyStomp;
}
