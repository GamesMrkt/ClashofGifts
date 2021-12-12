using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class EnemyStickman : Npc
{
    // Start is called before the first frame update
    private PlayerStickman playerStickman;
    private EnemyStickman enemyStickman;
    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        if (other.transform.CompareTag("PlayerStickman"))
        {
            playerStickman = other.transform.GetComponent<PlayerStickman>();
            if (!playerStickman.isTurned)
            {
                if (playerStickman.isShirted)
                {
                    if (this.isShirted)
                    {
                        //TODO Destroy ME AND HİM
                        Destroy(this.gameObject);
                        Destroy(other.gameObject);
                    }
                    else
                    {
                        //TODO DESTROY JUST ME
                        Destroy(this.gameObject);
                    }
                }
                else
                {
                    if (this.isShirted)
                    {
                        //TODO Destroy JUST HIM
                        Destroy(other.gameObject);
                    }
                    else
                    {
                        //TODO DESTROY ME AND HİM
                        Destroy(this.gameObject);
                        Destroy(other.gameObject);
                    }
                }
            }

        }
        else if (other.transform.CompareTag("EnemyStickman"))
        {
            enemyStickman = other.transform.GetComponent<EnemyStickman>();
            if (enemyStickman.isTurned)
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
        }
    }

}