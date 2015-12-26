using UnityEngine;
using System.Collections;

public class SwipePage : MonoBehaviour {

	public float speedAuto;
	public float capSoCong;
	public float soGameObjectCanSwipe;
	public float vtXBatDauClick,vtXKetThucClick;
//	public bool trangThaiClickDown=true;

	float vtGiua= -3.4f;
	int i;
	bool isLuotPhai=false;

	float vtXBatDauClick1,kc;
	
	void Start(){
		vtGiua = capSoCong / 2f;
	}
	
	void Update () {
		SwipeDaOk ();	
	}
	
	void SwipeDaOk(){
		//Vector3 M = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		var M= Input.mousePosition/100f;
		if (Input.GetMouseButtonDown (0)) {
			vtXBatDauClick=M.x;
			vtXBatDauClick1=M.x;
			kc=transform.position.x-M.x;
		}
		if (Input.GetMouseButtonUp (0)) {
			vtXKetThucClick=M.x;
			if(vtXKetThucClick-vtXBatDauClick>0){
				isLuotPhai=true;
			}
			else{
				isLuotPhai=false;
			}
		}
		if (Input.GetMouseButton (0)) {
			float h=M.x-vtXBatDauClick1;

			if(transform.position.x<=0.8f&&transform.position.x>=-0.8f){
				if(h<0){
					transform.position=new Vector3(M.x+kc,transform.position.y,transform.position.z);
				}
			}
			else if(transform.position.x>=capSoCong*soGameObjectCanSwipe-0.8f&&transform.position.x<=capSoCong*soGameObjectCanSwipe+0.8f){
				if(h>0){
					transform.position=new Vector3(M.x+kc,transform.position.y,transform.position.z);
				}
			}
			else{
				transform.position=new Vector3(M.x+kc,transform.position.y,transform.position.z);
			}
		} else {
			MoveAuto();
		}
	}
	

	void MoveAuto(){
		if (!isLuotPhai) {
			Luot (-1);
		} else
			Luot (1);
	}
	
	void Luot(int trai){
		if (transform.position.x > vtGiua  && transform.position.x < 0 - 0.9f) {
			i = 0;
			if(trai>0)
				i = 0;
			else
				i=1;	
			transform.Translate (speedAuto*trai, 0, 0);
		} else if (transform.position.x > vtGiua + capSoCong && transform.position.x < capSoCong - 0.5f) {
//			ChonIDiChuyen(1,trai); Khi chay ham nay bi loi kho hieu.:v
			if(trai>0)
				i = 1;
			else
				i=0;	
			transform.Translate (speedAuto*trai, 0, 0);
		} else if (transform.position.x > vtGiua + capSoCong * 2 && transform.position.x < capSoCong * 2 - 0.5f) {
			if(trai>0)
				i = 2;
			else
				i=1;	
			transform.Translate (speedAuto*trai, 0, 0);
		} else if (transform.position.x > vtGiua + capSoCong * 3 && transform.position.x < capSoCong * 3 - 0.5f) {
			if(trai>0)
				i = 3;
			else
				i=2;	
			transform.Translate (speedAuto*trai, 0, 0);
		} else if (transform.position.x > vtGiua + capSoCong * 4 && transform.position.x < capSoCong * 4 - 0.5f) {
			if(trai>0)
				i = 4;
			else
				i=3;			
			transform.Translate (speedAuto*trai, 0, 0);
		}else if (transform.position.x > vtGiua + capSoCong * 5 && transform.position.x < capSoCong * 5 - 0.5f) {
			if(trai>0)
				i = 5;
			else
				i=4;	
			transform.Translate (speedAuto*trai, 0, 0);
		} else if (transform.position.x > vtGiua + capSoCong * 6 && transform.position.x < capSoCong * 6 - 0.5f) {
			if(trai>0)
				i = 6;
			else
				i=5;	
			transform.Translate (speedAuto*trai, 0, 0);
		} else if (transform.position.x > vtGiua + capSoCong * 7 && transform.position.x < capSoCong * 7 - 0.5f) {
			if(trai>0)
				i = 7;
			else
				i=6;			
			transform.Translate (speedAuto*trai, 0, 0);
		} else if (transform.position.x > vtGiua + capSoCong * 8 && transform.position.x < capSoCong * 8 - 0.5f) {
			if(trai>0)
				i = 8;
			else
				i=7;	
			transform.Translate (speedAuto*trai, 0, 0);
		} else if (transform.position.x > vtGiua + capSoCong * 9 && transform.position.x < capSoCong * 9 - 0.5f) {
			if(trai>0)
				i = 9;
			else
				i=8;	
			transform.Translate (speedAuto*trai, 0, 0);
		} else if (transform.position.x > vtGiua + capSoCong * 10 && transform.position.x < capSoCong * 10 - 0.5f) {
			if(trai>0)
				i = 10;
			else
				i=9;			
			transform.Translate (speedAuto*trai, 0, 0);
		} else if (transform.position.x < vtGiua  && transform.position.x > capSoCong + 0.9f) {
			ChonIDiChuyen(1,trai);
			transform.Translate (speedAuto * trai, 0, 0);
		} else if (transform.position.x < vtGiua + capSoCong && transform.position.x > capSoCong * 2 + 0.5f) {
			ChonIDiChuyen(2,trai);
			transform.Translate (speedAuto * trai, 0, 0);
		} else if (transform.position.x < vtGiua + capSoCong * 2 && transform.position.x > capSoCong * 3 + 0.5f) {
			ChonIDiChuyen(3,trai);		
			transform.Translate (speedAuto *trai, 0, 0);
		} else if (transform.position.x < vtGiua + capSoCong * 3 && transform.position.x > capSoCong * 4 + 0.5f) {
			ChonIDiChuyen(4,trai);
			transform.Translate (speedAuto *trai, 0, 0);
		} else if (transform.position.x < vtGiua + capSoCong* 4 && transform.position.x > capSoCong * 5 + 0.5f) {
			ChonIDiChuyen(5,trai);
			transform.Translate (speedAuto * trai, 0, 0);
		} else if (transform.position.x < vtGiua + capSoCong * 5 && transform.position.x > capSoCong * 6 + 0.5f) {
			ChonIDiChuyen(6,trai);		
			transform.Translate (speedAuto *trai, 0, 0);
		} else if (transform.position.x < vtGiua + capSoCong * 6 && transform.position.x > capSoCong * 7 + 0.5f) {
			ChonIDiChuyen(7,trai);
			transform.Translate (speedAuto *trai, 0, 0);
		}else if (transform.position.x < vtGiua + capSoCong * 7&& transform.position.x > capSoCong * 8 + 0.5f) {
			ChonIDiChuyen(8,trai);
			transform.Translate (speedAuto * trai, 0, 0);
		} else if (transform.position.x < vtGiua + capSoCong * 8 && transform.position.x > capSoCong * 9 + 0.5f) {
			ChonIDiChuyen(9,trai);		
			transform.Translate (speedAuto *trai, 0, 0);
		} else if (transform.position.x < vtGiua + capSoCong * 9 && transform.position.x > capSoCong * 10 + 0.5f) {
			ChonIDiChuyen(10,trai);
			transform.Translate (speedAuto *trai, 0, 0);
		}
		else {
			transform.position = new Vector3 (capSoCong * i, transform.position.y, transform.position.z);
		}
	}

	void ChonIDiChuyen(int iDuocChon,int traii){
		if(traii<0)
			i = iDuocChon;
		else
			i=iDuocChon-1;
	}

}
