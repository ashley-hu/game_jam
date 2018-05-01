using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	public Color normalColor;
	public Color upsetColor;
	public Color pissedColor;
	public Color angryColor;

	public GameObject firePrefab;

	bool isOnFire = false;
	Animator myAnim;
	SpriteRenderer mySpriRend;
	GameObject fireObject;

	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator> ();
		mySpriRend = GetComponent<SpriteRenderer> ();
	}


	// Update is called once per frame
	void Update () {
		if (GameManager.currRage <= (GameManager.maxRage / 4f)) {
			MakeNormal ();
			mySpriRend.color = normalColor;

			isOnFire = false;
			Destroy (fireObject);
		} else if (GameManager.currRage <= (2 * (GameManager.maxRage / 4f))) {
			MakeUpset ();
			mySpriRend.color = upsetColor;

			isOnFire = false;
		} else if (GameManager.currRage <= (3 * (GameManager.maxRage / 4f))) {
			MakePissed ();
			mySpriRend.color = pissedColor;

			isOnFire = false;
		} else {
			MakeAngry ();
			mySpriRend.color = angryColor;

			if (!isOnFire) {
				fireObject = Instantiate (firePrefab, transform.position, Quaternion.Euler (new Vector3 (-90, 0, 0))) as GameObject;
				fireObject.transform.localScale = new Vector3 (0.5f, 0f, 1f);

				isOnFire = true;
			}

			fireObject.transform.position = this.transform.position + 0.5f * Vector3.up;
		}
	}


	void MakeNormal(){
		myAnim.SetBool ("IsNormal", true);
		myAnim.SetBool ("IsUpset", false);
		myAnim.SetBool ("IsPissed", false);
		myAnim.SetBool ("IsAngry", false);

	}


	void MakeUpset(){
		myAnim.SetBool ("IsNormal", false);
		myAnim.SetBool ("IsUpset", true);
		myAnim.SetBool ("IsPissed", false);
		myAnim.SetBool ("IsAngry", false);

	}


	void MakePissed(){
		myAnim.SetBool ("IsNormal", false);
		myAnim.SetBool ("IsUpset", false);
		myAnim.SetBool ("IsPissed", true);
		myAnim.SetBool ("IsAngry", false);

	}


	void MakeAngry(){
		myAnim.SetBool ("IsNormal", false);
		myAnim.SetBool ("IsUpset", false);
		myAnim.SetBool ("IsPissed", false);
		myAnim.SetBool ("IsAngry", true);

	}


	public void MakeStun(){
		myAnim.SetTrigger ("MakeStun");
	}
}
