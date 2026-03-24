using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // 1. Tell the audio manager to swap tracks
        if(AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayLevelMusic();
        }

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
