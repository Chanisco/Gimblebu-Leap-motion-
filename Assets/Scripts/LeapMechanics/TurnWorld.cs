using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class TurnWorld : MonoBehaviour {
	//------de kleuren waarin de block gaan veranderen---//
	Color green 		= new Color(0,10,0);
	Color blue 			= new Color(0,0,10);
	Color red 			= new Color(10,0,0);
	Color yellow 		= new Color(10,10,0);
	Color lightBlue		= new Color(0,10,10);

	//--floats--//
	float canTurn 			= 0;
	float colorChoice 		= 0;
	float turnWorldCount 	= 0;
	float turnWorld 		= 0.014f;

	//--ints---//
	int turnNr		= 0;
	int end 		= 0;

	//---bools--//
	bool nextTurn 		= false;
	bool routinStart 	= true;
	bool tempTurn		= true;
	
	public void Turning (Controller ctrl) {
		ColorChange();
		Frame nowFrame = ctrl.Frame();
		float roll = nowFrame.Hands[0].PalmNormal.Roll;
		float rollRound = Mathf.Round(roll * 10);
		float turnWorldRound = Mathf.Round(Global.turnWorld);

		//Debug.Log("GlobalNr = " + Global.turnWorld + "turnNr = " + turnNr + "tempTurnWorld" + turnWorldCount);
		if(Global.turnWorld > 4){
			Global.turnWorld = 0;
		}

		if(rollRound < -15){
			tempTurn = true;
			Global.turnWorld += turnWorld;
			turnWorldCount += turnWorld;

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
				if(tempTurn){
					Global.turnWorld -= turnWorldCount;
					turnWorldCount = 0;
					tempTurn = false;
					Global.turnWorld = Mathf.Round(Global.turnWorld);
				}
				if(turnNr != 0){
					if(turnWorldRound != 3){
						Global.turnWorld += 1;
						turnNr -= 1;

					}else if(turnWorldRound == 4){
						Global.turnWorld = 0;
						turnNr -= 1;

					}
				
				}else{
				canTurn = 0;
				turnNr = 0;
				nextTurn = false;
				}
			}else{
				if(Global.turnWorld > turnWorldRound && tempTurn == true){
					Global.turnWorld -= turnWorld;

				}else{
					Global.turnWorld = turnWorldRound;
					turnWorldCount = 0;
					tempTurn = false;
				}
			}

		}
	}

	IEnumerator CheckforTurns(){
		end 	= 1;
		canTurn = 0;
		turnNr	= 0;
		while(canTurn != end && !routinStart){
			canTurn += 1;
			yield return new WaitForSeconds(1);

			if(canTurn == end){
				if(turnNr != 3){
					nextTurn = true;
					turnNr += 1;
					end += 1;
					colorChoice += 1;
				}else{
					colorChoice = 2;
					turnNr = 0;
					end += 3;
				}

			}

		}
	}

	void ColorChange(){
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
