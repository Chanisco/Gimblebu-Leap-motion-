using UnityEngine;
using System.Collections;

public class PlayerGravity : MonoBehaviour {
	bool staatOpPlatform;

	void Update () {
		if(Global.turnWorld == 0){
			Physics.gravity = new Vector3(0,-5,0);
		}else if(Global.turnWorld == 1){
			Physics.gravity = new Vector3(5,0,0);
		}else if(Global.turnWorld == 2){
			Physics.gravity = new Vector3(0,5,0);
		}else if(Global.turnWorld == 3){
			Physics.gravity = new Vector3(-5,0,0);
		}
		NoleapTest();
	}

	void NoleapTest(){
		if(Input.GetKeyUp(KeyCode.Q)){
			if(Global.turnWorld != 3){
				Global.turnWorld += 1;

			}else{
				Global.turnWorld = 0;
			
			}
		}
	}
}
