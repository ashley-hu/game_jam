using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * BlockOptions class
 * This class has the properties for each prefab (obstacle) created
 * */
public class BlockOptions : MonoBehaviour {

	//Variable for the speed of the block
	public float speed;

	//Variable for the player object
	GameObject player;

	// Use this for initialization
	void Start () {
		//move the obstacle down based on the speed set 
		transform.position = new Vector3 (transform.position.x, transform.position.y + speed, 0);
		//get the player object
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//move the prefab down the screen
		transform.position -= new Vector3(0, 1 + speed, 0) * Time.deltaTime * 5;

		//prefab will be destroyed when it moves below the canvas 
		if (transform.position.y < -5.5f) {
			Destroy (this.gameObject);
		}
	}

	//Check if obstacle collide with player 
	void OnCollisionEnter2D(Collision2D coll){
		//if collide with player, play animation and destroy the obstacle
		if(coll.gameObject.tag == "Player"){
			player.GetComponent<PlayerAnimation> ().MakeStun ();
			player.GetComponent<PlayerAudioPlayer> ().PlayMoan ();
			GameManager.currRage += 0.1f; //keep count of rage for losing condition
			Destroy (this.gameObject);
		}
	}
}
