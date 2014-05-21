using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	bool standingOnPlane;

	// Update is called once per frame
	void Update () {
		if(standingOnPlane){
			if(Global.turnWorld == 0){
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
			}
		}
	}

	void OnCollisionEnter(Collision other) {
		if(other.collider.tag == "Platform"){
			Debug.Log("ik sta erop");
			standingOnPlane = true;
		}
	}
	void OnCollisionExit(Collision other){
		if(other.collider.tag == "Platform"){
			standingOnPlane = false;
		}
	}



}
