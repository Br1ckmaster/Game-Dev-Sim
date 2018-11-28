using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{

    Image fillImg;
    public float timeAmt = 120;
    private float time;



	void Start () 
	{
        fillImg = this.GetComponent<Image> ();
		time = timeAmt;
	}
	
	void Update () 
	{

		if (time > 0) 
		{
			time -= Time.deltaTime;
			fillImg.fillAmount = time / timeAmt;
        }
	}

}
