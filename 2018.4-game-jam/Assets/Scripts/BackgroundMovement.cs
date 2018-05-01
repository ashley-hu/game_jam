using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BackgroundMovement class
 * This scrolls the background to make it look like the player is moving upwards in the scene
 * 
 * */
public class BackgroundMovement : MonoBehaviour {

	public float movingSpeed;
	public GameObject cameraPos;

	// Update is called once per frame
	void Update () {
		//checks the camera position with the associated background position
		if (transform.position.y <= (cameraPos.transform.position.y - 16)) { 
			//move the background back to the original position so it cycles
			transform.position = new Vector3(cameraPos.transform.position.x, (cameraPos.transform.position.y + 7.5f), 0);
		} else {
			transform.position += movingSpeed * Vector3.down; //move the background down
		}
	}
}
