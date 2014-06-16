using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if(other.collider.tag == ConstantsTags.Respawn){
			Application.LoadLevel("Level1");
		}
	}
}
