﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour 
{

	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (new Vector3 (Time.deltaTime * 0, 0, -3));
	}
}
