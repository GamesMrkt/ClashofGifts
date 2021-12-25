using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashSpawner : MonoBehaviour
{
    [SerializeField] GameObject playerSplash;
    [SerializeField] GameObject enemySplash;

    public void Splash(Vector3 position, string team)
    {
        if (team == "Player")
        {
            var splash = Instantiate(playerSplash, position + Vector3.up * .01f, Quaternion.identity);
            Destroy(splash, 5f);
        }
        else
        {
            var splash = Instantiate(enemySplash, position + Vector3.up * .01f, Quaternion.identity);
            Destroy(splash, 5f);
        }
    }
}
