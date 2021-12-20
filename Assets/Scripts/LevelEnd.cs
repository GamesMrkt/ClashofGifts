using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] GameObject gamePlayUi;
    [SerializeField] Transform startPos, endPos;
    [SerializeField] private float speed;
    private bool isLevelEnd;
    private float startTime;
    private float totalDistance;
    private float currentDuration;
    private float journeyFraction;
    private float offsetForUi;
    void Start()
    {
        totalDistance = Vector3.Distance(startPos.position, endPos.position);
    }
    void Update()
    {
        if (isLevelEnd)
        {
            Destroy(gamePlayUi.gameObject);
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
                Destroy(this);
            }
        }
        startTime = startTime == 0 ? Time.time : startTime;
        currentDuration = (Time.time - startTime) * speed;
        journeyFraction = currentDuration / totalDistance;
        Camera.main.transform.position = Vector3.Lerp(startPos.position, endPos.position, journeyFraction);
        Camera.main.transform.rotation = Quaternion.Lerp(startPos.rotation, endPos.rotation, journeyFraction);
    }

}
