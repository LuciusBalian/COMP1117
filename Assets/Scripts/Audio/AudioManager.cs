using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // 1. Static access point
    public static AudioManager Instance;

    [Header("Music")]
    [Tooltip("Plays looping background tracks")]
    [SerializeField] private AudioSource musicSource;

    [Header("SFX")]
    [Tooltip("Player one-shot sound effects")]
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        // 2. The Singleton Pattern Logic
        if(Instance == null)
        {
            // If i'm the first one, I am the Instance
            Instance = this;

            // 3. The persistence
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If another audiomanager exists, destroy it
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
