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

    // --- MUSIC METHODS ---
    public void PlayMenuMusic() => PlayMusic(playlist.menuTheme);
    public void PlayLevelMusic() => PlayMusic(playlist.levelTheme);

    private void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip) return;
        musicSource.clip = clip;
        musicSource.Play();
    }

    // --- SFX METHODS (Static Access Points) ---
    public void PlayClick() => sfxSource.PlayOneShot(playlist.buttonClick);
    public void PlayJump() => sfxSource.PlayOneShot(playlist.jump);
    public void PlayWalk() => sfxSource.PlayOneShot(playlist.walkStep);
    public void PlayPickup() => sfxSource.PlayOneShot(playlist.pickupItem);
    public void PlayStomp() => sfxSource.PlayOneShot(playlist.enemyStomp);
}
