using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogChase : MonoBehaviour {

	public Transform playerOne;
	static Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(playerOne != null)
		{
			if (Vector3.Distance (playerOne.position, this.transform.position) < 3) //detect player within range
			{ 
				Vector3 direction = playerOne.position - this.transform.position;
				direction.y = 0; //calculate distance to player

				this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f); //rotation speed

				anim.SetBool ("IsSleeping", false);
				if (direction.magnitude > 3) //follow distance behind player
				{ 
					this.transform.Translate (0, 0, 0.20f); //chase speed
					anim.SetBool ("IsWakeUp", true);
					anim.SetBool ("IsBarking", false);
				} 
				else 
				{
					anim.SetBool ("IsBarking", true);
					anim.SetBool ("IsWakeUp", false);
				}
			} 
			else 
			{
				anim.SetBool ("IsSleeping", true);
				anim.SetBool ("IsWakeUp", false);
				anim.SetBool ("IsBarking", false);
			}
		}
	}
}
