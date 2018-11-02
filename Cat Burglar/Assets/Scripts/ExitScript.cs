using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

    public GameObject playerOne;
    public GameObject playerTwo;

    private bool playerOneCollided;
    private bool playerTwoCollided;

    private void Update()
    {
        if(playerOneCollided && Input.GetKeyDown(KeyCode.LeftControl))
        {
            Destroy(playerOne);
        }

        else if (playerTwoCollided && Input.GetKeyDown(KeyCode.RightControl))
        {
            Destroy(playerTwo);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
		if(collider.gameObject.name == "PlayerOne")
        {
            playerOneCollided = true;
        }

        else if (collider.gameObject.name == "PlayerTwo")
        {
            playerTwoCollided = true;
        }
    }

    void OnTriggerExit(Collider collider)
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
}
