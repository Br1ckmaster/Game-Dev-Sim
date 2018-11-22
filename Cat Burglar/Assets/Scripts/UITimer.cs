using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{

    ////Image FillImg;
    //float timeAmt = 10;
    //float time;

    public NightCycle nightCycle;

    private float x = 0;
    private float y = 0;
    private float z = 90;
	//public Text timeText;

	void Start () 
	{
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.Rotate(new Vector3(x, y, z));
        //FillImg = this.GetComponent<Image> ();
		//time = timeAmt;
	}
	
	void Update () 
	{

		//if (time > 0) 
		//{
		//	time -= Time.deltaTime;
		//	//FillImg.fillAmount = time / timeAmt;
            
  //          //timeText.text = "Time : " + time.ToString ("F");
  //      }
	}

    void UpdateHand()
    {

    }
}
