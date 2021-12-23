using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] string enemytagName;
    [SerializeField] string allyTagName;
    GamePlayUiManager gamePlayUiManager;

    void Start()
    {
        gamePlayUiManager = FindObjectOfType<GamePlayUiManager>();
    }
    public float GetHealth()
    {
        return health;
    }
    private void ReduceHealth()
    {
        health--;
        gamePlayUiManager.UpdateHealthText();
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
            if (other.transform.TryGetComponent(out Npc npc))
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
