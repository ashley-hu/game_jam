using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * FallingDown class
 * This creates the obstacles that fall down the canvas
 * The obstacles will increase in speed and number as the game progresses
 * */

public class FallingDown : MonoBehaviour {

	//Variables for the obstacle
	private static float posX;
	private static float posY;
	private float currTimer;
	public static float increaseAmount;
	public static float increaseCounter;
	public static Object blocks; 
	public static float minSpeed;
	public static float maxSpeed;

	public Sprite sprite0;
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;

	Sprite[] spriteArray = new Sprite[4];

	// Use this for initialization
	void Start () {
		//Load the prefab from the resources folder
		blocks = Resources.Load("Blocks");
		currTimer = 1f;
		increaseAmount = 3;
		increaseCounter = 0;
		minSpeed = 0f;
		maxSpeed = 1f;

		//Instantiate 3 obstacles with a random speed and position when game starts  
		for(int x = 0; x < increaseAmount; x++){
			posX = Random.Range (-6.5f, 6.5f); //random x position on canvas
			posY = Random.Range (6.0f, 10.0f); //random y position on canvas
			Create(minSpeed, maxSpeed, posX, posY);
		}

		spriteArray [0] = sprite0;
		spriteArray [1] = sprite1;
		spriteArray [2] = sprite2;
		spriteArray [3] = sprite3;
	}
	
	// Update is called once per frame
	void Update () {
		//Create obstacles every second 
		currTimer -= Time.deltaTime;
		if (currTimer < 0) {
			//amount of obstacles increase as game continues
			increaseCounter++; 
			if (increaseCounter >= 5) { //increase the obstacles every 5 seconds
				if (increaseAmount <= 9) { //max cap at 9
					increaseAmount += 1;
				}
				increaseCounter = 0; //reset counter for increasing obstacles
			}
			currTimer = 1f;
			for (int x = 0; x < increaseAmount; x++) {
				//set a random x and y for the obstacle
				posX = Random.Range (-6.5f, 6.5f);
				posY = Random.Range (6.0f, 10.0f);
				//increase the speed for obstacle
				minSpeed += 0.01f;
				maxSpeed += 0.01f;
				if (minSpeed >= 0.5f) {
					minSpeed = 0.5f; //set a min speed cap
				}
				if (maxSpeed >= 3) {
					maxSpeed = 3f; //set a max speed cap
				}
				//Instantiate more obstacles with a random speed and position as game starts  
				Create(minSpeed, maxSpeed, posX, posY);
			}
		}
	}

	//Instantiate the obstacle with parameters 
	BlockOptions Create(float minS, float maxS, float x, float y){
		GameObject newObject = Instantiate(blocks, new Vector3(x, y, 0), Quaternion.identity) as GameObject;

		int spriteNum = Random.Range (0, 4);
		while (spriteNum < 0 || spriteNum > 3) {
			spriteNum = Random.Range (0, 4);
		}
		newObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [spriteNum];

		float scale = Random.Range (0.8f, 1.2f);
		newObject.transform.localScale = new Vector3 (scale, scale, 1);

		//Create the obstacle object with parameters and return the object 
		BlockOptions obs = newObject.GetComponent<BlockOptions>();
		obs.speed = Random.Range (minS, maxS);
		return obs;
	}
}
