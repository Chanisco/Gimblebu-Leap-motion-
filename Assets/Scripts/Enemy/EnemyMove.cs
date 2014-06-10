using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	private float 	speed = 2;
	private Vector3 Rotation = new Vector3(0,0,0);
	// Update is called once per frame
	void Update () {
		transform.Translate(speed * Time.deltaTime,0,0);
		transform.eulerAngles = Rotation;

	}
	void OnTriggerEnter(Collider other) {
		if(other.collider.tag == "MoveBack"){
			if(Rotation.y == 0){
				Rotation = new Vector3(0,180,0);

			}else{
				Rotation = new Vector3(0,0,0);

			}
		}
	}
}
