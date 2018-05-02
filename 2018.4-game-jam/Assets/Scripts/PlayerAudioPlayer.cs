using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerAudioPlayer class
 * This class keeps track of the audio for the player
 * 
*/
public class PlayerAudioPlayer : MonoBehaviour {

	public AudioClip screamClip;
	public AudioClip moanClip;

	AudioSource myAudioPlayer;

	// Use this for initialization
	void Start () {
		myAudioPlayer = GetComponent<AudioSource> ();
	}

	//Play the scream sound when rage is released
	public void PlayScream(){
		myAudioPlayer.loop = false;

		if (myAudioPlayer.clip != screamClip) {
			myAudioPlayer.clip = screamClip;
		}

		if (!myAudioPlayer.isPlaying) {
			myAudioPlayer.Play ();
		}
	}

	//Play the moan sound when collided with object
	public void PlayMoan(){
		myAudioPlayer.loop = false;

		if (myAudioPlayer.clip != moanClip) {
			myAudioPlayer.clip = moanClip;
		}
			
		myAudioPlayer.Play ();
	}
}
