using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Path : MonoBehaviour
{
    private NavMeshAgent nav;
    private EnemyOne enemy;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        enemy = GetComponent<EnemyOne>();
    }

    public void PathBack()
    {
        if (enemy == null)
        {
            return;
        }
        nav.SetDestination(enemy.originalPos);
    }
}
