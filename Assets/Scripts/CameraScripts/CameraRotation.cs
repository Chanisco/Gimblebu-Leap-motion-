using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
	float zRotation 		= 0;

	void Update () {
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);
		zRotation = 90 * Global.turnWorld;
		/*if(Global.turnWorld == 0){
			zRotation = 0;
		}
		if(Global.turnWorld == 1){
			zRotation = 90;
		}
		if(Global.turnWorld == 2){
			zRotation = 180;
		}
		if(Global.turnWorld == 3){
			zRotation = 270;
		}*/
	}
}
