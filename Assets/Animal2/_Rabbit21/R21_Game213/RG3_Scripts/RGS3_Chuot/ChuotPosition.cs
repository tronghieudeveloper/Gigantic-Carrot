using UnityEngine;
using System.Collections;

public class ChuotPosition : MonoBehaviour {
	private string nameMucTieu;
	private string kyTuCuoi;
	void Start(){
		nameMucTieu = gameObject.transform.parent.name;
		kyTuCuoi = nameMucTieu [nameMucTieu.Length - 2] + "" + nameMucTieu [nameMucTieu.Length - 1];
		SetParentt ();
		SetThisName ();
	}

	void SetParentt(){
		GameObject sParent = GameObject.Find ("ToaDo000");
		gameObject.transform.parent = sParent.transform;
	}

	void SetThisName(){
		this.gameObject.name = "ChuotPosition" + kyTuCuoi;
	}

	void Update(){
		CheckMucTieu ();
	}

	void CheckMucTieu(){
		GameObject tMucTieu = GameObject.Find ("" + nameMucTieu);
		if (!tMucTieu) {
			GameObject tChuot=GameObject.Find("Chuot"+kyTuCuoi);
			if(tChuot){
				Debug.Log("hayhay");
				tChuot.GetComponent<ButtonChuot>().AnimationControl("DuoiChuot");
			}
			Destroy(this.gameObject);
		}
	}

}
