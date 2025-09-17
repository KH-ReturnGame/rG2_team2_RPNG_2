using UnityEngine;

public class XpOrbSpawner : MonoBehaviour
{
    [Header("Orb Settings")]
    public GameObject xpOrbPrefab;    // The prefab of your orb
    public int spawnCount = 15;        // How many orbs per wave
    public float spawnInterval = 5f;  // Time (seconds) between waves

    [Header("Spawn Area")]
    public Vector2 areaSize = new Vector2(50f, 50f); // width x height box

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnOrbs();
            timer = 0f;
        }
    }

    void SpawnOrbs()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            // Pick a random position inside the area
            Vector3 spawnPos = transform.position + new Vector3(
                Random.Range(-areaSize.x / 2f, areaSize.x / 2f),
                Random.Range(-areaSize.y / 2f, areaSize.y / 2f),
                0f
            );

            // Instantiate as a child of this spawner (so it stays organized in hierarchy)
            Instantiate(xpOrbPrefab, spawnPos, Quaternion.identity, transform);
        }
    }

    // Draw the spawn area in the Scene view for convenience
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(areaSize.x, areaSize.y, 0.1f));
    }
}
