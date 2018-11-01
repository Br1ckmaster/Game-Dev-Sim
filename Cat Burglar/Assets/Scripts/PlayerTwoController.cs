using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    CharacterController playerTwo;
	Animator animControl;
	private void Start()
    {
        playerTwo = GetComponent<CharacterController>();
		animControl = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<Animator>();
    }
    void Update() //Player Movement
    {
		PlayerAnimator();
        Vector2 input = new Vector2(Input.GetAxisRaw("P2_Horizontal"), Input.GetAxisRaw("P2_Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
        }

        float speed = (movementSpeed) * inputDir.magnitude;

        Vector3 velocity = transform.forward * speed;
        playerTwo.Move(velocity * Time.deltaTime);
    }

	void PlayerAnimator()
	{

		if(Input.GetButton("P2_Horizontal") || (Input.GetButton("P2_Vertical")))
		{
			animControl.SetBool("IsWalking", true);
			animControl.SetBool("IsIdle", false);
			animControl.SetBool("IsPickup", false);
		}
		else if(Input.GetButton("P2_Pickup"))
		{
			animControl.SetBool("IsWalking", false);
			animControl.SetBool("IsIdle", false);
			animControl.SetBool("IsPickup", true);
		}

		else
		{
			animControl.SetBool("IsWalking", false);
			animControl.SetBool("IsIdle", true);
			animControl.SetBool("IsPickup", false);
		}
	}

}
