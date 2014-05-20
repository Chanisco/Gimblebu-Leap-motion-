using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
	float zRotationOne 		= 0;
	float zRotationTwo 		= 90;
	float zRotationThree 	= 180;
	float zRotationFour 	= 270;

	void Update () {
		if(Global.turnWorld == 0){
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotationOne);
		}
		if(Global.turnWorld == 1){
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotationTwo);
		}
		if(Global.turnWorld == 2){
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotationThree);
		}
		if(Global.turnWorld == 3){
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotationFour);
		}
	}
}
