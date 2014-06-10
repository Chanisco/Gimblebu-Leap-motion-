using UnityEngine;
using System.Collections;

public class Decimale {

	public void TwoDecimal(float Number){
		Number = Mathf.Round(Number * 100) / 100;
	//	return Number;
	}
}
