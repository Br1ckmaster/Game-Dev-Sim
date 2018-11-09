using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{  
    static Animator anim;
    public EnemyOne enemy;

    void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemyOne>();
    }

    public void PlayerChase()
    {
        Vector3 directionOne = enemy.playerOne.position - this.transform.position;
        directionOne.y = 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(directionOne), 0.1f);
        anim.SetBool("IsIdle", false);
        if (directionOne.magnitude > 1)
        {
            this.transform.Translate(0, 0, enemy.enemySpeed);
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsAttacking", false);
        }
        else
        {
            anim.SetBool("IsAttacking", true);
            anim.SetBool("IsWalking", false);
        }

    }
}
