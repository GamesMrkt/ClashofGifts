using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyScoreManager : MonoBehaviour
{
    [SerializeField] private int Score;
    [SerializeField] private List<TextMeshProUGUI> DiceTextBoxes;
    public void AddScore(int addScore = 1)
    {
        Score += addScore;
        for (int i = 0; i < DiceTextBoxes.Count; i++)
        {
            DiceTextBoxes[i].text = Score.ToString();
        }
    }
    public int GetScore()
    {
        return Score;
    }
    public void ResetScore()
    {
        Score = 0;
        for (int i = 0; i < DiceTextBoxes.Count; i++)
        {
            DiceTextBoxes[i].text = "0";
        }
    }
}
