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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthText()
    {
        playerHealthTextBox.text = playerHealth.GetHealth().ToString();
        enemyHealthTextBox.text = enemyHealth.GetHealth().ToString();
    }
}
