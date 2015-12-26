using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {
	public string nameSencedCall;
	SwipePage swipePageScritp;
	Vector3 mouseDown,mouseUp;
	void OnMouseDown(){
		mouseDown= Input.mousePosition/100f;
	}

	void OnMouseUp(){
		mouseUp= Input.mousePosition/100f;
		if (Mathf.Abs (mouseDown.x - mouseUp.x) < 0.02f) {
			print (nameSencedCall);
			if(nameSencedCall=="RGS3_Rabbit213"){
				Application.LoadLevel("RGS3_Rabbit213");
			}
		}

	}
}
