using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class Resize : MonoBehaviour {

	public void fingerCheck(Controller ctrl){
		Frame frame = ctrl.Frame();
		Finger leftFingr = frame.Fingers.Leftmost;
		Finger rightFingr = frame.Fingers.Rightmost;

		Debug.Log (leftFingr.IsExtended);

	}
}
