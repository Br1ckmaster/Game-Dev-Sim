using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour 
{

		void Awake()
		{
			DoorBlock.coinsInLevel++;
		}

}
