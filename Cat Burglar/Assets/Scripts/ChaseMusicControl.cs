using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 

public class ChaseMusicControl : MonoBehaviour {

    public AudioMixerSnapshot BGM;
    public AudioMixerSnapshot Chase;
    //public AudioClip[] stings;
    //public AudioSource stingSource;
    public float bpm = 128;

    private float m_TransitionIn;
    private float m_TransitionOut;
    private float m_QuarterNote;


    // Use this for initialization
    void Start ()
    {
        m_QuarterNote = 60 / bpm;
        m_TransitionIn = m_QuarterNote;
        m_TransitionOut = m_QuarterNote * 4;
	}
	
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AudioTriggerChase"))
        {
            Chase.TransitionTo(m_TransitionIn);
        }
    }

    void OnTriggerExit(Collider other)
    {
       if (other.CompareTag("AudioTriggerChase"))
       {
            BGM.TransitionTo(m_TransitionOut);
       }
    }

}
