using UnityEngine;
using System.Collections;

public class Decimale {

	public float TwoDecimal(float Number){
		Number = Mathf.Round(Number * 100) / 100;
		return Number;
	}
}
