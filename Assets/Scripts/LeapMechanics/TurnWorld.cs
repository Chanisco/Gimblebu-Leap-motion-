using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class TurnWorld : MonoBehaviour {
	Color green 		= new Color(0,10,0);
	Color blue 			= new Color(0,0,10);
	Color red 			= new Color(10,0,0);
	Color yellow 		= new Color(10,10,0);
	Color lightBlue		= new Color(0,10,10);

	float canTurn 		= 0;
	float colorChoice 	= 0;

	int turnNr		= 0;
	int end 		= 0;

	bool nextTurn 		= false;
	bool routinStart 	= true;
	
	public void Turning (Controller ctrl) {
		Frame frame = ctrl.Frame();

		HandList h = frame.Hands;
		
		foreach(Hand hand in h)
		{
			Frame nowFrame = ctrl.Frame();
			float roll = nowFrame.Hands[0].PalmNormal.Roll;
			float rollRound = Mathf.Round(roll * 10);

			if(rollRound < -20){
				if(routinStart){
					routinStart = false;
					colorChoice = 2;
					StartCoroutine("CheckforTurns");
				}

			}else{
				routinStart = true;
				StopCoroutine("CheckforTurns");
				colorChoice = 1;
				if(nextTurn){
					while(turnNr != 0){
						if(Global.turnWorld != 3){
							Debug.Log("World is turning = " + Global.turnWorld + " " + turnNr);
							Global.turnWorld += 1;
							turnNr -= 1;
						}else if(Global.turnWorld == 3){
							Global.turnWorld = 0;
							turnNr -= 1;
						}
					
					}
					canTurn = 0;
					turnNr = 0;
					nextTurn = false;
				}
			}
		}
	}

	IEnumerator CheckforTurns(){
		end 	= 3;
		canTurn = 0;
		turnNr	= 0;
		while(canTurn != end && !routinStart){
			float isTurnPos = turnNr + Global.turnWorld;
			Debug.Log("kan ik turnen? = " + isTurnPos);

			canTurn += 1;
			yield return new WaitForSeconds(1);
			if(canTurn == end){
				//if(isTurnPos != 3){
				if(turnNr != 3){
					nextTurn = true;
					turnNr += 1;
					end += 3;
					colorChoice += 1;
					Debug.Log("kan ik turnen 2x? = " + turnNr);
				}else{
					colorChoice = 2;
					turnNr = 0;
					end += 3;
					Debug.Log("back to one");
				}
			}
		}
	}

	void Update(){
		if(colorChoice == 1){
			renderer.material.color = blue;
		}
		if(colorChoice == 2){
			renderer.material.color = green;
		}
		if(colorChoice == 3){
			renderer.material.color = red;
		}
		if(colorChoice == 4){
			renderer.material.color = yellow;
		}
		if(colorChoice == 5){
			renderer.material.color = lightBlue;
		}
	}
}
