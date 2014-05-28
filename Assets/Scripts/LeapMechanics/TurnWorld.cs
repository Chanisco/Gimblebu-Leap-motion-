﻿using UnityEngine;
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
		Frame nowFrame = ctrl.Frame();
		float roll = nowFrame.Hands[0].PalmNormal.Roll;
		float rollRound = Mathf.Round(roll * 10);
		Debug.Log(rollRound);

			if(rollRound < -18 || rollRound == 31){
				turnWorldCount += turnWorld;
				Global.turnWorld += turnWorld;
				tempTurn = true;
				if(routinStart){
					routinStart = false;
					colorChoice = 2;
					StartCoroutine("CheckforTurns");
				}

			}else{
				routinStart = true;
				if(tempTurn){
					Global.turnWorld -= turnWorldCount;
					tempTurn = false;
				}
				StopCoroutine("CheckforTurns");
				colorChoice = 1;
				if(nextTurn){
					turnWorldCount = 0;
					Debug.Log(Global.turnWorld);
					while(turnNr != 0){
						if(Global.turnWorld != 3){
							Global.turnWorld = Mathf.Round(Global.turnWorld);
							Global.turnWorld += 1;
							turnNr -= 1;

						}else if(Global.turnWorld == 3){
							Global.turnWorld = 0;
							turnNr -= 1;

						}
						Debug.Log(Global.turnWorld);

					
					}
					canTurn = 0;
					turnNr = 0;
					nextTurn = false;
				}

		}
	}

	IEnumerator CheckforTurns(){
		end 	= 1;
		canTurn = 0;
		turnNr	= 0;
		while(canTurn != end && !routinStart){
			float isTurnPos = turnNr + Global.turnWorld;
			Debug.Log("kan ik turnen? = " + isTurnPos);

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
