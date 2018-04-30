using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioPlayer : MonoBehaviour {

	public AudioClip screamClip;

	AudioSource myAudioPlayer;

	// Use this for initialization
	void Start () {
		myAudioPlayer = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void PlayScream(){
		myAudioPlayer.loop = false;

		if (myAudioPlayer.clip != screamClip) {
			myAudioPlayer.clip = screamClip;
		}

		if (!myAudioPlayer.isPlaying) {
			myAudioPlayer.Play ();
		}
	}
}
