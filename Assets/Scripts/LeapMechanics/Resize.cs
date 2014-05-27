using UnityEngine;
using System.Collections;
using Leap;

public class Resize : MonoBehaviour {

	public void fingerCheck(Controller ctrl){
		Frame frame = ctrl.Frame();

		Debug.Log("Hoeveelheid vingers: " + frame.Fingers.Count);


	}
}
