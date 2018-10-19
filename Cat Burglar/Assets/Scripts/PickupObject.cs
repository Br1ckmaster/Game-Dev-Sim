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
    public Text text;
    //public EnemyOne enemyOne;
    //public EnemyTwo enemyTwo;
    //public int scoreValue;
    //public bool LeftCtrlPressed;
    //public bool RightCtrlPressed;
    //bool LeftCtrlPressed = false;
    //bool RightCtrlPressed = false;
    bool playerOneCollided;
    bool playerTwoCollided;
    //public GameObject[] raycastObject;
    private int  itemsHeld = 0;
    //int itemsHeldA = 0;
    private static int itemsFinal = 0;

    void Start()
    {

    }

    void Update()
    {
        //Vector3 foward = transform.TransformDirection(Vector3.forward);
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, foward, out hit))
        //{
        //    if (hit.distance <= 5.0f && hit.collider.gameObject.tag == "Pickup")
        //    {
        //        if (Input.GetKeyDown("e"))
        //        {
        //            Destroy(raycastObject[1]);
        //        }
        //    }
        //}

        if (playerOneCollided && Input.GetKeyDown(KeyCode.LeftControl))
        {
            PickUp();

            if(gameObject.tag == "GroupA")
            {
                itemsHeld += 1;
                itemsFinal += itemsHeld;
                text.text = "Score: " + itemsFinal.ToString();
            }
            else if (gameObject.tag == "GroupB")
            {
                itemsHeld += 2;
                itemsFinal += itemsHeld;
                text.text = "Score: " + itemsFinal.ToString();
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
            //manger.AddScore(scoreValue);
            //playerOneLine.radius += 1.0f;
            //enemyOne.enemyRadius += 1.05;
            //enemyTwo.enemyRadius += 1.05;
        }

        else if (collider.gameObject.name == "PlayerTwo")
        {
            playerTwoCollided = true;
            //manger.AddScore(scoreValue);
            //playerTwoLine.radius += 1.0f;
            //enemyOne.enemyRadius += 1.05;
            //enemyTwo.enemyRadius += 1.05;

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

