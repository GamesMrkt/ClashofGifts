using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    private CanvasManager canvasManager;
    private EnemyShoot enemyShoot;
    private EnemyTimer enemyTimer;
    private Timer timer;
    private Shoot shoot;
    [SerializeField] Transform startPos, endPos;
    [SerializeField] private float speed;
    private bool isLevelEnd;
    private bool isGetAllTiles;
    private float startTime;
    private float totalDistance;
    private float currentDuration;
    private float journeyFraction;
    private float offsetForUi;
    private int totalEnemyTile;
    private int totalPlayerTile;
    void Start()
    {
        isGetAllTiles = true;
        canvasManager = GetComponent<CanvasManager>();
        totalDistance = Vector3.Distance(startPos.position, endPos.position);
        enemyShoot = FindObjectOfType<EnemyShoot>();
        enemyTimer = FindObjectOfType<EnemyTimer>();
        timer = FindObjectOfType<Timer>();
        shoot = FindObjectOfType<Shoot>();
    }
    void Update()
    {
        if (isLevelEnd)
        {
            PlugOutGame();
            CameraPositionChange();
        }
    }
    public void MakeLevelEnd()
    {
        isLevelEnd = true;
    }
    private void CameraPositionChange()
    {
        if (Camera.main.transform.position == endPos.position)
        {

            offsetForUi += Time.deltaTime;
            if (offsetForUi > 1f)
            {
                canvasManager.ShowLevelEndUi(totalEnemyTile, totalPlayerTile);
                Destroy(this);
            }
        }

        startTime = startTime == 0 ? Time.time : startTime;
        currentDuration = (Time.time - startTime) * speed;
        journeyFraction = currentDuration / totalDistance;
        Camera.main.transform.position = Vector3.Lerp(startPos.position, endPos.position, journeyFraction);
        Camera.main.transform.rotation = Quaternion.Lerp(startPos.rotation, endPos.rotation, journeyFraction);
    }
    private void PlugOutGame()
    {
        enemyShoot.enabled = false;
        enemyTimer.enabled = false;
        timer.enabled = false;
        shoot.enabled = false;
    }
   
}
