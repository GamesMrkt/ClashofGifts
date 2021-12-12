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
        for (int i = 0; i < playerSpawnPoints.Count; i++)
        {
            var spawnPos = playerSpawnPoints[i].transform.position;
            Instantiate(playerStickmanPrefab, spawnPos, playerStickmanPrefab.transform.rotation);
            spawnPos = enemySpawnPoints[i].transform.position;
            Instantiate(enemyStickmanPrefab, spawnPos, enemyStickmanPrefab.transform.rotation);
        }
    }
}
