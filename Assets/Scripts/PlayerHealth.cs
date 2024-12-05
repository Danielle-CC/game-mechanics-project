using UnityEngine;
using UnityEngine.UI; // For Image
using TMPro; // For TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3; // Maximum number of lives
    private int currentLives;

    public TextMeshProUGUI livesText; // Reference to the UI Text for lives
    public GameObject lostLifeText; // Reference to "You lost a life" text
    public GameObject gameOverText; // Reference to "Game Over" text
    public float deathDelay = 2f; // Delay before resetting or restarting
    public Image[] heartIcons; // Array of heart icons (set in Inspector)

    private bool isDead = false; // Prevents multiple triggers

    private void Start()
    {
        currentLives = maxLives; // Initialize lives
        UpdateLivesUI();

        if (lostLifeText != null) lostLifeText.SetActive(false);
        if (gameOverText != null) gameOverText.SetActive(false);
    }

    public void TakeDamage()
    {
        if (isDead) return; // Prevent multiple triggers
        isDead = true;

        currentLives--; // Reduce lives
        UpdateLivesUI(); // Update the UI immediately

        if (currentLives <= 0)
        {
            PlayerDeath(); // Handle game over
        }
        else
        {
            ShowLostLifeMessage();
            Invoke("ResetPlayerPosition", deathDelay); // Delay before resetting position
        }
    }

    private void UpdateLivesUI()
    {
        // Debugging
        Debug.Log("Updating UI. Current Lives: " + currentLives);

        // Update the lives text
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }

        // Update the heart icons
        for (int i = 0; i < heartIcons.Length; i++)
        {
            if (heartIcons[i] != null)
            {
                // Enable hearts up to currentLives, disable the rest
                heartIcons[i].enabled = (i < currentLives);
                Debug.Log($"Heart {i}: {(heartIcons[i].enabled ? "Enabled" : "Disabled")}");
            }
        }
    }

    private void ShowLostLifeMessage()
    {
        if (lostLifeText != null)
        {
            lostLifeText.SetActive(true);
            Invoke("HideLostLifeMessage", deathDelay);
        }
    }

    private void HideLostLifeMessage()
    {
        if (lostLifeText != null)
        {
            lostLifeText.SetActive(false);
        }
    }

    private void ResetPlayerPosition()
    {
        transform.position = Vector3.zero; // Example spawn point
        isDead = false; // Allow damage again
    }

    private void PlayerDeath()
    {
        Debug.Log("Game Over!");

        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }

        Invoke("RestartGame", deathDelay);
    }

    private void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
