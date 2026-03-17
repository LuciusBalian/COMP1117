using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private Checkpoint[] allCheckpoints;
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/player_save.json";
    }

    private void OnEnable()
    {
        foreach(Checkpoint cp in allCheckpoints)
        {
            cp.OnCheckpointReached += SaveGame; // Subscribe. 
        }
    }

    private void OnDisable()
    {
        foreach(Checkpoint cp in allCheckpoints)
        {
            cp.OnCheckpointReached -= SaveGame; // Unsubscribe
        }
    }

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

    public PlayerSaveData LoadGame()
    {
        if(File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<PlayerSaveData>(json);
        }

        Debug.LogWarning("No save file found at " + savePath);
        return null;
    }
}
