using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PickupObject : MonoBehaviour
{
   
    public PlayerLine playerOneRadius;

    public EnemyOne enemyOneDetection;
    public EnemyTwo enemyTwoDetection;

    public Text playerOneText;

    private bool playerOneCollided;

    private static bool  p1FirstRadiusChanged;
    private static bool  p1SecondRadiusChanged;
    private static bool  p1ThirdRadiusChanged;

    private static int playerOneScore;

    private int playerOneFinal = 0;

    public void Awake()
    {
        playerOneScore = 0;

        p1FirstRadiusChanged = false;
        p1SecondRadiusChanged = false;
        p1ThirdRadiusChanged = false;

    }

    private void Update()
    {
        if (playerOneCollided && Input.GetButton("P1_Pickup"))
        {
            PlayerOnePickup();
        }

    }

    private void OnTriggerEnter(Collider collider) //When player collides with object
    {
        switch(collider.gameObject.name)
        {
            case "PlayerOne": playerOneCollided = true; break;
        }
    }

    private void OnTriggerExit(Collider collider) //When player two exits object collider
    {
        switch (collider.gameObject.name)
        {
            case "PlayerOne": playerOneCollided = false; break;
        }
    }

    public void PlayerOnePickup()
    {
        Destroy(gameObject);

        switch (gameObject.tag)
        {
            case "GroupA":
                playerOneScore += 10;
                playerOneFinal += playerOneScore;
                playerOneText.text = " " + playerOneFinal.ToString();
                break;

            case "GroupB":
                playerOneScore += 100;
                playerOneFinal += playerOneScore;
                playerOneText.text = " " + playerOneFinal.ToString();
                break;

            case "GroupC":
                playerOneScore += 200;
                playerOneFinal += playerOneScore;
                playerOneText.text = " " + playerOneFinal.ToString();
                break;

            case "GroupD":
                playerOneScore += 500;
                playerOneFinal += playerOneScore;
                playerOneText.text = " " + playerOneFinal.ToString();
                break;

            case "GroupE":
                playerOneScore += 1000;
                playerOneFinal += playerOneScore;
                playerOneText.text = " " + playerOneFinal.ToString();
                break;
        }
    }


    public void OnDestroy()
    {
        if (playerOneFinal >= 250 && !p1FirstRadiusChanged)
        {
            playerOneRadius.radius += 1;
            enemyOneDetection.enemyRadiusP1 += 1;
            enemyTwoDetection.enemyRadiusP1 += 1;
            p1FirstRadiusChanged = true;
        }

        else if (playerOneFinal >= 500 && !p1SecondRadiusChanged)
        {
            playerOneRadius.radius += 2;
            enemyOneDetection.enemyRadiusP1 += 2.5;
            enemyTwoDetection.enemyRadiusP1 += 2.5;
            p1SecondRadiusChanged = true;
        }

        else if (playerOneFinal >= 1250 && !p1ThirdRadiusChanged)
        {
            playerOneRadius.radius += 3;
            enemyOneDetection.enemyRadiusP1 += 2.9;
            enemyTwoDetection.enemyRadiusP1 += 2.9;
            p1ThirdRadiusChanged = true;
        }  
    }
}
