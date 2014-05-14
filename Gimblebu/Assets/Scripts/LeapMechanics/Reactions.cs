using UnityEngine;
using System.Collections;
using Leap;

public class Reactions : MonoBehaviour {
	public static Controller controller;
	float SideFieldMin = -25f;
	float SideFieldMax = 25f;
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
		float MovementY;
		float MovementX;

		Frame frame = controller.Frame();


		HandList h = frame.Hands;
		hndCheck.HandCheck(controller);
		trnCheck.Turning(controller);

		foreach(Hand hand in h)
		{
			{
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

		}

		if(transform.position.x < SideFieldMin){
			transform.position = new Vector3(SideFieldMin,transform.position.y,0);
		}
		if(transform.position.x > SideFieldMax){
			transform.position = new Vector3(SideFieldMax,transform.position.y,0);
		}

		if(transform.position.y < SideFieldMin){
			transform.position = new Vector3(transform.position.x,SideFieldMin,0);
		}
		if(transform.position.y > SideFieldMax){
			transform.position = new Vector3(transform.position.x,SideFieldMax,0);
		}
	}
}
