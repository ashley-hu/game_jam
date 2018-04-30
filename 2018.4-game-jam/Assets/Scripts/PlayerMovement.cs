using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * PlayerMovement class
 * This moves the player with the mouse
 * */

public class PlayerMovement : MonoBehaviour {

	private float playerX;
	private float playerY;

	void Start(){
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update () {
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
		Vector3 currMousePos = Camera.main.ScreenToWorldPoint(mousePos);

		if (currMousePos.x > -7 && currMousePos.x < 7 && currMousePos.y < 3.5f && currMousePos.y > -3.5f) {
			transform.position = currMousePos;
		} else { //set the bounds so player can not move out of camera
			playerX = currMousePos.x;
			playerY = currMousePos.y;

			if (currMousePos.x < -7) {
				playerX = -7;
			} else if (currMousePos.x > 7) {
				playerX = 7;
			} 

			if (currMousePos.y < -3.5f) {
				playerY = -3.5f;
			} else if (currMousePos.y > 3.5f) {
				playerY = 3.5f;
			}

			transform.position = new Vector3 (playerX, playerY, currMousePos.z);
		}
	}
}
