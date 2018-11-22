using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class ChaseMusicControl : MonoBehaviour {

    public AudioMixerSnapshot BGM;
    public AudioMixerSnapshot Chase;

    public float BPM = 120;

    private float transitionIn;
    private float transitionOut;
    private float quaterNote;

    void Start ()
    {
        quaterNote = 60 / BPM;
        transitionIn = quaterNote;
        transitionOut = quaterNote * 4;
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AudioTriggerChase"))
        {
            Chase.TransitionTo(transitionIn);
        }
    }

    void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("AudioTriggerChase"))
       {
            BGM.TransitionTo(transitionOut);
       }
    }

}
