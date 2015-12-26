using UnityEngine;
using System.Collections;

public class Land : MonoBehaviour {

	public string landName;
	public string needItemName;


	// Use this for initialization
	void Start () {
		this.gameObject.name = ""+landName;
		needItemName = "shovel";
	}
	
	private void OnMouseOver(){
		CapThongTin ();
	}

	private void CapThongTin(){
		TouchControl.instance.landPosition = transform.position;
		TouchControl.instance.landName = this.gameObject.name;
		TouchControl.instance.landNeedItem = needItemName;
	}

	void LandFinish(){
		TouchControl.instance.GoiCotNuoc (transform.parent.name);
	}

}
