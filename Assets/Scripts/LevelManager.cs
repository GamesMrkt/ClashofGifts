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
        allSceneCount = SceneManager.sceneCountInBuildSettings - 1;
    }
    public void LoadNextLevel()
    {
        if (currentSceneIndex < allSceneCount)
        {
            currentSceneIndex++;
            SceneManager.LoadScene(currentSceneIndex);
        }
        else
        {
            //FIXME BURASI TÜM LEVELLER BİTTİĞİNDE KAÇINCI LEVELDEN BAŞLAYACAĞINI BELİRLEMEK İÇİN
            SceneManager.LoadScene(2);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
