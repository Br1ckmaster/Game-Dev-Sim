using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwo : MonoBehaviour
{
    public Transform playerOne;
    public double enemyRadiusP1 = 2;
    public double enemyRadiusP2 = 2;
    public double enemyTrailDistance = 3;

    public Animator anim;

    [HideInInspector]
    public Vector3 originalPos;

    private ChaseTwo chase;
    private PathTwo path;

    void Awake()
    {
        originalPos = gameObject.transform.position;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        chase = GetComponent<ChaseTwo>();
        path = GetComponent<PathTwo>();

        anim.SetBool("IsIdle", true);
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsAttacking", false);

        chase.enabled = false;
        path.enabled = false;
    }
    void Update()
    {
        if (playerOne != null)
        {
            if (Vector3.Distance(playerOne.position, gameObject.transform.position) < enemyRadiusP1)
            {
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsAttacking", false);

                chase.enabled = true;
                path.enabled = false;
                chase.PlayerChaseTwo();
            }

            else if (Vector3.Distance(playerOne.position, gameObject.transform.position) > enemyRadiusP1 + enemyTrailDistance)
            {
				anim.SetBool("IsIdle", false);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsAttacking", false);

                path.enabled = true;
                chase.enabled = false;
                path.PathBackTwo();
            }
        }
        else
        {
			anim.SetBool("IsIdle", false);
            //anim.SetBool("IsWalking", true);
            anim.SetBool("IsAttacking", false);

            path.enabled = true;
            chase.enabled = false;
            path.PathBackTwo();
        }
    }



}
