using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LevelEnd levelEnd;
    SpawnManager spawnManager;
    EnemyProjection enemyProjection;
    public float PlayerScore;
    public float EnemyScore;

    void Awake()
    {
        TinySauce.OnGameStarted();
    }
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        enemyProjection = FindObjectOfType<EnemyProjection>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlugOutGame(5, 0);
        }
    }

    public void PlugOutGame(float playerScore, float enemyScore)
    {

        Npc[] npcs = FindObjectsOfType<Npc>();
        for (int i = 0; i < npcs.Length; i++)
        {
            Destroy(npcs[i].gameObject);
        }
        PlayerScore = playerScore;
        EnemyScore = enemyScore;
        Destroy(spawnManager);
        Destroy(enemyProjection);
        StartCoroutine(LevelEnd());
        TinySauce.OnGameFinished(playerScore);

    }
    IEnumerator LevelEnd()
    {
        levelEnd.MakeLevelEnd();
        yield return new WaitForSeconds(1f);
        GetComponent<LeagueUiManager>().Show();
    }
}
