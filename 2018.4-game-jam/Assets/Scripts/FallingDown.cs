using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDown : MonoBehaviour {

	//public Transform blocks;
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
		blocks = Resources.Load("Blocks");
		currTimer = 1f;
		increaseAmount = 3;
		increaseCounter = 0;
		minSpeed = 0f;
		maxSpeed = 1f;
		for(int x = 0; x < increaseAmount; x++){
			posX = Random.Range (-6.5f, 6.5f);
			posY = Random.Range (6.0f, 10.0f);
			//Instantiate(blocks, new Vector3(posX, posY, 0), Quaternion.identity);
			Create(minSpeed, maxSpeed, posX, posY);
		}

		spriteArray [0] = sprite0;
		spriteArray [1] = sprite1;
		spriteArray [2] = sprite2;
		spriteArray [3] = sprite3;
	}
	
	// Update is called once per frame
	void Update () {
		currTimer -= Time.deltaTime;
		if (currTimer < 0) {
			increaseCounter++;
			if (increaseCounter >= 5) {
				if (increaseAmount <= 9) {
					increaseAmount += 1;
				}
				increaseCounter = 0;
			}
			currTimer = 1f;
			for (int x = 0; x < increaseAmount; x++) {
				posX = Random.Range (-6.5f, 6.5f);
				posY = Random.Range (6.0f, 10.0f);
				//Instantiate (blocks, new Vector3 (posX, posY, 0), Quaternion.identity);
				minSpeed += 0.01f;
				maxSpeed += 0.01f;
				if (minSpeed >= 0.5f) {
					minSpeed = 0.5f;
				}
				if (maxSpeed >= 3) {
					maxSpeed = 3f;
				}
				Create(minSpeed, maxSpeed, posX, posY);
			}
		}
	}

	BlockOptions Create(float minS, float maxS, float x, float y){
		GameObject newObject = Instantiate(blocks, new Vector3(x, y, 0), Quaternion.identity) as GameObject;

		int spriteNum = Random.Range (0, 4);
		while (spriteNum < 0 || spriteNum > 3) {
			spriteNum = Random.Range (0, 4);
		}
		newObject.GetComponent<SpriteRenderer> ().sprite = spriteArray [spriteNum];

		float scale = Random.Range (0.8f, 1.2f);
		newObject.transform.localScale = new Vector3 (scale, scale, 1);

		BlockOptions obs = newObject.GetComponent<BlockOptions>();
		obs.speed = Random.Range (minS, maxS);
		return obs;
	}
}
