using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Image radialBar;
    BoostManager boostManager;
    Shoot shoot;
    private float t;
    void Start()
    {
        shoot = FindObjectOfType<Shoot>();
        boostManager = GetComponent<BoostManager>();
    }
    void Update()
    {
        if (t >= time)
        {
            //TODO
            //Kullanılacak Boost Varmı Diye Kontrol Et;
            shoot = FindObjectOfType<Shoot>();
            if (shoot)
            {
                //Boost Var ise Atılmasını Bekle;
                return;
            }
            else
            {
                //Yok İse Yeni Boostu Spawn Et;
                //TODO BURAYA BİR BOOSTMANAGER EKLE RANDOM BİR BOOST VERSİN ANİMASYON İLE BERABER
                t = 0;
                Invoke("SpawnBoost", .25f);
            }
        }
        else
        {
            t += Time.deltaTime;
        }
        float progress = (((t / time) * 100) / 100);
        radialBar.fillAmount = progress;
    }
    private void SpawnBoost()
    {
        boostManager.SpawnBoost(Vector3.zero);
    }
}
