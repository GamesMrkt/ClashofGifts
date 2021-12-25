using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class Shoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Rigidbody rb;
    public float forceMultiplier = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Projection.Instance.ShowTrajectory();
            mousePressDownPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
            //Lock down there
            forceInit.y = Mathf.Clamp(forceInit.y, 250, 460);
            forceInit.x = Mathf.Clamp(forceInit.x, -200, 200);
            Vector3 forceV = (new Vector3(forceInit.x, forceInit.y, forceInit.y) * forceMultiplier);
            Projection.Instance.UpdateTrajectory(forceV, rb, transform.position);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mouseReleasePos = Input.mousePosition;
            Fire(mouseReleasePos - mousePressDownPos);
            Projection.Instance.HideTrajectory();
            Projection.Instance.enabled = false;
            Destroy(this.gameObject, 3f);
            Destroy(this);
        }
    }

    void Fire(Vector3 Force)
    {
        //Lock down there
        Force.y = Mathf.Clamp(Force.y, 250, 460);
        Force.x = Mathf.Clamp(Force.x, -200, 200);
        rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);
    }
    void OnEnable()
    {
        transform.rotation = Quaternion.Euler(-90, 0, 0);
        transform.position = Vector3.zero;
        Projection.Instance.ShowTrajectory();
        Projection.Instance.enabled = true;
    }
}
