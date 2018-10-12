using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    public float movementSpeed;
    CharacterController playerOne;
    private void Start()
    {
        playerOne = GetComponent<CharacterController>();
    }
    void Update() //Player Movement
    {

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

}
