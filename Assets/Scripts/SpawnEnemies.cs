using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab to spawn
    public Transform spawnPoint; // Where the enemy should spawn

    private bool hasSpawned = false; // Prevent multiple spawns

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Something entered the trigger: " + collision.gameObject.name);

        if (collision.CompareTag("Player") && !hasSpawned)
        {
            Debug.Log("Player triggered the enemy spawn!");
            hasSpawned = true;
            SpawnEnemy();
        }
    }
private void SpawnEnemy()
{
    if (enemyPrefab != null && spawnPoint != null)
    {
        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.z = 0; // Ensure correct Z position
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Debug the spawned enemy's properties
        SpriteRenderer sr = spawnedEnemy.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Debug.Log("Enemy SpriteRenderer found! Sorting Layer: " + sr.sortingLayerName + ", Order in Layer: " + sr.sortingOrder);
            Debug.Log("Enemy color alpha: " + sr.color.a);
        }
        else
        {
            Debug.LogError("Enemy does not have a SpriteRenderer!");
        }

        Debug.Log("Enemy spawned at position: " + spawnedEnemy.transform.position);
    }
    else
    {
        Debug.LogError("Enemy Prefab or Spawn Point is missing!");
    }
}
}