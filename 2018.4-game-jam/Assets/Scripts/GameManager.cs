using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*This script counts score and rage,
 * and display them on screen*/

public class GameManager : MonoBehaviour {

	//public static float rageReceived;
	public static float currRage;
	public static float roundScore;
	public static float maxRage;

	public float deathTimer;
	public Slider rageMeter;
	public Image fillMeter;
	public GameObject player;

	public Transform cameraPos;

	private float score;
	private int rageCount;
	private GameObject scoreText;
	private GameObject rageText;
	private GameObject[] allObstacles;
	private float shakeTimer;
	private float shakeAmount;
	private bool setShake;
	private Vector2 shakePos;

	// Use this for initialization
	void Start () {
		scoreText = GameObject.FindWithTag ("Score");
		rageText = GameObject.FindWithTag ("RageCount");
		score = 0;
		maxRage = 1;
		rageMeter.value = 0;
		rageMeter.maxValue = maxRage;
		//rageReceived = 0;
		rageCount = 0;
		//currRage = rageReceived;
		currRage = 0;
		shakeTimer = 1f;
		shakeAmount = 0.2f;
		setShake = false;

		player.GetComponent<PlayerMovement> ().enabled = true;
	}


	// Update is called once per frame
	void Update () {

		//Display the current score on canvas
		if (scoreText != null) {
			score += Time.deltaTime;
			roundScore = Mathf.RoundToInt (score);
			scoreText.GetComponent<Text> ().text = "Score: " + roundScore.ToString();
		}


		//Display the remaining rage-unleashing chances
		if (rageText != null) {
			rageText.GetComponent<Text> ().text = "Rage: " + (3 - rageCount).ToString();
		}


		//Updating the rage bar with rage value
		rageMeter.value = currRage;

		if (currRage <= 0) {
			fillMeter.color = new Color(1, 0.92f, 0.016f, 0); //set slider circle to be transparent
		} else {
			//change the color from yellow to red as you receive more "rage"
			fillMeter.color = Color.Lerp (Color.yellow, Color.red, currRage / 1);
		}


		//If there's still chance to unleash rage and rage bar is full, let player unleash rage
		if ((rageMeter.value == maxRage) && (rageCount < 3)) {
			UnleashRage ();
		}
			
		if (setShake) {
			ShakeCamera();
			//cameraPos.position = new Vector3 (0, 0, -10);
		}

		//Game over when rage bar overflows
		if (currRage > (maxRage + 0.05f)) {
			GameOver ();
		}

		//Game over when rage bar reaches the max and there's no chance to unleash rage
		if ((rageCount >= 3) && (rageMeter.value == maxRage)) {
			GameOver ();
		}
	}

	//Destroy all objects in scene
	void UnleashRage(){
		allObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
		if (Input.GetKeyDown ("space")) {
			player.GetComponent<PlayerAudioPlayer> ().PlayScream ();

			for(var i = 0 ; i < allObstacles.Length ; i ++){
				Destroy(allObstacles[i]);
			}
			currRage = 0;
			maxRage -= 0.1f;

			rageMeter.maxValue = maxRage;
			rageMeter.value = currRage;

			score -= 100;
			rageCount += 1;

			FallingDown.increaseAmount = 3;
			FallingDown.increaseCounter = 0;
			FallingDown.minSpeed = 0f;
			FallingDown.maxSpeed = 1f;

			setShake = true;
		}
	}

	public void ShakeCamera(){
		if (shakeTimer >= 0) {
			shakePos = Random.insideUnitCircle * shakeAmount;
			cameraPos.position = new Vector3 (cameraPos.position.x + shakePos.x, cameraPos.position.y + shakePos.y, cameraPos.position.z);
			shakeTimer -= Time.deltaTime;
		} else {
			setShake = false;
			cameraPos.position = new Vector3 (0, 0, -10);
			Debug.Log ("Set shake: " + setShake);
			shakeTimer = 1;
		}
	}


	void GameOver(){
		player.GetComponent<SpriteRenderer> ().color = Color.white;
		player.GetComponent<PlayerMovement> ().enabled = false;

		player.GetComponent<PlayerAnimation> ().DestroyFire ();
		player.GetComponent<PlayerAnimation> ().MakeBurned ();

		deathTimer -= Time.deltaTime;

		if (deathTimer <= 0) {
			SceneManager.LoadScene ("endStage");
		}
	}

}

