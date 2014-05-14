using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

public class TurnWorld : MonoBehaviour {
	Color green = new Color(0,10,0);
	Color blue = new Color(0,0,10);
	Color origin;

	float canTurn = 0;

	bool nextTurn = false;

	void Awake(){
		origin = renderer.material.color;
	}
	public void Turning (Controller ctrl) {
		Frame frame = ctrl.Frame();

		HandList h = frame.Hands;
		
		foreach(Hand hand in h)
		{
			Frame nowFrame = ctrl.Frame();
			float roll = nowFrame.Hands[0].PalmNormal.Roll;
			float rollRound = Mathf.Round(roll * 10);

			//Vector handRot = hand.RotationAxis(nowFrame);
			if(rollRound < -20){
				StartCoroutine(CheckforTurns());
				renderer.material.color = green;
			}else{
				canTurn = 0;
				renderer.material.color = blue;
				if(nextTurn){
					if(Global.turnWorld != 3){
						Debug.Log("World is turning = " + Global.turnWorld);
						Global.turnWorld += 1;
					}else if(Global.turnWorld == 3){
						Global.turnWorld = 0;
					}
					nextTurn = false;
				}
			}
//			Debug.Log(Mathf.Round(roll * 10));
		}
	}

	IEnumerator CheckforTurns(){

		int End = 10;
		if(canTurn != End){
			Debug.Log("Nr turn = "+ canTurn);
			canTurn += 1;
			yield return new WaitForSeconds(1);
			if(canTurn == End){
				nextTurn = true;
			}
		}
	}
}
