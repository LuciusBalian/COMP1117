using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int scoreValue = 1;

    public UnityEvent<int> onCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            onCollected.Invoke(scoreValue);
            Destroy(gameObject);
        }
    }
}
