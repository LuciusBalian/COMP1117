using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // 1. Define the delegate (The blueprint for listeners)
    public delegate void CheckpointHandler(Vector3 position);

    // 2. Define the event
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

            // 3. Let everyone know checkpoint has been reached!
            OnCheckpointReached?.Invoke(collision.transform.position);

            Debug.Log("Checkpoint Reached!");
        }
    }
}
