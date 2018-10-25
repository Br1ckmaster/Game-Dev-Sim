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

    private bool playerOneCollided;
    private bool playerTwoCollided;

    private static bool p1FirstRadius;
    private static bool p1SecondRadius;
    private static bool p1ThirdRadius;

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
            Destroy(gameObject);

            switch (gameObject.tag)
            {
                case "GroupA":  playerOneScore += 1;
                                playerOneFinal += playerOneScore;
                                playerOneText.text = "Score: " + playerOneFinal.ToString();
                    break;

                case "GroupB":
                                playerOneScore += 2;
                                playerOneFinal += playerOneScore;
                                playerOneText.text = "Score: " + playerOneFinal.ToString();
                    break;

                case "GroupC":
                                playerOneScore += 3;
                                playerOneFinal += playerOneScore;
                                playerOneText.text = "Score: " + playerOneFinal.ToString();
                    break;
            }
        }
        
        else if (playerTwoCollided && Input.GetKeyDown(KeyCode.RightControl))
        {
            Destroy(gameObject);

            switch (gameObject.tag)
            {
                case "GroupA":
                                playerTwoScore += 1;
                                playerTwoFinal += playerTwoScore;
                                playerTwoText.text = "Score: " + playerTwoFinal.ToString();
                    break;

                case "GroupB":
                                playerTwoScore += 2;
                                playerTwoFinal += playerTwoScore;
                                playerTwoText.text = "Score: " + playerTwoFinal.ToString();
                    break;

                case "GroupC":
                                playerTwoScore += 3;
                                playerTwoFinal += playerTwoScore;
                                playerTwoText.text = "Score: " + playerTwoFinal.ToString();
                    break;
            }
        }
    }


    void OnTriggerEnter(Collider collider) //When player collides with object
    {
        switch(collider.gameObject.name)
        {
            case "PlayerOne": playerOneCollided = true; break;
            case "PlayerTwo": playerTwoCollided = true; break;
        }
    }

    void OnTriggerExit(Collider collider) //When player two exits object collider
    {
        switch (collider.gameObject.name)
        {
            case "PlayerOne": playerOneCollided = false; break;
            case "PlayerTwo": playerTwoCollided = false; break;
        }
    }

    //void PickUp()
    //{
    //    Destroy(gameObject);
    //}

    void OnDestroy()
    {
        if (playerOneFinal >= 3 && !p1FirstRadius)
        {
            playerOneLine.radius += 1;
            p1FirstRadius = true;
        }

        else if (playerOneFinal >= 7 && !p1SecondRadius)
        {
            playerOneLine.radius += 2;
            p1SecondRadius = true;
        }
    }
    
}
