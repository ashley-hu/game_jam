using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * SwitchScenes class
 * Controls the switch between scenes
 * Build index 
 * 0 = startStage
 * 1 = gameStage
 * 2 = endStage
 * 
 * */
public class SwitchScenes : MonoBehaviour {

	public AudioClip clickSound;
	private AudioSource audioSource;
	private bool soundIsDone = false;

	public void Awake () {
		audioSource = GetComponent<AudioSource>();
	}

	//Start the game when player presses "start"
	public void SwitchToGameStageFromStartStage(){
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			if (!soundIsDone) { //wait until button sound is done playing before loading next scene
				StartCoroutine(DelayedLoad("gameStage"));
				soundIsDone = true; 
			}
		}
	}

	//Restart the game after the player presses "play again"
	public void SwitchToGameStageFromEndStage(){
		if (SceneManager.GetActiveScene ().buildIndex == 2) {
			if (!soundIsDone) { //wait until button sound is done playing before loading next scene
				StartCoroutine(DelayedLoad("gameStage"));
				soundIsDone = true; 
			}
		}
	}

	//Quit the game
	public void QuitGame(){
		if (!soundIsDone) { //wait until button sound is done playing before quitting
			StartCoroutine(DelayedQuitGame());
			soundIsDone = true; 
		}
	}

	//Wait until sound is done playing until loading new scene
	IEnumerator DelayedLoad(string scene){
		//Play the clip once
		audioSource.PlayOneShot (clickSound);
		//Wait until clip finish playing
		yield return new WaitForSeconds (clickSound.length);  
		SceneManager.LoadScene (scene);
	}

	//Wait until sound is done playing until loading new scene
	IEnumerator DelayedQuitGame(){
		//Play the clip once
		audioSource.PlayOneShot (clickSound);
		//Wait until clip finish playing
		yield return new WaitForSeconds (clickSound.length);  
		Application.Quit ();
	}
}
