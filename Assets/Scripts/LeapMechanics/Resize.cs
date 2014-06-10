using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class Resize : MonoBehaviour {
	GameObject parent;

	void Awake(){
		parent = transform.parent.gameObject;
	}
	public void fingerCheck(Controller ctrl){
		Frame frame = ctrl.Frame();
		Finger leftFingr = frame.Fingers.Leftmost;
		Finger rightFingr = frame.Fingers.Rightmost;

		Debug.Log ("Linker Finger = " + leftFingr.Direction.x +  "Rechter finger = " + rightFingr.Direction.x);


	}
}
