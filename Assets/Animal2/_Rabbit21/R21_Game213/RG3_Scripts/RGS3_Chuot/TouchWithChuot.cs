using UnityEngine;
using System.Collections;

public class TouchWithChuot : MonoBehaviour {

	void OnMouseDown(){
		transform.parent.transform.parent.transform.parent.transform.parent.GetComponent<ButtonChuot> ().AnimationControl ("DuoiChuot");

		//AnimationControl ("DuoiChuot");
	}
}
