using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBlock : MonoBehaviour 
{
	public static int coinsInLevel;
	public static int collectedCoins;

	void Update()
	{
		if (collectedCoins == coinsInLevel) //&& Input.GetKeyDown("somekey"))
		{
			Destroy(this.gameObject);
		}
	}
}
