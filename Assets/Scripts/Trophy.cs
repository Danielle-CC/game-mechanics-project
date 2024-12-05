using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class Trophy : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene to load
    public GameObject levelCompleteText; // Reference to a UI text for "Level Complete" message
    public GameObject collectAllCoinsText; // Reference to a UI text for "Collect All Coins" message
    public float restartDelay = 3f; // Time before loading the next level

    private void Start()
    {
        // Hide UI messages at the start
        if (levelCompleteText != null) levelCompleteText.SetActive(false);
        if (collectAllCoinsText != null) collectAllCoinsText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Check if all coins are collected
            if (AreAllCoinsCollected())
            {
                Debug.Log("Player reached the trophy! Level Complete.");

                // Show "Level Complete" message
                if (levelCompleteText != null)
                {
                    levelCompleteText.SetActive(true);
                }

                // Load the next scene after a delay
                Invoke("LoadNextScene", restartDelay);
            }
            else
            {
                Debug.Log("Player needs to collect all coins first!");

                // Show "Collect All Coins" message briefly
                if (collectAllCoinsText != null)
                {
                    collectAllCoinsText.SetActive(true);
                    Invoke("HideCollectAllCoinsText", 2f); // Hide message after 2 seconds
                }
            }
        }
    }

    private bool AreAllCoinsCollected()
    {
        Debug.Log("AreAllCoinsCollected method called"); // Log when the method is called
        // Check if any coins are still active in the scene
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        Debug.Log("Coins remaining: " + coins.Length); // Log the number of remaining coins
        return coins.Length == 0; // If no coins are left, all are collected
    }


    private void HideCollectAllCoinsText()
    {
        if (collectAllCoinsText != null)
        {
            collectAllCoinsText.SetActive(false);
        }
    }

    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene name not set in Trophy script!");
        }
    }
}
