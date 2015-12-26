using UnityEngine;
using System.Collections;

public class LuuStatic : MonoBehaviour {
	public static int soCarotThuHoachDuoc=0;
	public static string[] kyTuCuoi = {"11","12","13","21","22","23","31","32","33"};

	void Start(){
		ResetStatic ();
	}

	public void ResetStatic(){
		soCarotThuHoachDuoc = 0;
	}
}
