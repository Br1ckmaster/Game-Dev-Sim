using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PickupObject : MonoBehaviour
{
   
    //public Text scoreText;
    public PlayerLine playerOneRadius;
    public PlayerLine playerTwoRadius;

    public EnemyOne enemyOneDetection;
    public EnemyTwo enemyTwoDetection;

    public Text playerOneText;
    public Text playerTwoText;

    private bool playerOneCollided;
    private bool playerTwoCollided;

    private static bool  p1FirstRadiusChanged;
    private static bool  p1SecondRadiusChanged;
    private static bool  p1ThirdRadiusChanged;
                  
    private static bool  p2FirstRadiusChanged;
    private static bool  p2SecondRadiusChanged;
    private static bool  p2ThirdRadiusChanged;

    private static int playerOneScore;
    private static int playerTwoScore;

    private int playerOneFinal = 0;
    private int playerTwoFinal = 0;

    void Awake()
    {
        playerOneScore = 0;
        playerTwoScore = 0;

        p1FirstRadiusChanged = false;
        p1SecondRadiusChanged = false;
        p1ThirdRadiusChanged = false;

        p2FirstRadiusChanged = false;
        p2SecondRadiusChanged = false;
        p2ThirdRadiusChanged = false;

    }

    void Update()
    {
        if (playerOneCollided && Input.GetButton("P1_Pickup"))
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
                playerOneText.text = " " + playerOneFinal.ToString();
                break;

            case "GroupB":
                playerOneScore += 2;
                playerOneFinal += playerOneScore;
                playerOneText.text = " " + playerOneFinal.ToString();
                break;

            case "GroupC":
                playerOneScore += 3;
                playerOneFinal += playerOneScore;
                playerOneText.text = " " + playerOneFinal.ToString();
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
                playerTwoText.text = " " + playerTwoFinal.ToString();
                break;

            case "GroupB":
                playerTwoScore += 2;
                playerTwoFinal += playerTwoScore;
                playerTwoText.text = " " + playerTwoFinal.ToString();
                break;

            case "GroupC":
                playerTwoScore += 3;
                playerTwoFinal += playerTwoScore;
                playerTwoText.text = " " + playerTwoFinal.ToString();
                break;
        }
    }


    void OnDestroy()
    {
        if (playerOneFinal >= 3 && !p1FirstRadiusChanged)
        {
            playerOneRadius.radius += 1;
            enemyOneDetection.enemyRadiusP1 += 1;
            //enemyTwoDetection.enemyRadiusP1 += 1;
            p1FirstRadiusChanged = true;
        }

        else if (playerOneFinal >= 7 && !p1SecondRadiusChanged)
        {
            playerOneRadius.radius += 2;
            enemyOneDetection.enemyRadiusP1 += 2.5;
           // enemyTwoDetection.enemyRadiusP1 += 2.5;
            p1SecondRadiusChanged = true;
        }

        else if (playerOneFinal >= 10 && !p1ThirdRadiusChanged)
        {
            playerOneRadius.radius += 3;
            enemyOneDetection.enemyRadiusP1 += 2.9;
            //enemyTwoDetection.enemyRadiusP1 += 2.9;
            p1ThirdRadiusChanged = true;
        }

        if (playerTwoFinal >= 3 && !p2FirstRadiusChanged)
        {
            playerTwoRadius.radius += 1;
            enemyOneDetection.enemyRadiusP2 += 1;
            //enemyTwoDetection.enemyRadiusP2 += 1;
            p2FirstRadiusChanged = true;
        }

        else if (playerTwoFinal >= 7 && !p2SecondRadiusChanged)
        {
            playerTwoRadius.radius += 2;
            enemyOneDetection.enemyRadiusP2 += 2.5;
            //enemyTwoDetection.enemyRadiusP2 += 2.5;
            p2SecondRadiusChanged = true;
        }

        else if (playerTwoFinal >= 10 && !p2ThirdRadiusChanged)
        {
            playerTwoRadius.radius += 3;
            enemyOneDetection.enemyRadiusP2 += 2.9;
           // enemyTwoDetection.enemyRadiusP2 += 2.9;
            p2ThirdRadiusChanged = true;
        }
    }
}
