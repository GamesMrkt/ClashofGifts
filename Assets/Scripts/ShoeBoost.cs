using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoeBoost : MonoBehaviour, ICollectable
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
                if (!npc.isSpeedUp)
                {
                    npc.animator.SetBool("isFastRunning", true);
                    npc.speed = npc.speed * 2.5f;
                    npc.isSpeedUp = true;
                    npc.GetShoes();
                }
            }
            sendBoost = true;
            Destroy(this.gameObject);
        }
    }
}
