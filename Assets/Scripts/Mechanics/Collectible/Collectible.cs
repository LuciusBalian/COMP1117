using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int scoreValue = 1;

    public UnityEvent<int> OnPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
