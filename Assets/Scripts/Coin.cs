using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding is the player
        if (collision.CompareTag("Player"))
        {
            // Log for debugging
            Debug.Log("Coin collected by: " + collision.gameObject.name);

            // Add coin to the total
            CoinManager.instance.AddCoin(1);

            // Destroy the coin after collection
            Destroy(gameObject);
        }
    }
}
