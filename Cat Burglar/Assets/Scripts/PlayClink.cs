using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClink : MonoBehaviour {

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

    void Awake()
    {

        source = GetComponent<AudioSource>();


    }

    void Update()
    {
        if (inTrigger)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                source.PlayOneShot(clinkSound);
                StartCoroutine(Key());
            }
        }
    }

    IEnumerator Key()
    {
        yield return new WaitForSeconds(0.5f);
		Destroy(this.gameObject);
    }
}
