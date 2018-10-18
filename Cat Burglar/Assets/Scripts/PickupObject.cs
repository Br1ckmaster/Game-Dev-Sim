using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PickupObject : MonoBehaviour {

    public Text scoreText;
    public PlayerLine playerOneLine;
    public PlayerLine playerTwoLine;
    public EnemyOne enemyOne;
    public EnemyTwo enemyTwo;
    public int scoreValue;
    public bool LeftCtrlPressed;
    public bool RightCtrlPressed;
   
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            LeftCtrlPressed = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightControl))
        {
            RightCtrlPressed = true;
        }
        

    }

    void OnTriggerEnter(Collider collider) //When player collides with object
    {
        ScoreManager manger = collider.gameObject.GetComponent<ScoreManager>();
        Debug.Log("Enter Collision");

        if (collider.gameObject.name == "PlayerOne" && LeftCtrlPressed == true)
        {
            manger.AddScore(scoreValue);
            playerOneLine.radius += 1.0f;
            enemyOne.enemyRadius += 1.05;
            Destroy(gameObject);
        }

        else if (collider.gameObject.name == "PlayerTwo" && RightCtrlPressed == true)
        {
            manger.AddScore(scoreValue);
            playerTwoLine.radius += 1.0f;
            enemyTwo.enemyRadius += 1.05;
            Destroy(gameObject);
        }
    }

    void OnTriggerExit(Collider collider) //When player two exits object collider
    {
        if (collider.gameObject.name == "PlayerOne")
        {
            Debug.Log("Exit Collision");
            LeftCtrlPressed = false;
        }

        else if (collider.gameObject.name == "PlayerTwo")
        {
            Debug.Log("Exit Collision");
            RightCtrlPressed = false;
        }
    }
}
