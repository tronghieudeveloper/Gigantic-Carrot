using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CotNuocCarot : MonoBehaviour {

	public Image phanTramCotNuoc;
	public float max_helth=100f;
	public float cur_helth=0f;

	private bool isDie;
	// Use this for initialization
	void Start () {
		cur_helth = max_helth;
		InvokeRepeating ("degreaseHelth",1f,1f);
	}
	public float cal_helth;
	void degreaseHelth(){
		cur_helth -= 1f;
		cal_helth = cur_helth / max_helth;
		if (gameObject.activeInHierarchy) {
			Animator animator = transform.FindChild ("Carot").GetComponent<Animator> ();
			if (cal_helth < -0.2f) {
				ResetLand ();
				Destroy (this.gameObject);
			} else if (cal_helth < 0.35f) {
				isDie = true;
				animator.SetBool ("carrotDie", true);
				if (animator.GetBool ("carotTuoiLai"))
					animator.SetBool ("carotTuoiLai", false);
			} else if (cal_helth < 0.5f) {
				animator.SetBool ("la3Rung", true);
				if (isDie && !animator.GetBool ("carotTuoiLai"))
					animator.SetBool ("carotTuoiLai", true);
			} else if (cal_helth < 0.65f) {
				animator.SetBool ("la2Rung", true);
				if (isDie && !animator.GetBool ("carotTuoiLai"))
					animator.SetBool ("carotTuoiLai", true);
			} else if (cal_helth < 0.85f) {
				animator.SetBool ("la1Rung", true);
				if (isDie && !animator.GetBool ("carotTuoiLai"))
					animator.SetBool ("carotTuoiLai", true);
			}
			SetHelth (cal_helth);
		}

	}

	void OnMouseDown(){
		if (cal_helth >= 0.35f) {
			LuuStatic.soCarotThuHoachDuoc++;
			GameObject.Find ("ScoreText").GetComponent<Text> ().text = "x" + LuuStatic.soCarotThuHoachDuoc;
			ResetLand ();
			Destroy (this.gameObject);
		}
	}

	//Duoc goi tu class ButtonChuot
	public void ResetLand(){
		GameObject.Find("Land"+this.gameObject.name[this.gameObject.name.Length-2]+""+this.gameObject.name[this.gameObject.name.Length-1]).GetComponent<Land>().needItemName="shovel";
	}

	void SetHelth(float h){
		phanTramCotNuoc.fillAmount = h;
	}
}
