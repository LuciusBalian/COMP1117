using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioPlaylist", menuName = "Scriptable Objects/Audio/Playlist")]
public class AudioPlaylist : ScriptableObject
{
    [Header("Music Tracks")]
    public AudioClip menuTheme;
    public AudioClip levelTheme;

    [Header("Sound Effects")]
    public AudioClip buttonClick;
    public AudioClip levelStart;
}
