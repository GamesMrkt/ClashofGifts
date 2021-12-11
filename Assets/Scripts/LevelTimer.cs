using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float levelTime;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    private LevelEnd levelEnd;
    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = levelTime;
        slider.value = levelTime;
        levelEnd = GetComponent<LevelEnd>();
    }
    void Update()
    {
        ShowTheGameTime();
    }
    private void ShowTheGameTime()
    {
        if (levelTime > 0) { levelTime -= Time.deltaTime; }
        else
        {
            levelTime = 0;
            levelEnd.MakeLevelEnd();
            Destroy(this);
        }
        
        slider.value = levelTime;
        if (levelTime > 10)
        {
            textMeshPro.text = levelTime.ToString().Substring(0, 2);
        }
        else
        {
            textMeshPro.text = levelTime.ToString().Substring(0, 1);
        }

    }
    public float GetTime()
    {
        return levelTime;
    }
}
