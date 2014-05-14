using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
/*	private bool isNrOne = false;
	private bool isNrTwo = true;
	private bool isNrThree = false;
	private bool isNrFour = false;*/
	float zRotationOne 		= 0;
	float zRotationTwo 		= 90;
	float zRotationThree 	= 180;
	float zRotationFour 	= 270;

	void Start(){

	}

	void Update () {
		Debug.Log(transform.rotation.z);
		if(Global.turnWorld == 0){
			TurnOne();
		}
		if(Global.turnWorld == 1){
			TurnTwo();
		}
		if(Global.turnWorld == 2){
			TurnThree();
		}
		if(Global.turnWorld == 3){
			TurnFour();
		}
	}

	void TurnOne(){
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotationOne);
	}
	void TurnTwo(){
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotationTwo);
	}
	void TurnThree(){
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotationThree);
	}
	void TurnFour(){
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotationFour);
	}
}
