using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * PlayerMovement class
 * This moves the player with the mouse
 * 
 * */

public class PlayerMovement : MonoBehaviour {

	//Variables for player position
	private float playerX;
	private float playerY;

	void Start(){
		//do not show the cursor on the player
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update () {

		//Get the mouse position
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
		Vector3 currMousePos = Camera.main.ScreenToWorldPoint(mousePos);

		//Keep the player in bounds so they do not go off screen
		if (currMousePos.x > -7 && currMousePos.x < 7 && currMousePos.y < 3.5f && currMousePos.y > -3.5f) {
			transform.position = currMousePos;
		} else { //set the bounds so player can not move out of camera
			playerX = currMousePos.x; //set the player to the mouse position
			playerY = currMousePos.y;

			//move the players along the x-axis boundary
			if (currMousePos.x < -7) {  //left side
				playerX = -7;
			} else if (currMousePos.x > 7) { //right side 
				playerX = 7;
			} 

			//move the players along the y-axis boundary
			if (currMousePos.y < -3.5f) { //bottom side
				playerY = -3.5f;
			} else if (currMousePos.y > 3.5f) { //top side
				playerY = 3.5f;
			}

			//player's position is the mouse position
			transform.position = new Vector3 (playerX, playerY, currMousePos.z);
		}
	}
}
