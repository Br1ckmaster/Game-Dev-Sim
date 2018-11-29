using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour {

    [SerializeField]
    private Image image;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            image.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
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
