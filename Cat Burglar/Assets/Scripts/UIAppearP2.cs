using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAppearP2 : MonoBehaviour {

    [SerializeField] private Image customImage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTwo"))
        {
            customImage.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerTwo"))
        {
            customImage.enabled = false;
        }
    }

    private void OnDestroy()
    {
        if (customImage != null)
        {
            customImage.enabled = false;
        }
    }
}
