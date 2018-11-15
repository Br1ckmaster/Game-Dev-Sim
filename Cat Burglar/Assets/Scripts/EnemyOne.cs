using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyOne: MonoBehaviour
{
    public Transform playerOne;
    //public Transform playerTwo;
    public double enemyRadiusP1 = 2;
    public double enemyRadiusP2 = 2;
    public double enemyTrailDistance = 3;
    //public float enemySpeed;

	static Animator anim;

    [HideInInspector]
    public Vector3 originalPos;

    private NavMeshAgent nav;

    private Chase chase;
    private Path path;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        originalPos = gameObject.transform.position;
    }

    void Start ()
	{
		anim = GetComponent<Animator>();
        chase = GetComponent<Chase>();
        path = GetComponent<Path>();

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
            if (Vector3.Distance(playerOne.position, this.transform.position) < enemyRadiusP1)
            {
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsAttacking", false);

                chase.enabled = true;
                path.enabled = false;
                chase.PlayerChase();
            }

            else if (Vector3.Distance(playerOne.position, this.transform.position) > enemyRadiusP1/* + 4*/)
            {
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsAttacking", false);

                path.enabled = true;
                chase.enabled = false;
                path.PathBack();
            }
        }
        else
        {
            anim.SetBool("IsIdle", false);
            anim.SetBool("IsWalking", true);
            anim.SetBool("IsAttacking", false);

            path.enabled = true;
            chase.enabled = false;
            path.PathBack();
        }

        //else if (Vector3.Distance(playerOne.position, this.transform.position) > enemyRadiusP1)
        //{
        //    Patrolling();
        //}
        //else if (Vector3.Distance(playerTwo.position, this.transform.position) < enemyRadiusP2 /*&& angle < 30*/)
        //{
        //    Vector3 directionTwo = playerTwo.position - this.transform.position;

        //    directionTwo.y = 0;
        //    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(directionTwo), 0.1f);
        //    anim.SetBool("IsIdle", false);
        //    if (directionTwo.magnitude > 1)
        //    {
        //        this.transform.Translate(0, 0, enemySpeed);
        //        anim.SetBool("IsWalking", true);
        //        anim.SetBool("IsAttacking", false);
        //    }
        //    else
        //    {
        //        anim.SetBool("IsAttacking", true);
        //        anim.SetBool("IsWalking", false);
        //    }
        //}

        //else
        //{
        //    anim.SetBool("IsIdle", true);
        //    anim.SetBool("IsWalking", false);
        //    anim.SetBool("IsAttacking", false);
        //    chase.enabled = false;
        //}
    }





}
