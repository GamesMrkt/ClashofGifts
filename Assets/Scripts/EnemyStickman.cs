using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SelectionBase]
public class EnemyStickman : Npc
{

    private EnemyStickman enemyStickman;
    private PlayerStickman playerStickman;
    private GameObject collidedGameObj;

    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);

        if (other.transform.CompareTag("PlayerStickman"))
        {
            collidedGameObj = other.gameObject;
            playerStickman = collidedGameObj.transform.GetComponent<PlayerStickman>();
            if (!playerStickman.isTurned)
            {
                Stop();
                animator.SetBool("isHitting", true);
            }
        }
        else if (other.transform.CompareTag("EnemyStickman"))
        {
            collidedGameObj = other.gameObject;
            enemyStickman = collidedGameObj.transform.GetComponent<EnemyStickman>();
            if (enemyStickman.isTurned)
            {
                Stop();
                animator.SetBool("isHitting", true);
            }
            else if (this.isTurned)
            {
                Stop();
                animator.SetBool("isHitting", true);
            }
        }
    }
    public void DoHit()
    {
        if (collidedGameObj = null)
        {
            return;
        }

        if (playerStickman)
        {
            if (!playerStickman.isTurned)
            {
                animator.SetBool("isHitting", true);
                if (playerStickman.isShirted)
                {
                    if (this.isShirted)
                    {
                        //TODO Destroy ME AND HİM
                        splashSpawner.Splash(this.transform.position, "Enemy");
                        Destroy(gameObject);
                        Destroy(collidedGameObj);
                    }
                    else
                    {
                        //TODO DESTROY JUST ME
                        splashSpawner.Splash(this.transform.position, "Enemy");
                        Destroy(gameObject);
                    }
                }
                else
                {
                    if (isShirted)
                    {
                        //TODO Destroy JUST HIM
                        Destroy(collidedGameObj);
                    }
                    else
                    {
                        //TODO DESTROY ME AND HİM
                        splashSpawner.Splash(this.transform.position, "Enemy");
                        Destroy(gameObject);
                        Destroy(collidedGameObj);
                    }
                }
            }

        }
        else if (enemyStickman)
        {
            if (enemyStickman.isTurned)
            {
                animator.SetBool("isHitting", true);
                if (enemyStickman.isShirted)
                {
                    if (this.isShirted)
                    {
                        //TODO Destroy ME AND HİM
                        splashSpawner.Splash(this.transform.position, "Enemy");
                        Destroy(gameObject);
                        Destroy(enemyStickman.gameObject);
                    }
                    else
                    {
                        //TODO DESTROY JUST ME
                        splashSpawner.Splash(this.transform.position, "Enemy");
                        Destroy(gameObject);
                    }
                }
                else
                {
                    if (isShirted)
                    {
                        //TODO Destroy JUST HIM
                        Destroy(enemyStickman.gameObject);
                    }
                    else
                    {
                        //TODO DESTROY ME AND HİM
                        splashSpawner.Splash(this.transform.position, "Enemy");
                        Destroy(gameObject);
                        Destroy(enemyStickman.gameObject);
                    }
                }
            }
            else if (this.isTurned)
            {
                animator.SetBool("isHitting", true);
                if (enemyStickman.isShirted)
                {
                    if (this.isShirted)
                    {
                        //TODO Destroy ME AND HİM
                        splashSpawner.Splash(this.transform.position, "Enemy");
                        Destroy(gameObject);
                        Destroy(enemyStickman.gameObject);
                    }
                    else
                    {
                        //TODO DESTROY JUST ME
                        splashSpawner.Splash(this.transform.position, "Enemy");
                        Destroy(gameObject);
                    }
                }
                else
                {
                    if (isShirted)
                    {
                        //TODO Destroy JUST HIM
                        Destroy(enemyStickman.gameObject);
                    }
                    else
                    {
                        //TODO DESTROY ME AND HİM
                        splashSpawner.Splash(this.transform.position, "Enemy");
                        Destroy(gameObject);
                        Destroy(enemyStickman.gameObject);
                    }
                }
            }
        }
        animator.SetBool("isHitting", false);
        GoOn();
        collidedGameObj = null;
    }
}
