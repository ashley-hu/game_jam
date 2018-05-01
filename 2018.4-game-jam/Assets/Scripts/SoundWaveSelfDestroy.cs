using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaveSelfDestroy : MonoBehaviour {

	public float surviveTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		surviveTime -= Time.fixedDeltaTime;

		if (surviveTime <= 0) {
			Destroy (this.gameObject);
		}
	}
}
