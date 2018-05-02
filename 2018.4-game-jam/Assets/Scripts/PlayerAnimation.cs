using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	public Color normalColor;
	public Color upsetColor;
	public Color pissedColor;
	public Color angryColor;


	Animator myAnim;
	SpriteRenderer mySpriRend;

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
		} else if (GameManager.currRage <= (2 * (GameManager.maxRage / 4f))) {
			MakeUpset ();
			mySpriRend.color = upsetColor;
		} else if (GameManager.currRage <= (3 * (GameManager.maxRage / 4f))) {
			MakePissed ();
			mySpriRend.color = pissedColor;
		} else {
			MakeAngry ();
			mySpriRend.color = angryColor;
		}
	}


	void MakeNormal(){
		myAnim.SetBool ("IsNormal", true);
		myAnim.SetBool ("IsUpset", false);
		myAnim.SetBool ("IsPissed", false);
		myAnim.SetBool ("IsAngry", false);
		myAnim.SetBool ("IsBurned", false);
	}


	void MakeUpset(){
		myAnim.SetBool ("IsNormal", false);
		myAnim.SetBool ("IsUpset", true);
		myAnim.SetBool ("IsPissed", false);
		myAnim.SetBool ("IsAngry", false);
		myAnim.SetBool ("IsBurned", false);
	}


	void MakePissed(){
		myAnim.SetBool ("IsNormal", false);
		myAnim.SetBool ("IsUpset", false);
		myAnim.SetBool ("IsPissed", true);
		myAnim.SetBool ("IsAngry", false);
		myAnim.SetBool ("IsBurned", false);
	}


	void MakeAngry(){
		myAnim.SetBool ("IsNormal", false);
		myAnim.SetBool ("IsUpset", false);
		myAnim.SetBool ("IsPissed", false);
		myAnim.SetBool ("IsAngry", true);
		myAnim.SetBool ("IsBurned", false);
	}


	public void MakeStun(){
		myAnim.SetTrigger ("MakeStun");
	}


	public void MakeBurned(){
		myAnim.SetBool ("IsNormal", false);
		myAnim.SetBool ("IsUpset", false);
		myAnim.SetBool ("IsPissed", false);
		myAnim.SetBool ("IsAngry", false);
		myAnim.SetBool ("IsBurned", true);
	}
}
