using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab;

    [SerializeField]
    private float timeToSpawn = 3.0f;

    [SerializeField]
    private GameObject terrain;

    [SerializeField]
    private int spawnAmount = 85;

    private int poolPosition;

    void Awake() {
        Vector3 terrainSize = terrain.GetComponent<Renderer>().bounds.size;
        Vector3 terrainPos = terrain.transform.position;
        coinInstiante(terrainSize,terrainPos);
    }


    private void coinInstiante(Vector3 terrainSize, Vector3 terrainPos) {
        int count = 0;
        while (spawnAmount > count) {
            float randomXpositionSpawner = Random.Range(terrainPos.x - terrainSize.x / 2, terrainPos.x + terrainSize.x / 2);
            float randomZpositionSpawner = Random.Range(terrainPos.z - terrainSize.z / 2, terrainPos.z + terrainSize.z / 2);
            Vector3 position = new Vector3(randomXpositionSpawner,terrainPos.y + 0.5f, randomZpositionSpawner);    
            Instantiate(coinPrefab, position, Quaternion.identity);
            count++;
        };
    }
    
    // private IEnumerator Spawn(Vector3 terrainSize, Vector3 terrainPos) {
    //     while(true) {
            
    //         if (poolPosition == -1) {
    //             Debug.LogError("CoinSpawner::Spawn No prefab was passed");
    //             yield return null;
    //         }
    //         GameObject coin = ObjectPooler.instance.GetPooledObject(poolPosition);
    //         coin.transform.position = new Vector3(randomXpositionSpawner, terrainPos.y+0.5f, randomZpositionSpawner);
    //         coin.transform.rotation = Quaternion.identity;
    //         coin.SetActive(true);
    //         yield return new WaitForSeconds(timeToSpawn);
    //     }
    // }

}
