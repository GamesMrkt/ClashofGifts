using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanOnTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ICollectable collectable))
        {
            collectable.GetBoost();
        }
    }
}
