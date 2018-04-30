using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	private GameObject finalScore;

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		finalScore = GameObject.FindWithTag ("FinalScore");
	}
	
	// Update is called once per frame
	void Update () {
		if (finalScore != null) {
			finalScore.GetComponent<Text> ().text = "Score\n" + GameManager.roundScore;
		}
	}
}
