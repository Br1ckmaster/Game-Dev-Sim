using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{

    Image fillImg;
    public float timeAmt = 120;
    private float time;

    //public NightCycle nightCycle;

    //private float x = 0;
    //private float y = 0;
    //private float z = 90;
	//public Text timeText;

	void Start () 
	{
        //RectTransform rectTransform = GetComponent<RectTransform>();
        //rectTransform.Rotate(new Vector3(x, y, z));
        fillImg = this.GetComponent<Image> ();
		time = timeAmt;
	}
	
	void Update () 
	{

		if (time > 0) 
		{
			time -= Time.deltaTime;
			fillImg.fillAmount = time / timeAmt;
            
           // timeText.text = "Time : " + time.ToString ("F");
        }
	}

}
