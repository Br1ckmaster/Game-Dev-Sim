using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathTwo : MonoBehaviour 
{
    private NavMeshAgent nav;
    private EnemyTwo enemy;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        enemy = GetComponent<EnemyTwo>();
    }

    public void PathBackTwo()
    {
        if (enemy == null)
        {
            return;
        }
        nav.SetDestination(enemy.originalPos);
    }
}
