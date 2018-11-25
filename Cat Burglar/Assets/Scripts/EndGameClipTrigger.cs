using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameClipTrigger : MonoBehaviour {

	Animator anim;
	public GameObject playerOne;
	public GameObject playerTwo;

	private bool playerOneCollided;
	private bool playerTwoCollided;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(playerOneCollided && Input.GetKeyDown(KeyCode.LeftControl))
		{
			anim.SetTrigger("EndGame");
		}

		else if (playerTwoCollided && Input.GetKeyDown(KeyCode.RightControl))
		{
			anim.SetTrigger("EndGame");
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.name == "PlayerOne")
		{
			playerOneCollided = true;
		}

		else if (collider.gameObject.name == "PlayerTwo")
		{
			playerTwoCollided = true;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.name == "PlayerOne")
		{
			playerOneCollided = false;
		}

		else if (collider.gameObject.name == "PlayerTwo")
		{
			playerTwoCollided = false;
		}

	}
}
