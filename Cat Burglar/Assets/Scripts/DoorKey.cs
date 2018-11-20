using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour {

    public bool inTrigger;
	public AudioClip clinkSound;
	private AudioSource source;


    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

	void Awake () 
	{

		source = GetComponent<AudioSource>();

	}

    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
				source.PlayOneShot(clinkSound);
                DoorScript.doorKey = true;
				//yield return new WaitForSeconds (0.5);
                Destroy(this.gameObject);
            }
        }
    }

    /*private void OnGUI()
    {
        if (inTrigger)
        {
            GUI.Box(new Rect(0, 60, 200, 25), "Press Left Control to steal");
        }
    }*/
}
