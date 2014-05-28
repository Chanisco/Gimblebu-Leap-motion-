using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
	float zRotation 		= 0;

	void Update () {
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);
		zRotation = 90 * Global.turnWorld;
	}
}
