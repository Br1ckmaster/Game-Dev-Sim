using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSound : MonoBehaviour 
{
	public Renderer rend;

	public void Start()
	{
		rend = GetComponent<Renderer>();
		rend.enabled = true;
	}

	public void LeftControl()
	{
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();
		rend.enabled = false;
		Destroy(gameObject, audio.clip.length);
	}
}
