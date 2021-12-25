using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Rigidbody rb;


    [Header("Force Config")]
    [SerializeField] private int xMin;
    [SerializeField] private int xMax;
    [SerializeField] private int yMin;
    [SerializeField] private int yMax;

    private Vector3 newPos;
    private float t;
    private float _time;
    public float forceMultiplier = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _time = Random.Range(1, 6);
    }
    void Update()
    {
        if (EnemyProjection.EnemyInstance != null)
        {
            t += Time.deltaTime;
            if (t >= _time)
            {
                EnemyProjection.EnemyInstance.ShowTrajectory();
                mousePressDownPos = new Vector3(Screen.width / 2, 0, 0);
                int x = Random.Range(((Screen.width / 100) * xMin), ((Screen.width / 100) * xMax));
                int y = Random.Range(((Screen.height / 100) * yMin), ((Screen.height / 100) * yMax));
                newPos = new Vector3(Screen.width / 2 + x, y, 0);
                Vector3 forceInit = (newPos - mousePressDownPos);
                forceInit.y = Mathf.Clamp(forceInit.y, 150, 500);
                Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, -forceInit.y) * forceMultiplier);
                EnemyProjection.EnemyInstance.UpdateTrajectory(forceV, rb, transform.position);

                t = 0;
                _time = Random.Range(1, 6);
                Invoke("SendDice", .5f);
            }
        }

    }

    void Fire(Vector3 Force)
    {
        Force.y = Mathf.Clamp(Force.y, 150, 500);
        rb.AddForce(new Vector3(Force.x, Force.y, -Force.y) * forceMultiplier);
    }
    void SendDice()
    {
        mouseReleasePos = newPos;
        Fire(mouseReleasePos - mousePressDownPos);
        if (EnemyProjection.EnemyInstance != null)
        {
            EnemyProjection.EnemyInstance.HideTrajectory();
            EnemyProjection.EnemyInstance.enabled = false;
        }
        Destroy(this.gameObject, 3f);
        Destroy(this);
    }
    void OnEnable()
    {
        transform.rotation = Quaternion.Euler(-90, 0, 0);
        transform.position = new Vector3(0, 0, 6.22f);
        if (EnemyProjection.EnemyInstance != null)
        {
            EnemyProjection.EnemyInstance.ShowTrajectory();
            EnemyProjection.EnemyInstance.enabled = true;
        }

    }
}
