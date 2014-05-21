using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(Global.turnWorld == 0){
			if(Input.GetKey(KeyCode.A)){
				transform.Translate(-5 * Time.deltaTime	,0,0);
			}else if(Input.GetKey(KeyCode.D)){
				transform.Translate(5  * Time.deltaTime,0,0);
			}	
		}else if(Global.turnWorld == 1){
			if(Input.GetKey(KeyCode.A)){
				transform.Translate(0,-5 * Time.deltaTime,0);
			}else if(Input.GetKey(KeyCode.D)){
				transform.Translate(0,5  * Time.deltaTime,0);
			}
		}else if(Global.turnWorld == 2){
			if(Input.GetKey(KeyCode.A)){
				transform.Translate(5 * Time.deltaTime	,0,0);
			}else if(Input.GetKey(KeyCode.D)){
				transform.Translate(-5  * Time.deltaTime,0,0);
			}
		}else if(Global.turnWorld == 3){
			if(Input.GetKey(KeyCode.A)){
				transform.Translate(0,5 * Time.deltaTime,0);
			}else if(Input.GetKey(KeyCode.D)){
				transform.Translate(0,-5  * Time.deltaTime,0);
			}
		}
	}
}
