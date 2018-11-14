using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTrigger : MonoBehaviour {

    public bool inTrigger;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    // Use this for initialization
    void Start ()
    {
        Player.GetComponent<LineRenderer>().enabled = false;
        inTrigger = false;
    }

    // Update is called once per frame
    void Update ()
    {
		if (inTrigger)
        {
            Player.GetComponent<LineRenderer>().enabled = true;
        }

    }
}
