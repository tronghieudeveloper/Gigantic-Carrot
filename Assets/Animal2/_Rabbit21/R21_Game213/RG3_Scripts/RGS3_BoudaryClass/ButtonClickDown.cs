using UnityEngine;
using System.Collections;

public class ButtonClickDown : MonoBehaviour {
	public string buttonDuocChon;
	public GameObject items;
	void OnMouseDown(){
		TouchControl.instance.itemName = buttonDuocChon;
		GoiItemGameObject ();
	}

	void GoiItemGameObject(){
		Instantiate (items, this.transform.position, Quaternion.identity);
	}

}
