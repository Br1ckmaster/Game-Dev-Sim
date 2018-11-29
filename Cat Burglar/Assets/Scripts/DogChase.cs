using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogChase : MonoBehaviour {

	public Transform playerOne;
    public double dogRadiusP1 = 2;

	public Animator anim;
    public EnemyOne enemyOneDetection;
    public EnemyTwo enemyTwoDetection;
    public PlayerLine playerOneRadius;

    private bool playerDetected = false;

	public void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	public void Update ()
	{
		if (playerOne != null)
		{
			if (Vector3.Distance (playerOne.position, this.transform.position) < dogRadiusP1)
			{
                Vector3 direction = playerOne.position - this.transform.position;
				direction.y = 0;

				this.transform.rotation = Quaternion.Slerp (this.transform.rotation, 
                                            Quaternion.LookRotation (direction), 0.1f);

				anim.SetBool ("IsSleeping", false);
                anim.SetBool ("IsBarking", true);
                anim.SetBool ("IsWakeUp", false);

                if (!playerDetected)
                {
                    DetectionIncrease();
                }

            }
            else if (Vector3.Distance(playerOne.position, this.transform.position) > dogRadiusP1)
            {
				anim.SetBool ("IsSleeping", true);
				anim.SetBool ("IsWakeUp", false);
				anim.SetBool ("IsBarking", false);
                if (playerDetected)
                {
                    StartCoroutine(DetectionShrink());
                    playerDetected = false;
                }
            }
		}
	}
    public void DetectionIncrease()
    {
        playerDetected = true;
        playerOneRadius.radius += 2;
        enemyOneDetection.enemyRadiusP1 += 2.5;
        enemyTwoDetection.enemyRadiusP1 += 2.5;
        dogRadiusP1 += 2.5;
    }

    private IEnumerator DetectionShrink()
    {
        yield return new WaitForSeconds(3.0f);
        playerOneRadius.radius -= 2;
        enemyOneDetection.enemyRadiusP1 -= 2.5;
        enemyTwoDetection.enemyRadiusP1 -= 2.5;
        dogRadiusP1 -= 2.5;
    }
}
