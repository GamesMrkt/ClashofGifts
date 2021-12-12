using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] string enemytagName;
    [SerializeField] string allyTagName;
    private void ReduceHealth()
    {
        health--;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemytagName))
        {
            ReduceHealth();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag(allyTagName))
        {
            if (gameObject.transform.TryGetComponent(out Npc npc))
            {
                if (npc.isTurned)
                {
                    ReduceHealth();
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
