using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
/*	private bool isNrOne = false;
	private bool isNrTwo = true;
	private bool isNrThree = false;
	private bool isNrFour = false;*/

	void Start(){
		transform.Rotate(new Vector3(0,0,90));
	}

	void Update () {
		Debug.Log(transform.rotation.z);
		if(Global.turnWorld == 0){
			turnOne();
		}else if(Global.turnWorld == 1){
			TurnTwo();
		}
	}

	void turnOne(){
		if(transform.rotation.z != 0.25f){
			transform.Rotate(0,0,0.25f);
		}
	}
	void TurnTwo(){
		if(transform.rotation.z != 90){
			transform.Rotate(0,0,10);
		}
	}
}
