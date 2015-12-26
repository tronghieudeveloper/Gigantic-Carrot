using UnityEngine;
using System.Collections;

public class ButtonChuot : MonoBehaviour {

	private string kyTuCuoi;
	private float[] timeAnimation=new float[10];

	void Start(){
		kyTuCuoi =""+ this.gameObject.name [gameObject.name.Length - 2] + "" + gameObject.name [gameObject.name.Length - 1];
		timeAnimation [0] = 0.2f;
		timeAnimation [1] = GetComponent<SkeletonAnimation> ().skeleton.data.FindAnimation ("1.chui len").duration;
		timeAnimation [2] = GetComponent<SkeletonAnimation> ().skeleton.data.FindAnimation ("2.nhay len gam").duration;
		timeAnimation [3] = GetComponent<SkeletonAnimation> ().skeleton.data.FindAnimation ("3.lay carrot").duration;
		timeAnimation [4] = GetComponent<SkeletonAnimation> ().skeleton.data.FindAnimation ("Bi duoi 1").duration;
		timeAnimation [5] = GetComponent<SkeletonAnimation> ().skeleton.data.FindAnimation ("Bi duoi 2").duration;
		StartCoroutine (AnimationAutu());
	}

	IEnumerator AnimationAutu(){
		yield return new WaitForSeconds (timeAnimation[1]);
		GetComponent<SkeletonAnimation>().AnimationName="2.nhay len gam";
		yield return new WaitForSeconds (timeAnimation[2]);
		GetComponent<SkeletonAnimation>().AnimationName="3.lay carrot";
		GameObject.Find ("carrotFinish" + kyTuCuoi).GetComponent<BoxCollider> ().enabled = false;
		DestroyWithTime (timeAnimation [3]);
		StartCoroutine (SetActiveMucTieu());

	}


	//duoc goi tu ham CheckMucTieu() cua class ChuotPosition 
	//Duoc goi tu ham OnMouseDown() cua class TouchWithChuot
	public void AnimationControl(string dk){
		if (dk == "DuoiChuot") {
			ChuyenBoxColliderMucTieuVeTrue();
			if( GetComponent<SkeletonAnimation>().AnimationName=="1.chui len"){
				GameObject tChuotPosition=GameObject.Find ("ChuotPosition"+kyTuCuoi);
				if(tChuotPosition){
					Destroy(tChuotPosition.gameObject);
				}
				GetComponent<SkeletonAnimation>().AnimationName="Bi duoi 1";
				DestroyWithTime(timeAnimation [4]);
			}
			else if( GetComponent<SkeletonAnimation>().AnimationName=="2.nhay len gam"){
				GameObject tChuotPosition=GameObject.Find ("ChuotPosition"+kyTuCuoi);
				if(tChuotPosition){
					Destroy(tChuotPosition.gameObject);
				}				
				GetComponent<SkeletonAnimation>().AnimationName="Bi duoi 2";
				DestroyWithTime(timeAnimation [5]);
			}
			ChuyenBoxColliderMucTieuVeTrue();
		}

	}

	void ChuyenBoxColliderMucTieuVeTrue(){
		GameObject tCarrotMucTieu=GameObject.Find ("carrotFinish" + kyTuCuoi);
		if(tCarrotMucTieu)
			tCarrotMucTieu.GetComponent<BoxCollider> ().enabled = true;
	}

	IEnumerator SetActiveMucTieu(){
		yield return new WaitForSeconds (timeAnimation[0]);
		GameObject tMucTieu = GameObject.Find ("carrotFinish" + kyTuCuoi);
		if (tMucTieu) {
			tMucTieu.GetComponent<CotNuocCarot>().ResetLand();
			tMucTieu.gameObject.SetActive(false);
		}
	}

//	void OnMouseDown(){
//		AnimationControl ("DuoiChuot");
//	}

	void DestroyWithTime(float time){
		Invoke ("DestroyThisGameObject",time);
	}

	void DestroyThisGameObject(){
		Destroy (this.gameObject);
	}
}
