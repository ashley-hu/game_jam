using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDown : MonoBehaviour {

	public Transform blocks;
	private float posX;
	private float posY;
	private float currTimer;

	// Use this for initialization
	void Start () {
		currTimer = 1f;
		for(int x = 0; x < 5; x++){
			posX = Random.Range (-6.5f, 6.5f);
			posY = Random.Range (7.0f, 10.0f);
			Instantiate(blocks, new Vector3(posX, posY, 0), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		currTimer -= Time.deltaTime;
		if (currTimer < 0) {
			currTimer = 1f;
			for (int x = 0; x < 5; x++) {
				posX = Random.Range (-6.5f, 6.5f);
				posY = Random.Range (7.0f, 10.0f);
				Instantiate (blocks, new Vector3 (posX, posY, 0), Quaternion.identity);
			}
		}
	}
}
