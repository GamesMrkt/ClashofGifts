using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Vector3 placeToGo;
    private bool isGoing;
    void Start()
    {
        placeToGo = new Vector3(Screen.width, Screen.height, 0);
    }
    void OnEnable()
    {
        placeToGo = new Vector3(Screen.width, Screen.height, 0);
    }
    void Update()
    {
        if (isGoing)
        {
            transform.position = Vector3.Lerp(transform.position, placeToGo, 7 * Time.deltaTime);
        }

        if (transform.position.magnitude * 1.005 > placeToGo.magnitude)
        {
            Destroy(gameObject);
        }
    }
    public void GoToMoney()
    {
        isGoing = true;
    }
}
