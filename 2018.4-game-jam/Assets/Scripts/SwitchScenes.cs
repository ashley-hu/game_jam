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

	//Start the game when player presses "start"
	public void SwitchToGameStageFromStartStage(){
		if (SceneManager.GetActiveScene ().buildIndex == 0) {
			SceneManager.LoadScene ("gameStage");
		}
	}

	//Restart the game after the player presses "play again"
	public void SwitchToGameStageFromEndStage(){
		if (SceneManager.GetActiveScene ().buildIndex == 2) {
			SceneManager.LoadScene ("gameStage");
		}
	}
}
