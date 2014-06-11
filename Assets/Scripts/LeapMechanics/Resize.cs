using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class Resize : MonoBehaviour {
	GameObject parent;
	Hand hand;
	Decimale decimaal;
	void Awake(){
		decimaal = new Decimale();
		parent = transform.parent.gameObject;
	}
	public void fingerCheck(Controller ctrl){
		Frame frame = ctrl.Frame();
		Finger leftFingr = frame.Fingers.Leftmost;
		Finger rightFingr = frame.Fingers.Rightmost;
		float LeftFinger = decimaal.TwoDecimal(leftFingr.Direction.y);
		float rightFinger = decimaal.TwoDecimal(rightFingr.Direction.y);
		Debug.Log ("Linker Finger = " + LeftFinger +  "Rechter finger = " + rightFinger);


	}
}
