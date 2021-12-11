using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("LevelEnd Ui")]
    [SerializeField] private GameObject LevelEndUi;
    [SerializeField] private TextMeshProUGUI enemyTeamScoreTextBox;
    [SerializeField] private TextMeshProUGUI playerTeamScoreTextBox;
    [SerializeField] private GameObject goodFace;
    [SerializeField] private GameObject badFace;
    [SerializeField] private Image ButtonImage;
    [SerializeField] private TextMeshProUGUI ButtonTextBox;

    [Header("Properties")]
    [SerializeField] private Sprite winButtonSprite;
    [SerializeField] private Sprite loseButtonSprite;
    [SerializeField] private string winButtonText;
    [SerializeField] private string loseButtonText;

    LevelChecker levelChecker;
    private LevelManager levelManager;
    private void Start()
    {
        levelChecker = FindObjectOfType<LevelChecker>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void ShowLevelEndUi(int enemyTeam, int playerTeam)
    {
        bool isGameWin;
        if (enemyTeam > playerTeam)
        {
            isGameWin = false;
            //TinySauce.OnGameFinished(false, playerTeam, levelNumber: levelChecker.GetLevel());
        }
        else
        {
            isGameWin = true;
           // TinySauce.OnGameFinished(true, playerTeam, levelNumber: levelChecker.GetLevel());
        }

        enemyTeamScoreTextBox.text = enemyTeam.ToString();
        playerTeamScoreTextBox.text = playerTeam.ToString();

        SetFaceType(isGameWin);
        SetButtonType(isGameWin);

        LevelEndUi.SetActive(true);
    }
    private void SetFaceType(bool state)
    {
        if (state)
        { badFace.SetActive(false); goodFace.SetActive(true); }
        else
        { badFace.SetActive(true); goodFace.SetActive(false); }
    }
    private void SetButtonType(bool state)
    {
        if (state)
        {
            ButtonImage.sprite = winButtonSprite; ButtonTextBox.text = winButtonText;
            ButtonImage.gameObject.GetComponent<Button>().onClick.AddListener(delegate { levelManager.LoadNextLevel(); });
        }
        else
        {
            ButtonImage.sprite = loseButtonSprite; ButtonTextBox.text = loseButtonText;
            ButtonImage.gameObject.GetComponent<Button>().onClick.AddListener(delegate { levelManager.RestartLevel(); });
        }


    }
}
