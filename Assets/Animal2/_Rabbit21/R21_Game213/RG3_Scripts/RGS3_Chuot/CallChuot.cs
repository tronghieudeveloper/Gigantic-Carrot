using UnityEngine;
using System.Collections;

public class CallChuot : MonoBehaviour {

	public GameObject Chuot;
	private Vector3 toaDoNull=new Vector3(-100f,-100f,-100f);

	void Start () {
		InvokeRepeating ("CallChuotRandom",0f,0.09f);
	}

	bool CheckChuotHienThi(){
		int i = 0;
		GameObject tChuot=GameObject.Find("Chuot"+LuuStatic.kyTuCuoi[i]);
		while(i<LuuStatic.kyTuCuoi.Length&&!tChuot){

			tChuot=GameObject.Find("Chuot"+LuuStatic.kyTuCuoi[i]);
			i++;
		}

		if (i == LuuStatic.kyTuCuoi.Length) {
			StartCoroutine(Tranh2Chuot());
			return true;
		}
		return false;
	}

	Vector3 RamdomPosition(int rd){
		GameObject tChuotPosition=GameObject.Find("ChuotPosition"+LuuStatic.kyTuCuoi[rd]);
		GameObject mucNuocCarrot = GameObject.Find ("carrotFinish" + LuuStatic.kyTuCuoi [rd]);
		//Neu ton tai vi tri ChuotPosition-> Ton Tai carrotFinish
		if (tChuotPosition&&mucNuocCarrot) {
			if( mucNuocCarrot.GetComponent<CotNuocCarot>().cal_helth>0.9f){
				StartCoroutine(Tranh2Chuot());
				return tChuotPosition.transform.position;
			}
			return toaDoNull;
		}
		return toaDoNull;
	}

	void CallChuotRandom(){
		int rd = Random.Range (0, LuuStatic.kyTuCuoi.Length);
		Vector3 positionRandom = RamdomPosition (rd);
		if (CheckChuotHienThi ()&&positionRandom!=toaDoNull) {

			StartCoroutine(Tranh2Chuot());
			GameObject chuot =Instantiate(Chuot,positionRandom,Quaternion.identity)as GameObject;
			chuot.gameObject.name="Chuot"+LuuStatic.kyTuCuoi[rd];
		}
	}

	IEnumerator Tranh2Chuot(){
		CancelInvoke("CallChuotRandom");
		yield return new WaitForSeconds(0.9f);
		InvokeRepeating ("CallChuotRandom",0f,0.09f);
	}

}
