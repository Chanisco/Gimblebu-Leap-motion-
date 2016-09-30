using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	
	void OnTriggerEnter(Collider other) {
		if(other.GetComponent<Collider>().tag == "Mouse"){
			Debug.Log("YOU HIT ME");
		}
	}
}
