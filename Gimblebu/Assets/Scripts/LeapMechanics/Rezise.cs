using UnityEngine;
using System.Collections;
using Leap;

public class Rezise : MonoBehaviour {

	void fingerCheck(Controller ctrl){
		Frame frame = ctrl.Frame();
		HandList h = frame.Hands;

		foreach(Hand hand in h){

			float frontFinger = frame.Fingers.Frontmost.TouchDistance;
			Debug.Log(frontFinger);

		}


	}
}
