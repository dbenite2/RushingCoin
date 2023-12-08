using UnityEngine;

public class CoinSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject coinPrefab;

    [SerializeField]
    private GameObject terrain;

    [SerializeField]
    private int spawnAmount = 85;

    void Awake() {
        // Get the terrain size and position to set the coins within its boundaries
        Vector3 terrainSize = terrain.GetComponent<Renderer>().bounds.size;
        Vector3 terrainPos = terrain.transform.position;
        coinInstiante(terrainSize,terrainPos);
    }

    private void coinInstiante(Vector3 terrainSize, Vector3 terrainPos) {
        int count = 0;
        while (spawnAmount > count) {
            float randomXpositionSpawner = Random.Range(terrainPos.x - terrainSize.x / 2, terrainPos.x + terrainSize.x / 2);
            float randomZpositionSpawner = Random.Range(terrainPos.z - terrainSize.z / 2, terrainPos.z + terrainSize.z / 2);
            // sets the coin in a random position and slighty over the floor to give it a floation effect on it.
            Vector3 position = new Vector3(randomXpositionSpawner,terrainPos.y + 0.5f, randomZpositionSpawner);
            Instantiate(coinPrefab, position, Quaternion.identity);
            count++;
        };
    }

}
