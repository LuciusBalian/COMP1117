using UnityEngine;
using TMPro;
using System.Collections; 

public class GameUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI cherryText;
    [SerializeField] private RectTransform scorePanel;      // Wooden Panel

    [Header("Juice Settings")]
    [SerializeField] private float pulseScale = 1.2f;
    [SerializeField] private float pulseDuration = 0.1f;

    private int totalCherries = 0;
    private Vector3 originalScale;

    private void Awake()
    {
        if(scorePanel != null)
        {
            originalScale = scorePanel.localScale;
        }
    }

    private void Start()
    {
        // Initialize the display at the start of the game
        UpdateCherryDisplay();
    }

    // Listener method
    // Accepts an int so that it can receive data from the event.
    public void OnCherryCollected(int amount)
    {
        totalCherries += amount;
        UpdateCherryDisplay();

        // Trigger pulse effect
        StopAllCoroutines();            // Resets if multiple cherries are hit quickly 
        StartCoroutine(PulseEffect());
    }

    private IEnumerator PulseEffect()
    {
        // Scale up
        scorePanel.localScale = originalScale * pulseScale;

        yield return new WaitForSeconds(pulseDuration);

        scorePanel.localScale = originalScale;
    }

    private void UpdateCherryDisplay()
    {
        if(cherryText != null)
        {
            cherryText.text = totalCherries.ToString();
        }
    }
}
