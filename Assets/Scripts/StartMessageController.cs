using UnityEngine;
using TMPro; // For TextMeshPro

public class StartMessageController : MonoBehaviour
{
    public float displayDuration = 5f; // Time the message will stay visible

    private TextMeshProUGUI messageText; // Reference to the TextMeshPro component

    private void Start()
    {
        // Get the TextMeshPro component
        messageText = GetComponent<TextMeshProUGUI>();

        // Start the coroutine to hide the message after a delay
        StartCoroutine(HideMessage());
    }

    private System.Collections.IEnumerator HideMessage()
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);

        // Hide the message
        gameObject.SetActive(false);
    }
}
