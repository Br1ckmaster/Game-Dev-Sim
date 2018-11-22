using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{  
    public Animator anim;
    public GameObject player;

    private NavMeshAgent nav;
    private EnemyOne enemy;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemyOne>();
    }

    public void PlayerChase()
    {
        if (enemy == null)
        {
            return;
        }

            nav.SetDestination(enemy.playerOne.position);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //anim.SetBool("IsWalking", false);
        //anim.SetBool("IsAttacking", true);
        switch (collision.gameObject.name)
        {
            case "PlayerOne": Destroy(player); break;
        }
    }
}
