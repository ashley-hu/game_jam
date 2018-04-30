using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOptions : MonoBehaviour {

	private float speed;

	GameObject player;

	// Use this for initialization
	void Start () {
		speed = Random.Range (0f, 1f);
		transform.position = new Vector3 (transform.position.x, transform.position.y + speed, 0);

		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//move the prefab down the screen
		transform.position -= new Vector3(0, 1+ speed, 0) * Time.deltaTime * 5;

		//prefab will be destroyed
		if (transform.position.y < -5.5f) {
			Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Player"){
			player.GetComponent<PlayerAnimation> ().MakeStun ();

			GameManager.currRage += 0.1f; //keep count of rage for losing condition
			Destroy (this.gameObject);
		}
	}
}
