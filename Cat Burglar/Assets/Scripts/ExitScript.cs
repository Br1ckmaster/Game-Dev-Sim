using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour {

    public GameObject playerOne;
	public GameObject enemyOne;
	public GameObject enemyTwo;

    public Image endBackground;
    public Image wonBackground;

    private bool playerOneCollided;

	private void Awake()
	{
        endBackground.enabled = false;
        wonBackground.enabled = false;
	}

    private void Update()
    {
        if(playerOneCollided && Input.GetButtonDown("P1_Pickup"))
        {
            EndGame();
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
		if(collider.gameObject.name == "PlayerOne")
        {
            playerOneCollided = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "PlayerOne")
        {
            playerOneCollided = false;
        }
    }

    private void EndGame()
    {
        endBackground.enabled = true;
        wonBackground.enabled = true;

        Destroy(enemyOne);
        Destroy(enemyTwo);
        Destroy(playerOne);
    }

	private void OnDestroy()
	{
		if (endBackground && wonBackground != null)
		{
			endBackground.enabled = false;
			wonBackground.enabled = false;
		}
	}
}
