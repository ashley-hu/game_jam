using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioPlayer : MonoBehaviour {

	public AudioClip screamClip;
	public AudioClip moanClip;

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

	public void PlayMoan(){
		myAudioPlayer.loop = false;

		if (myAudioPlayer.clip != moanClip) {
			myAudioPlayer.clip = moanClip;
		}
			
		myAudioPlayer.Play ();
	}
}
