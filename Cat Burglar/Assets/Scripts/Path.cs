using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Path : MonoBehaviour
{
    static Animator anim;

    //public Transform[] waypoints;
    //public float minWaypointDistance = 0.1f;

    private NavMeshAgent nav;
    private EnemyOne enemy;

    //private int curWaypoint = 0;
    //private int maxWaypoint;
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        //maxWaypoint = waypoints.Length;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        enemy = GetComponent<EnemyOne>();
    }

    public void PathBack()
    {

        // nav.speed = enemy.enemySpeed * 50;

        //Vector3 tempPos;
        //Vector3 tempWaypointPos;

        //tempPos = transform.position;
        //tempPos.y = 0f;

        ////this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(tempPos), 0.05f);


        //tempWaypointPos = waypoints[curWaypoint].position;
        //tempWaypointPos.y = 0f;

        //if (Vector3.Distance(tempPos, tempWaypointPos) <= minWaypointDistance)
        //{
        //    if (curWaypoint == maxWaypoint)
        //        curWaypoint = 0;
        //    else
        //        curWaypoint++;
        //}
        if (enemy == null)
        {
            return;
        }

        nav.SetDestination(enemy.originalPos);
    }
}
