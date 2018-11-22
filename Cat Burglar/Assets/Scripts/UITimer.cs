using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour {


    
	//Image FillImg;
	float timeAmt = 10;
	float time;
	//public Text timeText;

	// Use this for initialization
	void Start () 
	{
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.Rotate(new Vector3(0, 0, 90));
        //FillImg = this.GetComponent<Image> ();
		time = timeAmt;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (time > 0) 
		{
			time -= Time.deltaTime;
			//FillImg.fillAmount = time / timeAmt;
            
            //timeText.text = "Time : " + time.ToString ("F");
        }
	}
}
