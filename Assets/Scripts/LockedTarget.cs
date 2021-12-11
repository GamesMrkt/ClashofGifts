using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedTarget : MonoBehaviour
{
    private Vector3 target { get; set; }
    private float currentLerpTime;
    private float lerpTime = 5;

    void Update()
    {
        //currentLerpTime += Time.deltaTime / 2f;
        currentLerpTime = currentLerpTime >= 1 ? 1 : currentLerpTime + (Time.deltaTime / 3f);
        float perc = currentLerpTime / lerpTime;
        transform.position = Vector3.Lerp(transform.position, target, perc);
    }
    public void SetTarget(Vector3 value)
    {
        target = value;
    }
    public Vector3 GetTarget()
    {
        return target;
    }

}
