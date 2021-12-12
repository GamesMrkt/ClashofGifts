using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBoost : MonoBehaviour, ICollectable
{
    // Start is called before the first frame update
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
                if (!npc.isTurned)
                {
                    npc.isTurned = true;
                    npc.ChangeSide();
                    var rotationVector = gameObject.transform.rotation.eulerAngles;
                    gameObject.transform.rotation = Quaternion.Euler(rotationVector + new Vector3(0, 180, 0));
                }
                sendBoost = true;
                Destroy(this.gameObject);
            }
        }
    }
}
