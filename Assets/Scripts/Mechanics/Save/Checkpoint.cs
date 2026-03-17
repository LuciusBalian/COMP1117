using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // public SaveManager saveManager; 

    // 1. Delegate
    public delegate void CheckpointHandler(Vector3 position);

    // 2. The Event
    public event CheckpointHandler OnCheckpointReached;

    private SpriteRenderer sRend;

    private void Awake()
    {
        sRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            sRend.color = Color.green;

            // saveManager.SaveGame(collision.transform.position);
            // 3. Let everyone know checkpoint has been reached!
            OnCheckpointReached?.Invoke(collision.transform.position);

            Debug.Log("Checkpoint Reached!");
        }
    }
}
