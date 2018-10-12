using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickupObject : MonoBehaviour {

    public Text scoreText;
    public int scoreValue;
    public bool LeftCtrlPressed;
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            LeftCtrlPressed = true;
        }

    }

    void OnTriggerEnter(Collider collider) //When player collides with object
    {
        ScoreManager manger = collider.gameObject.GetComponent<ScoreManager>();
        Debug.Log("Enter Collision");

        if (collider.gameObject.name == "PlayerOne" && LeftCtrlPressed == true)
        {
            manger.AddScore(scoreValue);
            Destroy(gameObject);
        }

        else if (collider.gameObject.name == "PlayerTwo")
        {
            manger.AddScore(scoreValue);
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
        }
    }
}
