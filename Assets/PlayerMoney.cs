using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    [SerializeField] GameObject moneyPrefab;
    [SerializeField] float radius;
    LevelManager levelManager;
    public int money;
    bool isGameEnd;
    bool isFirstTimeMoney = true;

    void Start()
    {
        money = PlayerPrefs.GetInt("PlayerMoney", 0);
        moneyText.text = money.ToString();
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void BurstCoin()
    {
        if (isFirstTimeMoney)
        {
            int coinValue = Random.Range(25, 45);
            money += coinValue;
            PlayerPrefs.SetInt("PlayerMoney", money);
            for (int i = 0; i < coinValue; i++)
            {
                var randomPos = (Vector3)Random.insideUnitCircle * radius;
                var mousePos = Input.mousePosition;
                randomPos += mousePos;
                GameObject newObj = Instantiate(moneyPrefab, randomPos, Quaternion.identity);
                newObj.transform.SetParent(gameObject.transform);
            }
            isGameEnd = true;
            isFirstTimeMoney = false;
        }
    }

    void Update()
    {
        if (isGameEnd)
        {
            Invoke("NextLevel", 1.75f);
        }
    }
    private void NextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
