using UnityEngine;
using System.Collections;
using Leap;

public class Reactions : MonoBehaviour {

	public static Controller controller;

	FistCheck 	hndCheck;
	TurnWorld 	trnCheck;
	Resize 		rszCheck;
	MouseMove 	MsCheck;
		
	void Awake () {
		controller = new Controller();
		hndCheck 	= (FistCheck)GetComponent<FistCheck>();
		trnCheck 	= (TurnWorld)GetComponent<TurnWorld>();
		rszCheck 	= (Resize)GetComponent<Resize>();
		MsCheck 	= (MouseMove)GetComponent<MouseMove>();
	}

	void Update () {
		rszCheck.fingerCheck(controller);
		MsCheck.Mouse(controller);
		hndCheck.HandCheck(controller);
		trnCheck.Turning(controller);

	
	}
}
