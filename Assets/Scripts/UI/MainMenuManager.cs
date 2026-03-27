using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip levelMusic;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(menuMusic);
    }

    public void StartGame()
    {
        AudioManager.Instance.PlayMusic(levelMusic);
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
