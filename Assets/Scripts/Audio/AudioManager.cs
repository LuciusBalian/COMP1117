using UnityEngine;

public class AudioManager : MonoBehaviour
{
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

    public void PlayMusic(AudioClip clip, bool isLooping = true)
    {
        musicSource.clip = clip;
        musicSource.loop = isLooping;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
