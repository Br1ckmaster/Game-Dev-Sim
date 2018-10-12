using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public Text scoreText;
    public int scoreTally;

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void AddScore(int scoreValue)
    {
        scoreTally += scoreValue;
        scoreText.text = "Score: " + scoreTally.ToString();
    }
}
