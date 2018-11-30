using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    public float movementSpeed;

    CharacterController playerOne;
    Animator animControl;

    private void Start()
    {
        playerOne = GetComponent<CharacterController>();
        animControl = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        playerOne.detectCollisions = false;
    }
    public void Update() //Player Movement
    {
        PlayerAnimator();
        Vector2 input = new Vector2(Input.GetAxisRaw("P1_Horizontal"), Input.GetAxisRaw("P1_Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
        }

        float speed = (movementSpeed) * inputDir.magnitude;

        Vector3 velocity = transform.forward * speed;
        playerOne.Move(velocity * Time.deltaTime);
    }

    private void PlayerAnimator()
    {
        if(Input.GetButton("P1_Horizontal") || (Input.GetButton("P1_Vertical")))
        {
            animControl.SetBool("IsWalking", true);
            animControl.SetBool("IsIdle", false);
            animControl.SetBool("IsPickup", false);
        }
        else if(Input.GetButton("P1_Pickup"))
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
