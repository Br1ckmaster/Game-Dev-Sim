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

    public EnemyOne enemyOneRangeP1;
    public EnemyOne enemyOneRangeP2;

    public EnemyTwo enemyTwoRangeP1;
    public EnemyTwo enemyTwoRangeP2;

    public Text playerOneText;
    public Text playerTwoText;

    private bool playerOneCollided;
    private bool playerTwoCollided;

    private static bool p1FirstRadiusChanged;
    private static bool p1SecondRadiusChanged;
    private static bool p1ThirdRadiusChanged;

    private static bool p2FirstRadiusChanged;
    private static bool p2SecondRadiusChanged;
    private static bool p2ThirdRadiusChanged;

    private int playerOneScore = 0;
    private int playerTwoScore = 0;

    private static int playerOneFinal = 0;
    private static int playerTwoFinal = 0;

    void Update()
    {
        if (playerOneCollided && Input.GetButton("P1_Pickup") &&
        !Input.GetButton("P1_Horizontal") && !Input.GetButton("P1_Vertical"))
        {
            StartCoroutine(PlayerOnePickupDelay());
        }

        else if (playerTwoCollided && Input.GetButton("P2_Pickup") &&
        !Input.GetButton("P2_Horizontal") && !Input.GetButton("P2_Vertical"))
        {
            StartCoroutine(PlayerTwoPickupDelay());
        }

        else if (playerOneCollided && Input.GetButton("P1_Pickup"))
        {
            PlayerOnePickup();
        }

        else if (playerTwoCollided && Input.GetButton("P2_Pickup"))
        {
            PlayerTwoPickup();
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

    void PlayerOnePickup()
    {
        Destroy(gameObject);

        switch (gameObject.tag)
        {
            case "GroupA":
                playerOneScore += 1;
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

    void PlayerTwoPickup()
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

    IEnumerator PlayerOnePickupDelay()
    {
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);

        switch (gameObject.tag)
        {
            case "GroupA":
                playerOneScore += 1;
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

    IEnumerator PlayerTwoPickupDelay()
    {
        yield return new WaitForSeconds(0.5f);

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

    void OnDestroy()
    {
        if (playerOneFinal >= 3 && !p1FirstRadiusChanged)
        {
            playerOneLine.radius += 1;
            enemyOneRangeP1.enemyRadiusP1 += 1;
            enemyTwoRangeP1.enemyRadiusP1 += 1;
            p1FirstRadiusChanged = true;
        }

        else if (playerOneFinal >= 7 && !p1SecondRadiusChanged)
        {
            playerOneLine.radius += 2;
            enemyOneRangeP1.enemyRadiusP1 += 2.5;
            enemyTwoRangeP1.enemyRadiusP1 += 2.5;
            p1SecondRadiusChanged = true;
        }

        else if (playerOneFinal >= 10 && !p1ThirdRadiusChanged)
        {
            playerOneLine.radius += 3;
            enemyOneRangeP1.enemyRadiusP1 += 2.9;
            enemyTwoRangeP1.enemyRadiusP1 += 2.9;
            p1ThirdRadiusChanged = true;
        }

        if (playerTwoFinal >= 3 && !p2FirstRadiusChanged)
        {
            playerTwoLine.radius += 1;
            enemyOneRangeP2.enemyRadiusP2 += 1;
            enemyTwoRangeP2.enemyRadiusP2 += 1;
            p2FirstRadiusChanged = true;
        }

        else if (playerTwoFinal >= 7 && !p2SecondRadiusChanged)
        {
            playerTwoLine.radius += 2;
            enemyOneRangeP2.enemyRadiusP2 += 2.5;
            enemyTwoRangeP2.enemyRadiusP2 += 2.5;
            p2SecondRadiusChanged = true;
        }

        else if (playerTwoFinal >= 10 && !p2ThirdRadiusChanged)
        {
            playerTwoLine.radius += 3;
            enemyOneRangeP2.enemyRadiusP2 += 2.9;
            enemyTwoRangeP2.enemyRadiusP2 += 2.9;
            p2ThirdRadiusChanged = true;
        }


    }

}
