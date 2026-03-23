using UnityEngine;
using UnityEngine.Events;

public class Cherry : MonoBehaviour
{
    [SerializeField] private int cherryValue = 1;   // Point value of a cherry

    // The event that carries the value
    public UnityEvent<int> onPickedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Announce that a cherry has been picked up
            onPickedUp.Invoke(cherryValue);

            // Destroy the cherry
            Destroy(gameObject);
        }
    }
}
