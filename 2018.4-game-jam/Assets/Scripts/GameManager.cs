using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private GameObject scoreText;
	private float score;
	private float roundScore;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.FindWithTag ("Score");
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreText != null) {
			score += Time.deltaTime;
			roundScore = Mathf.RoundToInt (score);
			scoreText.GetComponent<Text> ().text = "Score: " + roundScore.ToString();
		}
	}
}
