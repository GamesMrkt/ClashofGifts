using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeagueUiManager : MonoBehaviour
{
    [SerializeField] GameObject LeagueUi;
    [SerializeField] TextMeshProUGUI WorldRankText;
    [SerializeField] GameObject tapToContinue;
    int addScoreValue;
    int worldRank;
    int singleValue = 0;
    void Start()
    {
        worldRank = PlayerPrefs.GetInt("WorldRank", 9997285);
        WorldRankText.text = "# " + worldRank.ToString();
    }

    // Update is called once per frame
    public void Show()
    {
        LeagueUi.gameObject.SetActive(true);
        CheckGameStatus();
    }
    private void CheckGameStatus()
    {
        if (GetComponent<GameManager>().PlayerScore > GetComponent<GameManager>().EnemyScore)
        {
            //Win
            singleValue = -1;
            addScoreValue = Random.Range(-100, -1000);

            if (addScoreValue > -250)
                StartCoroutine(SetWorldRank(0.01f));
            else
                StartCoroutine(SetWorldRank(0.001f));
        }
        else
        {
            //Lose
            singleValue = 1;
            addScoreValue = Random.Range(50, 250);
            StartCoroutine(SetWorldRank(0.01f));
        }
    }

    IEnumerator SetWorldRank(float countTime)
    {
        yield return new WaitForSeconds(1.5f);
        int tempWorldRank = worldRank + addScoreValue;
        while (tempWorldRank != worldRank)
        {
            yield return new WaitForSeconds(countTime);
            worldRank += singleValue;
            WorldRankText.text = "# " + worldRank.ToString();
        }
        worldRank = tempWorldRank;
        PlayerPrefs.SetInt("WorldRank", worldRank);
        yield return new WaitForSeconds(.5f);
        tapToContinue.SetActive(true);
    }
}
