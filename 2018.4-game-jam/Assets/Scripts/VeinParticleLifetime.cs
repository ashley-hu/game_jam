using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * VeinParticleLifetime class
 * Keeps track of how long the vein particle will live
 * Appears when player collides with obstacle
*/
public class VeinParticleLifetime : MonoBehaviour {

	public float lifetime;
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;

		//Destroy after set time
		if (lifetime <= 0) {
			Destroy (this.gameObject);
		}
	}
}
