using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShirtBoost : MonoBehaviour, ICollectable
{
    bool sendBoost = false;
    void Start()
    {
        Destroy(this.gameObject, 10);
    }
    public void GetBoost(GameObject gameObject)
    {
        if (!sendBoost)
        {
            if (gameObject.transform.TryGetComponent(out Npc npc))
            {
                if (!npc.isShirted)
                {
                    npc.isShirted = true;
                    npc.charModel.gameObject.SetActive(false);
                    npc.charModelTshirt.gameObject.SetActive(true);
                }
                sendBoost = true;
                Destroy(this.gameObject);
            }
        }
    }
}
