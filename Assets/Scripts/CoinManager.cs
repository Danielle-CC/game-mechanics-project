using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance; // Singleton instance
    public TextMeshProUGUI coinText; // Reference to the UI Text (TextMeshPro)
    private int coinCount = 0; // Total coins collected

    private void Awake()
    {
        // Set up the singleton instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure there's only one CoinManager
        }
    }

    public void AddCoin(int amount)
    {
        coinCount += amount; // Increment the coin count
        UpdateCoinText(); // Update the UI
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "COINS: " + coinCount; // Update the text on the screen
        }
        else
        {
            Debug.LogError("Coin Text UI is not assigned in the CoinManager!");
        }
    }
}
