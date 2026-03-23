using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI cherryText;

    private int totalCherries = 0;

    private void Start()
    {
        // Initialize the display at the start of the game
        UpdateCherryDisplay();
    }

    // Listener method
    // Accepts an int so that it can receive data from the event
    public void OnCherryCollected(int amount)
    {
        totalCherries += amount;
        UpdateCherryDisplay();
    }

    private void UpdateCherryDisplay()
    {
        // Safety check!
        if(cherryText != null)
        {
            cherryText.text = totalCherries.ToString();
        }
    }
}
