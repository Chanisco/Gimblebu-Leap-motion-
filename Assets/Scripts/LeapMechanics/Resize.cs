using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class Resize : MonoBehaviour {
	public GameObject parent;
	Hand hand;
	Decimale decimaal;

	void Awake(){
		decimaal = new Decimale();
	//	parent = transform.parent.gameObject;
	}
	public void fingerCheck(Controller ctrl){
		Frame frame = ctrl.Frame();
		Frame previousFrame = ctrl.Frame(5);

			float pinch = 			decimaal.TwoDecimal(frame.Hands[0].PinchStrength);
			float previousPinch = 	decimaal.TwoDecimal(previousFrame.Hands[0].PinchStrength);
		if(pinch > 0.1){
			if(pinch > previousPinch){
				Shrink();
			}else if (pinch < previousPinch){
				Debug.Log("Fuck you");
				EnLarge();
			}
		}

			//Debug.Log("Pinch = " + pinch + " Previous Pinch = " + previousPinch);

			

			/*Finger leftFingr = frame.Fingers[0];
			Finger rightFingr = frame.Fingers[1];
		




			float LeftFinger = decimaal.TwoDecimal(leftFingr.Direction.y);
			float rightFinger = decimaal.TwoDecimal(rightFingr.Direction.y);
			float difference = LeftFinger -= rightFinger;

			if(difference < 0.4f && difference > 0f){
				Debug.Log("Rocuted");
			}
			Debug.Log ("Linker Finger = " + LeftFinger +  "Rechter finger = " + rightFinger);
		}*/




	}

	public void EnLarge(){
		parent.transform.localScale += new Vector3(0.01f, 0.01f, 0);
	}

	public void Shrink(){
		parent.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
	}
}
