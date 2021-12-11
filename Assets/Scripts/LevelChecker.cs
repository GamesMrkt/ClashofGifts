using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChecker : MonoBehaviour
{
    [SerializeField] private string LevelName;
    void Start()
    {
        //TinySauce.OnGameStarted(levelNumber: LevelName);
    }
    public string GetLevel()
    {
        return LevelName;
    }
}
