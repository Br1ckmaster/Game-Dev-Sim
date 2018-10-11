using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickupObject : MonoBehaviour {

    public Text scoreText;

    private bool canPickup;
    private int score;

    void Start()
    {
        score = 0;
        ScoreText();
    }
	
	void Update()
    {
        if (canPickup && Input.GetKeyDown(KeyCode.E)) //Player pressing E to pickup object
        {
            ObjectPickup();
            Score();
            ScoreText();
        }
    
    }

    void OnTriggerEnter(Collider collider) //When player collides with object
    {
      if(collider.gameObject.name == "Player")
        {
            Debug.Log("Entered Collision");
            canPickup = true;
        }
    }

    void OnTriggerExit(Collider collider) //When player exits object collider
    {
        if (collider.gameObject.name == "Player")
        {
            Debug.Log("Exited Collision");
            canPickup = false;
        }
    }

    void ObjectPickup() //Pickup object
    {
        Destroy(this.gameObject);
    }

    void OnGUI() //Displays tooltip
    {
        if(canPickup)
        {
            GUI.Box(new Rect(0, 60, 300, 50), "Press E to pickup");
        }
    }

    void ScoreText() //Displays score text
    {
        scoreText.text = "Score: " + score.ToString();
    }
   
    void Score() //Adding score
    {
        score = score + 1;
    }
}
