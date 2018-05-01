using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*	This script counts score and rage,
	and display them on screen 
	The main functionality of the game happens here:
		- Player rage is displayed 
		- Player current score is displayed
		- Player unleashes rage here
		- Camera shakes here
		- Soundwave animation triggers here
		- Game over state gets triggered here
*/

public class GameManager : MonoBehaviour {

	//Variables relevant to rage
	public static float currRage; //current rage value
	public static float maxRage; //current maxium rage value players can receive
	public Slider rageMeter; //Slider that shows rage value
	public Image fillMeter; //How much to fill the rageMeter
	private int rageCount; //How many times has the player unleashed rage


	//Variables relevant to screenshake
	public Transform cameraPos;
	private Vector2 shakePos; //Shake offset
	private bool setShake; //If the screen is shaking
	private float shakeAmount; //The maximum offset
	private float shakeTimer; //How long to keep shaking


	//Variables relevant to sound wave animation
	private bool setSoundAnim; //If triggering sound wave animation
	private float soundAnimTimer; //How long the sound wave animation keeps playing


	//Variables relevant to player death
	private bool isDead;
	public float deathTimer; //How much the death animation last before loading fail scene


	//Variables relevant to score and remaining chances to unleash rage 
	private float score;
	public static float roundScore;
	private GameObject scoreText;
	private GameObject rageText;


	public GameObject player;
	public GameObject soundWavePrefab;
	private GameObject[] allObstacles;


	// Use this for initialization
	void Start () {
		scoreText = GameObject.FindWithTag ("Score");
		rageText = GameObject.FindWithTag ("RageCount");
		score = 0;
		maxRage = 1;
		rageMeter.value = 0;
		rageMeter.maxValue = maxRage;
		rageCount = 0;	
		currRage = 0;
		shakeTimer = 1f;
		soundAnimTimer = 1f;
		shakeAmount = 0.15f;
		setShake = false;
		setSoundAnim = false;
		isDead = false;

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
		if ((rageMeter.value == maxRage) && (rageCount < 3) && !isDead) {
			UnleashRage ();
		}
	
		//Shake the camera if player unleashes their rage (by pressing space)
		if (setShake) {
			ShakeCamera();
		}

		//Show a sound wave
		if (setSoundAnim) {
			TriggerSoundWave ();
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

	//Destroy all objects in scene when player presses space
	void UnleashRage(){
		allObstacles = GameObject.FindGameObjectsWithTag("Obstacle");
		if (Input.GetKeyDown ("space")) {
			player.GetComponent<PlayerAudioPlayer> ().PlayScream ();

			for(var i = 0 ; i < allObstacles.Length ; i ++){
				Destroy(allObstacles[i]);
			}

			//reset variables for player's rage 
			currRage = 0;
			maxRage -= 0.1f;
			rageMeter.maxValue = maxRage;
			rageMeter.value = currRage;

			//decrease score when player unleashes rage 
			score -= 20;
			//decrease rage count
			rageCount += 1;

			//reset the obstacles falling down to be less and slower 
			FallingDown.increaseAmount = 3;
			FallingDown.increaseCounter = 0;
			FallingDown.minSpeed = 0f;
			FallingDown.maxSpeed = 1f;

			//set the boolean to shake the camera and turn on animation
			setShake = true;
			setSoundAnim = true;
		}
	}

	//Shake the camera when player releases rage to add effect
	void ShakeCamera(){
		if (shakeTimer >= 0) {
			//find a random point in the circle and shake it 
			shakePos = Random.insideUnitCircle * shakeAmount;
			//shake the camera 
			cameraPos.position = new Vector3 (cameraPos.position.x + shakePos.x, cameraPos.position.y + shakePos.y, cameraPos.position.z);
			//decrease the time of the shake
			shakeTimer -= Time.deltaTime;
		} else {
			setShake = false; //after time is done shake is done 
			cameraPos.position = new Vector3 (0, 0, -10); //reset to original camera position
			shakeTimer = 1f; //reset the time for shake for future shakes
		}
	}

	//Trigger a sound wave when player releases rage
	void TriggerSoundWave(){
		GameObject newWave = Instantiate (soundWavePrefab) as GameObject;
		newWave.transform.position = player.transform.position;

		soundAnimTimer -= Time.deltaTime;
		if (soundAnimTimer <= 0) {
			setSoundAnim = false;
			soundAnimTimer = 1f;
		}
	}

	//Game over state 
	void GameOver(){
		isDead = true;
		player.GetComponent<SpriteRenderer> ().color = Color.white;
		player.GetComponent<PlayerMovement> ().enabled = false;
		player.GetComponent<PlayerAnimation> ().enabled = false;

		player.GetComponent<PlayerAnimation> ().DestroyFire ();
		player.GetComponent<PlayerAnimation> ().MakeBurned ();

		deathTimer -= Time.deltaTime;

		//load the end scene after a certain time
		if (deathTimer <= 0) {
			SceneManager.LoadScene ("endStage");
		}
	}

}

