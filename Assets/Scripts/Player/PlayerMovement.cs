using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	bool standingOnPlane;

	int HeadButCount = 0;
	int walking = 0;

	bool headbutBool = true;
	AudioClip Tok;
	Animator animator;

	void Start(){
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		animator.SetInteger("Headbut",HeadButCount);
		animator.SetInteger("Walking", walking);

		if(standingOnPlane){
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
				transform.Translate(-10 * Time.deltaTime	,0,0);
			} if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
				walking = 1;
				transform.Translate(10  * Time.deltaTime,0,0);
			} else {
				walking = 0;
			}
			/*if(Global.turnWorld == 0){
				if(Input.GetKey(KeyCode.A)){
					transform.Translate(-10 * Time.deltaTime	,0,0);
				}else if(Input.GetKey(KeyCode.D)){
					transform.Translate(10  * Time.deltaTime,0,0);
				}	
			}else if(Global.turnWorld == 1){
				if(Input.GetKey(KeyCode.A)){
					transform.Translate(0,-10 * Time.deltaTime,0);
				}else if(Input.GetKey(KeyCode.D)){
					transform.Translate(0,10  * Time.deltaTime,0);
				}
			}else if(Global.turnWorld == 2){
				if(Input.GetKey(KeyCode.A)){
					transform.Translate(10 * Time.deltaTime	,0,0);
				}else if(Input.GetKey(KeyCode.D)){
					transform.Translate(-10  * Time.deltaTime,0,0);
				}
			}else if(Global.turnWorld == 3){
				if(Input.GetKey(KeyCode.A)){
					transform.Translate(0,10 * Time.deltaTime,0);
				}else if(Input.GetKey(KeyCode.D)){
					transform.Translate(0,-10  * Time.deltaTime,0);
				}
			}*/
		}
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
			if(headbutBool){
				AudioSource.PlayClipAtPoint(Tok, transform.position,10);
				HeadButCount = 50;
				headbutBool = false;
			}
		}
		if(HeadButCount > 3){
			HeadButCount -= 1;
		}else{
			headbutBool = true;
		}

	}

	void OnCollisionEnter(Collision other) {
		if(other.collider.tag == ConstantsTags.Platform){
			standingOnPlane = true;
		}
	}
	void OnCollisionExit(Collision other){
		if(other.collider.tag == ConstantsTags.Platform){
			standingOnPlane = false;
		}
	}



}
