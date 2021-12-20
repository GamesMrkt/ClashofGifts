using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int currentSceneIndex;
    int allSceneCount;
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
