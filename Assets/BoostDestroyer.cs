using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.transform.gameObject.layer == LayerMask.NameToLayer("Collectable"))
        {
            Destroy(other.gameObject);
        }
    }

}
