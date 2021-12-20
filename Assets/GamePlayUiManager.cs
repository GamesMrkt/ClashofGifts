using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayUiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHealthTextBox;
    [SerializeField] TextMeshProUGUI enemyHealthTextBox;

    [SerializeField] Health playerHealth;
    [SerializeField] Health enemyHealth;
    public void UpdateHealthText()
    {
        playerHealthTextBox.text = playerHealth.GetHealth().ToString();
        enemyHealthTextBox.text = enemyHealth.GetHealth().ToString();
        //Check If It is any health below zero
        HealthCheck();
    }
    private void HealthCheck()
    {
        if (playerHealth.GetHealth() < 1 || enemyHealth.GetHealth() < 1)
        {
            GetComponent<GameManager>().PlugOutGame(playerHealth.GetHealth(),enemyHealth.GetHealth());
        }
    }
}
