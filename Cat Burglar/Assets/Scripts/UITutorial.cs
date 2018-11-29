using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour 
{
	public bool inTrigger;
	//public GameObject Player;
	[SerializeField] private Image image;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			image.enabled = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player")) 
		{
			image.enabled = false;
		}
	}

	private void OnDestroy()
	{
		if (image != null)
		{
			image.enabled = false;
		}
	}
}
