using UnityEngine;

[CreateAssetMenu(fileName = "AudioPlaylist", menuName = "Scriptable Objects/AudioPlaylist")]
public class AudioPlaylist : ScriptableObject
{
    [Header("Music Tracks")]
    public AudioClip menuTheme;
    public AudioClip levelTheme;

    [Header("Sound Effects")]
    public AudioClip jumpFX;
}
