using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);
		Vector3 currMousePos = Camera.main.ScreenToWorldPoint(mousePos);
		transform.position = currMousePos;
	}
}
