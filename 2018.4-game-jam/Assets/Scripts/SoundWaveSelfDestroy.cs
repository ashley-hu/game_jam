using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * SoundWaveSelfDestory
 * This class keeps track of how long the sound wave will live
 * The sound wave occurs after player releases their rage
*/
public class SoundWaveSelfDestroy : MonoBehaviour {

	public float surviveTime;

	// Update is called once per frame
	void Update () {
		surviveTime -= Time.fixedDeltaTime;

		//Destroy sound wave after set time
		if (surviveTime <= 0) {
			Destroy (this.gameObject);
		}
	}
}
