using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjection : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField, Range(3, 500)] private int lineSegmentCount = 20;
    [SerializeField] Transform targetPoint;
    private List<Vector3> linePoints = new List<Vector3>();
    public LayerMask CollidableLayers;

    #region Singleton
    public static EnemyProjection EnemyInstance;
    void Awake()
    {
        EnemyInstance = this;
    }
    #endregion

    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidbody, Vector3 startPoint)
    {
        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;
        float FlightDuration = (4 * velocity.y) / Physics.gravity.y;
        float stepTime = FlightDuration / lineSegmentCount;
        linePoints.Clear();

        for (int i = 0; i < lineSegmentCount; i++)
        {
            float _stepTimePassed = stepTime * i;//change in time;

            Vector3 MovementVector = new Vector3(
                velocity.x * _stepTimePassed,
                velocity.y * _stepTimePassed - 0.5f * Physics.gravity.y * _stepTimePassed * _stepTimePassed,
                velocity.z * _stepTimePassed
            );

            Vector3 newPoint = (-MovementVector + startPoint);
            linePoints.Add(newPoint);
            if (Physics.OverlapSphere(newPoint, .025f, CollidableLayers).Length > 0)
            {
                lineRenderer.positionCount = linePoints.Count;
                targetPoint.gameObject.SetActive(true);
                targetPoint.transform.position = newPoint;
                break;
            }
            else
            {
                targetPoint.gameObject.SetActive(false);
            }
        }

        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());
    }

    public void HideTrajectory()
    {
        lineRenderer.positionCount = 0;
        lineRenderer.gameObject.SetActive(false);
        targetPoint.gameObject.SetActive(false);
    }
    public void ShowTrajectory()
    {
        lineRenderer.gameObject.SetActive(true);
    }

}
