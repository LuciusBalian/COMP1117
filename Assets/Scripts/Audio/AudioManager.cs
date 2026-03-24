using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioPlaylist playlist; // Drag MainPlaylist here
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        { 
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        if (playlist != null && playlist.menuTheme != null)
        {
            PlayMenuMusic();
        }
    }

    // New methods to play specific tracks from the playlist
    public void PlayMenuMusic() => PlayMusic(playlist.menuTheme);
    public void PlayLevelMusic() => PlayMusic(playlist.levelTheme);
    public void PlayClickSFX() => sfxSource.PlayOneShot(playlist.buttonClick);

    private void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip) return; // Prevent restarting if already playing
        musicSource.clip = clip;
        musicSource.Play();
    }
}
