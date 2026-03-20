using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    /* The C# Way
     * 
    // 1. Define the delegate (The blueprint for listeners)
    public delegate void CheckpointHandler(Vector3 position);

    // 2. Define the event
    public event CheckpointHandler OnCheckpointReached;
    */

    // The UnityEvents Way
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

            /* The C# Way
            // 3. Let everyone know checkpoint has been reached!
            OnCheckpointReached?.Invoke(collision.transform.position);
            */

            // The UnityEvent Way
            onCheckpointReached.Invoke(collision.transform.position);

            Debug.Log("Checkpoint Reached!");
        }
    }
}
