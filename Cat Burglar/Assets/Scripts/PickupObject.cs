using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PickupObject : MonoBehaviour
{

    //public Text scoreText;
    public PlayerLine playerOneLine;
    public PlayerLine playerTwoLine;

    public Text playerOneText;
    public Text playerTwoText;

    bool playerOneCollided;
    bool playerTwoCollided;

    private int playerOneScore = 0;
    private int playerTwoScore = 0;

    private static int playerOneFinal = 0;
    private static int playerTwoFinal = 0;

    void Start()
    {

    }

    void Update()
    {
        if (playerOneCollided && Input.GetKeyDown(KeyCode.LeftControl))
        {
            PickUp();

            if(gameObject.tag == "GroupA")
            {
                playerOneScore += 1;
                playerOneFinal += playerOneScore;
                playerOneText.text = "Score: " + playerOneFinal.ToString();
            }
            else if (gameObject.tag == "GroupB")
            {
                playerOneScore += 2;
                playerOneFinal += playerOneScore;
                playerOneText.text = "Score: " + playerOneFinal.ToString();
            }
            else if (gameObject.tag == "GroupC")
            {
                playerOneScore += 3;
                playerOneFinal += playerOneScore;
                playerOneText.text = "Score: " + playerOneFinal.ToString();
            }
        }

        else if (playerTwoCollided && Input.GetKeyDown(KeyCode.RightControl))
        {
            PickUp();

            if (gameObject.tag == "GroupA")
            {
                playerTwoScore += 1;
                playerTwoFinal += playerTwoScore;
                playerTwoText.text = "Score: " + playerTwoFinal.ToString();
            }
            else if (gameObject.tag == "GroupB")
            {
                playerTwoScore += 2;
                playerTwoFinal += playerTwoScore;
                playerTwoText.text = "Score: " + playerTwoFinal.ToString();
            }
            else if (gameObject.tag == "GroupC")
            {
                playerTwoScore += 3;
                playerTwoFinal += playerTwoScore;
                playerTwoText.text = "Score: " + playerTwoFinal.ToString();
            }
        }

        if (playerTwoCollided && Input.GetKeyDown(KeyCode.RightControl))
        {
            PickUp();
        }
    }


    void OnTriggerEnter(Collider collider) //When player collides with object
    {

        if (collider.gameObject.name == "PlayerOne")
        {
            playerOneCollided = true;
        }

        else if (collider.gameObject.name == "PlayerTwo")
        {
            playerTwoCollided = true;
        }
    }

    void OnTriggerExit(Collider collider) //When player two exits object collider
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

    void PickUp()
    {
        Destroy(gameObject);
    }

}

