using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneTwo: MonoBehaviour
{

	//public Transform playerOne;
	public Transform playerTwo;
	public double enemyRadius = 2;
	public float enemySpeed;
	static Animator anim;

	void Start ()
	{
		anim = GetComponent<Animator>();
	}
	void Update()
	{
		//Vector3 directionOne = playerTwo.position - this.transform.position;
		Vector3 directionTwo = playerTwo.position - this.transform.position;
		//float angle = Vector3.Angle(direction, this.transform.forward);
		if (Vector3.Distance (playerTwo.position, this.transform.position) < enemyRadius /*&& angle < 30*/) 
		{
			directionTwo.y = 0;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (directionTwo), 0.1f);
			anim.SetBool ("IsIdle", false);
			if (directionTwo.magnitude > 1) 
			{
				this.transform.Translate (0, 0, enemySpeed);
				anim.SetBool ("IsWalking", true);
				anim.SetBool ("IsAttacking", false);
			} 
			else 
			{
				anim.SetBool ("IsAttacking", true);
				anim.SetBool ("IsWalking", false);
			}

		} 
		else 
		{
			anim.SetBool ("IsIdle", true);
			anim.SetBool ("IsWalking", false);
			anim.SetBool ("IsAttacking", false);
		}

		// else if (Vector3.Distance(playerTwo.position, this.transform.position) < enemyRadius /*&& angle < 30*/)
		/* {
            directionTwo.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(directionTwo), 0.1f);
			anim.SetBool ("isIdle", false);
            if (directionTwo.magnitude > 1)
            {
                this.transform.Translate(0, 0, enemySpeed);
				anim.SetBool ("isWalking", true);
            }

        }*/
	}
}
