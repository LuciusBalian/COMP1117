using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    // public SaveManager saveManager; 

    /* The C# Event Way
    // 1. Delegate
    // public delegate void CheckpointHandler(Vector3 position);

    // 2. The Event
    // public event CheckpointHandler OnCheckpointReached;
    */

    // The UnityEvent Way
    public UnityEvent<Vector3> onCheckpointReached;

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

            /* C# Event Way
            // 3. Let everyone know checkpoint has been reached!
            // OnCheckpointReached?.Invoke(collision.transform.position);
            */

            // The UnityEventWay
            onCheckpointReached.Invoke(collision.transform.position);

            Debug.Log("Checkpoint Reached!");
        }
    }
}
