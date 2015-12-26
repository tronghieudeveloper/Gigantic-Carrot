using UnityEngine;
using System.Collections;

public class ButtonOver : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			var mousePos = Input.mousePosition;
			mousePos.z = 18f;
			transform.position = Camera.main.ScreenToWorldPoint (mousePos);
			TouchControl.instance.itemPosition=transform.position;
		} else {
			Destroy(this.gameObject);
		}

	}
}
