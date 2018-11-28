using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseTwo : MonoBehaviour {
    public Animator anim;
    public GameObject player;

    private NavMeshAgent nav;
    private EnemyTwo enemy;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemyTwo>();
    }

    public void PlayerChaseTwo()
    {
        if (enemy == null)
        {
            return;
        }
        nav.SetDestination(enemy.playerOne.position);
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsWalking", true);
        anim.SetBool("IsAttacking", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player": Destroy(player); break;
        }
    }
}
