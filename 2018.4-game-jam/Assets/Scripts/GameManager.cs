using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public Slider rageMeter;
	public static float rageReceived;
	public Image fillMeter;

	private GameObject scoreText;
	private float score;
	private float roundScore;
	private float maxRage;
	private GameObject[] allObstacles;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.FindWithTag ("Score");
		score = 0;
		maxRage = 1;
		rageMeter.value = 0;
		rageMeter.maxValue = maxRage;
		rageReceived = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (scoreText != null) {
			//display the current score on canvas
			score += Time.deltaTime;
			roundScore = Mathf.RoundToInt (score);
			scoreText.GetComponent<Text> ().text = "Score: " + roundScore.ToString();
		}
		rageMeter.value = rageReceived;
		if (rageReceived <= 0) {
			fillMeter.color = new Color(1, 0.92f, 0.016f, 0); //set slider circle to be transparent
		} else {
			//change the color from yellow to red as you receive more "rage"
			fillMeter.color = Color.Lerp (Color.yellow, Color.red, rageReceived / 1);
		}
			
		if (rageMeter.value == maxRage) {
			UnleashRage ();
		} else if (rageMeter.value > maxRage) {
		}
	}

	//Destroy all objects in scene
	public void UnleashRage(){
		allObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
		if (Input.GetKeyDown ("space")) {
			for(var i = 0 ; i < allObstacles.Length ; i ++){
				Destroy(allObstacles[i]);
			}
			rageReceived = 0;
			maxRage -= 0.1f;
			rageMeter.maxValue = maxRage;
			score -= 100;
		}
	}
}
