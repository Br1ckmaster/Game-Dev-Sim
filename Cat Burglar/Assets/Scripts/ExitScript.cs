using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

	Animator anim;
    public GameObject playerOne;
    public GameObject playerTwo;

	public GameObject enemyOne;
	public GameObject enemyTwo;

    private bool playerOneCollided;
    private bool playerTwoCollided;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}

    private void Update()
    {
        if(playerOneCollided && Input.GetKeyDown(KeyCode.Space))
        {
			//Destroy(playerOne);
			anim.SetTrigger("EndGame");
			//UnityEngine.SceneManagement.SceneManager.LoadScene(6);
			Destroy(enemyOne);
			Destroy(enemyTwo);
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
