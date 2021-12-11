using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTimer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private Image radialBar;
    BoostManager boostManager;
    EnemyShoot shoot;
    private float t;
    void Start()
    {
        shoot = FindObjectOfType<EnemyShoot>();
        boostManager = GetComponent<BoostManager>();
    }
    void Update()
    {
        if (t >= time)
        {
            //TODO
            //Kullanılacak Boost Varmı Diye Kontrol Et;
            shoot = FindObjectOfType<EnemyShoot>();
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
        boostManager.SpawnBoost(new Vector3(0, 0, 6.2f));
    }
}
