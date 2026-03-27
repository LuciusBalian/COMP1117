using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioPlaylist playlist;

    // 1. Static access point
    public static AudioManager Instance;

    [Header("Music")]
    [Tooltip("Plays looping background tracks")]
    [SerializeField] private AudioSource musicSource;

    [Header("Sound Effects")]
    [Tooltip("Plays one-shot sound effects")]
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        // 2. Singleton pattern logic
        if(Instance == null)
        {
            // I'm the first one! I will be the lone AudioManager
            Instance = this;

            // 3. Persistence (Unity-Only)
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy other objects of this type from being created
            Destroy(gameObject);
        }
    }

    // ------------- MUSIC METHODS --------------- //
    /*
    public void PlayMenuMusic()
    {
        PlayMusic(playlist.menuTheme);
    }
    */
    public void PlayMenuMusic() => PlayMusic(playlist.menuTheme);
    public void PlayLevelMusic() => PlayMusic(playlist.levelTheme);

    private void PlayMusic(AudioClip clip)
    {
        // Safety check!
        if(musicSource.clip == clip)
        {
            return; // Don't interrupt the current song with the same song.
        }
        musicSource.clip = clip;
        musicSource.Play();
    }


    // -------------- SFX METHODS ----------------//
    public void PlayJumpSFX() => sfxSource.PlayOneShot(playlist.jumpFX);
}
