﻿using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if(other.collider.tag == "Enemy"){
			Debug.Log("You lost a life!");
		}
	}
}