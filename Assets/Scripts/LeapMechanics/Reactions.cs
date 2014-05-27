using UnityEngine;
using System.Collections;
using Leap;

public class Reactions : MonoBehaviour {
	public GameObject Player;
	public static Controller controller;

	FistCheck hndCheck;
	TurnWorld trnCheck;
		
		// Use this for initialization
	void Awake () {
		controller = new Controller();
		hndCheck = (FistCheck)GetComponent<FistCheck>();
		trnCheck = (TurnWorld)GetComponent<TurnWorld>();
	}
	
	// Update is called once per frame
	void Update () {
		float sideFieldMinX = 	-25f 	- Player.transform.position.x;
		float sideFieldMaxX = 	25f 	+ Player.transform.position.x;
		float sideFieldMinY = 	-25f 	- Player.transform.position.y;
		float sideFieldMaxY = 	25f 	+ Player.transform.position.y;
		//Debug.Log(sideFieldMaxX);
		float MovementY;
		float MovementX;

		Frame frame = controller.Frame();


		HandList h = frame.Hands;
		hndCheck.HandCheck(controller);
		trnCheck.Turning(controller);

		foreach(Hand hand in h){
				MovementY = hand.PalmPosition.y;
				MovementX = hand.PalmPosition.x;

				if(hand.PalmPosition.z < 0 && !Global.fist){
					if(Global.turnWorld == 0){
						Vector3 MovPosition = new Vector3(MovementX / 50 ,MovementY / 150,0);
						transform.Translate(0,-1,0);
						transform.Translate(MovPosition);
					}

					if(Global.turnWorld == 1){
						Vector3 MovPosition = new Vector3(-MovementY / 150,MovementX / 50,0);
						transform.Translate(1,0,0);
						transform.Translate(MovPosition);
					}

					if(Global.turnWorld == 2){
						Vector3 MovPosition = new Vector3(-MovementX / 50,-MovementY / 150,0);
						transform.Translate(0,1,0);
						transform.Translate(MovPosition);
					}

					if(Global.turnWorld == 3){
						Vector3 MovPosition = new Vector3(MovementY / 150,-MovementX / 50,0);
						transform.Translate(-1,0,0);
						transform.Translate(MovPosition);
					}
					
				}

		}

		if(transform.position.x < sideFieldMinX){
			transform.position = new Vector3(sideFieldMinX,transform.position.y,0);
		}
		if(transform.position.x > sideFieldMaxX){
			transform.position = new Vector3(sideFieldMaxX,transform.position.y,0);
		}

		if(transform.position.y < sideFieldMinY){
			transform.position = new Vector3(transform.position.x,sideFieldMinY,0);
		}
		if(transform.position.y > sideFieldMaxY){
			transform.position = new Vector3(transform.position.x,sideFieldMaxY,0);
		}
	}
}
