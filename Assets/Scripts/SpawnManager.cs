using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<Transform> enemySpawnPoints;
    [SerializeField] private List<Transform> playerSpawnPoints;
    [SerializeField] private GameObject playerStickmanPrefab;
    [SerializeField] private GameObject enemyStickmanPrefab;

    [SerializeField] private float spawnTime;
    private float t;
    void Update()
    {
        t += Time.deltaTime;
        if (t >= spawnTime)
        {
            SpawnStickmans();
            t = 0;
        }
    }
    private void SpawnStickmans()
    {
        var spawnPos = playerSpawnPoints[Random.Range(0, playerSpawnPoints.Count)].transform.position;
        Instantiate(playerStickmanPrefab, spawnPos, playerStickmanPrefab.transform.rotation);
        spawnPos = enemySpawnPoints[Random.Range(0, enemySpawnPoints.Count)].transform.position;
        Instantiate(enemyStickmanPrefab, spawnPos, enemyStickmanPrefab.transform.rotation);
    }
}
