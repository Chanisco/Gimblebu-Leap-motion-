using UnityEngine;
using System.Collections;
using Leap;

public class FistCheck : MonoBehaviour {
	// Update is called once per frame
	public void HandCheck (Controller ctrl) {
		Frame frame = ctrl.Frame();

		int fingrCount = frame.Fingers.Count;

		//----als er een vuist word gemaakt---//
		if(fingrCount == 0){
			Global.fist = true;
		}else{
			Global.fist = false;
		}

		//----als je wijst-------------------//
		if(fingrCount == 1){
			Global.point = true;
		}else{
			Global.point = false;
		}

		//----als je met 2 vingers erop staat---//
		if(fingrCount == 2){
			Global.rezise = true;
		}else{
			Global.rezise = false;
		}
	}
}
