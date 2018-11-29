using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

	Animator anim;
    public GameObject playerOne;

	public GameObject enemyOne;
	public GameObject enemyTwo;

    private bool playerOneCollided;

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

    }

    void OnTriggerEnter(Collider collider)
    {
		if(collider.gameObject.name == "PlayerOne")
        {
            playerOneCollided = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "PlayerOne")
        {
            playerOneCollided = false;
        }
    }
}
