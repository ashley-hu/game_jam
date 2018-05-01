using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * FinalScore class
 * This displays the final score when the game is over
*/
public class FinalScore : MonoBehaviour {

	private GameObject finalScore;

	// Use this for initialization
	void Start () {
		Cursor.visible = true; //show the cursor
		finalScore = GameObject.FindWithTag ("FinalScore");
	}
	
	// Update is called once per frame
	void Update () {
		if (finalScore != null) {
			//Display the score 
			finalScore.GetComponent<Text> ().text = "Score\n" + GameManager.roundScore;
		}
	}
}
