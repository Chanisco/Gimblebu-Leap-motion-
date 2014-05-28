using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		if(other.collider.tag == "Mouse"){
			Debug.Log("YOU HIT ME");
		}
	}
}
