using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BackgroundMovement class
 * 
 * 
 * */
public class BackgroundMovement : MonoBehaviour {

	public float movingSpeed;
	public GameObject camera;

	// Use this for initialization
	void Start () {
	}


	// Update is called once per frame
	void Update () {
		if (transform.position.y <= (camera.transform.position.y - 16)) {
			transform.position = new Vector3(camera.transform.position.x, (camera.transform.position.y + 7), 0);
		} else {
			transform.position += movingSpeed * Vector3.down;
		}
	}
}
