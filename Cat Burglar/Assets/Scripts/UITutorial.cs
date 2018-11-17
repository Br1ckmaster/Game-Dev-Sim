using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour 
{
	[SerializeField] private Image customImage1;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag ("Player")) 
		{
			customImage1.enabled = true;
		}
	}

	void OnTriggerExir(Collider other)
	{
		if (other.CompareTag ("Player")) 
		{
			customImage1.enabled = false;
		}
	}
}
