using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] npcPrefabs;
    public Transform playerTransform;
    private GameManagerX gameManagerX;
    private float spawnRange = 5f;
    private float startDelay = 1f;
    private float spawnInterval = 2f;

    void Start()
    {
        gameManagerX = GameManagerX.instance;
        Invoke("StartSpawning", startDelay);
    }

    void StartSpawning()
    {
        if (gameManagerX != null && gameManagerX.isGameActive)
        {
            StartCoroutine(SpawnWaves());
        }
    }

    IEnumerator SpawnWaves()
    {
        while (gameManagerX.isGameActive)
        {
            for (int i = 0; i < npcPrefabs.Length; i++)
            {
                SpawnNPC();
                yield return new WaitForSeconds(spawnInterval);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnNPC()
    {
        GameObject npcPrefab = npcPrefabs[Random.Range(0, npcPrefabs.Length)];
        Vector3 spawnPos = playerTransform.position + Random.onUnitSphere * spawnRange;
        spawnPos.y = 0;
        Instantiate(npcPrefab, spawnPos, Quaternion.identity);
    }
}
