using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

	// Display score on "Win Screen"
	void Start ()
    {
        Text myText = GetComponent<Text>();
        myText.text = ScoreKeeper.score.ToString();
        ScoreKeeper.Reset();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
