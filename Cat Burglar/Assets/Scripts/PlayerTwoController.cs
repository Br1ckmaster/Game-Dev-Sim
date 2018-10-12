using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    public float movementSpeed;
    CharacterController playerTwo;
    private void Start()
    {
        playerTwo = GetComponent<CharacterController>();
    }
    void Update() //Player Movement
    {

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

}
