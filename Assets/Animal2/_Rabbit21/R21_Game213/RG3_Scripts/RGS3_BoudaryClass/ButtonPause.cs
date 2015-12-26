using UnityEngine;
using System.Collections;

public class ButtonPause : MonoBehaviour {

	void OnMouseDown(){
		if (Time.timeScale != 0) {
			Time.timeScale = 0;
		} else
			Time.timeScale = 1f;
	}
}
