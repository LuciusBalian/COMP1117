using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // [SerializeField] private Checkpoint[] allCheckpoints;
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/player_save.json";
    }

    /*
    private void OnEnable()
    {
        foreach(Checkpoint cp in allCheckpoints)
        {
            cp.OnCheckpointReached += SaveGame; // Subscribe
        }
    }

    private void OnDisable()
    {
        foreach(Checkpoint cp in allCheckpoints)
        {
            cp.OnCheckpointReached -= SaveGame; // Unsubscribe
        }
    }
    */

    public void SaveGame(Vector3 playerPos)
    {
        PlayerSaveData data = new PlayerSaveData();
        data.position[0] = playerPos.x;
        data.position[1] = playerPos.y;
        data.position[2] = playerPos.z;

        string json = JsonUtility.ToJson(data, true);   // Optional 2nd argument. "True" makes the output file human readabale
        File.WriteAllText(savePath, json);
        Debug.Log("Game Saved to: " + savePath);
    }

    // Load game
    public Vector3 LoadGame()
    {
        if (File.Exists(savePath))
        {
            // File exists!
            string json = File.ReadAllText(savePath);   // Load the JSON string from savePath

            PlayerSaveData data = JsonUtility.FromJson<PlayerSaveData>(json);   // Converts the JSON string into PlayerSaveData.
            Vector3 playerData = new Vector3(data.position[0], data.position[1], data.position[2]);
            return playerData;
        }

        // File doesn't exists!
        Debug.LogWarning("No save file found at " + savePath);
        return Vector3.zero;
    }
}
