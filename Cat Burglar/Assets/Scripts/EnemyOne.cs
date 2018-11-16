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

	public Animator anim;

    [HideInInspector]
    public Vector3 originalPos;

    private Chase chase;
    private Path path;

    void Awake()
    {
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
            if (Vector3.Distance(playerOne.position, gameObject.transform.position) < enemyRadiusP1)
            {
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsAttacking", false);

                chase.enabled = true;
                path.enabled = false;
                chase.PlayerChase();
            }

            //else if (Vector3.Distance(playerOne.position, gameObject.transform.position) > enemyRadiusP1 + enemyTrailDistance)
            //{
            //    anim.SetBool("IsIdle", false);
            //    anim.SetBool("IsWalking", false);
            //    anim.SetBool("IsAttacking", false);

            //    path.enabled = true;
            //    chase.enabled = false;
            //    path.PathBack();
            //}
        }
        else
        {
            anim.SetBool("IsIdle", false);
            //anim.SetBool("IsWalking", true);
            anim.SetBool("IsAttacking", false);

            path.enabled = true;
            chase.enabled = false;
            path.PathBack();
        }
    }





}
