using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour {

	public float khoangCachLandVoiChuotX;
	public float khoangCachLandVoiChuotY;


	public static TouchControl instance;

	public string itemName; 			  //tu Class ButtonClickDown
	public Vector3 itemPosition; 		  //tu Class ButtonOver

	public string landName;				  //tu Class Land
	public string landNeedItem;			  //tu Class Land
	public Vector3 landPosition;		  //tu Class Land



	public GameObject aniShovel;
	public GameObject aniSeed;
	public GameObject aniWater;
	public GameObject aniWaterWhenFinish;
	public GameObject cotNuoc;

	private void Start(){

		if (instance == null)
			instance = this;
	}

	void Update(){
		if (Input.GetMouseButtonUp (0)) {
			ThaCheck (itemPosition,itemName,landPosition,landName,landNeedItem);
		}
	}



	// Duoc goi tu ham LandFinish Cua Class Land
	public void GoiCotNuoc(string nLandFinish){

		GameObject tLandFinish=GameObject.Find(""+nLandFinish);
		if(tLandFinish){

			GameObject cNuoc= Instantiate (cotNuoc,tLandFinish.transform.position,Quaternion.identity)as GameObject;
			cNuoc.gameObject.name="carrotFinish"+nLandFinish[nLandFinish.Length-2]+""+nLandFinish[nLandFinish.Length-1];

			Destroy (tLandFinish);
		}
	}



	private void ThaCheck(Vector3 iPosition,string iName,Vector3 lPosition,string lName,string lNeedItem){
		if (iName == lNeedItem&&Mathf.Abs(iPosition.x-lPosition.x)<khoangCachLandVoiChuotX&&Mathf.Abs(iPosition.y-lPosition.y)<khoangCachLandVoiChuotY) {
			//chose right:
		//	Debug.Log("chose right tha check");
			string kyTyCuoiViTriLand=string.Concat(lName[lName.Length-2],lName[lName.Length-1]);
			string nIteam= GameObject.Find(""+lName).GetComponent<Land>().needItemName;
			GameObject tItem=GameObject.Find(""+nIteam+""+kyTyCuoiViTriLand);

			if(!tItem){
				GameObject tItemFinsh=GameObject.Find("carrotFinish"+kyTyCuoiViTriLand);
				if(!tItemFinsh){
					GameObject tItemDangCo=null;
					GameObject aniDuocGoi=null;
					if(nIteam=="shovel"){
					
						aniDuocGoi = Instantiate(aniShovel,lPosition,Quaternion.identity)as GameObject;
						nIteam="seed";
					}
					else if(nIteam=="seed"){
						tItemDangCo=GameObject.Find("shovel"+kyTyCuoiViTriLand);

						aniDuocGoi = Instantiate(aniSeed,lPosition,Quaternion.identity)as GameObject;
						nIteam="water";
					}
					else{
						tItemDangCo=GameObject.Find("seed"+kyTyCuoiViTriLand);
						aniDuocGoi= Instantiate(aniWater,lPosition,Quaternion.identity)as GameObject;

					}
					if(tItemDangCo){
						Destroy(tItemDangCo.gameObject);
					}

					if(aniDuocGoi!=null){
						aniDuocGoi.gameObject.name=""+iName+""+kyTyCuoiViTriLand;		

					}
					GameObject.Find(""+lName).GetComponent<Land>().needItemName=nIteam;
				}
				else{
					//Khi carrot finish chi can tuoi nuoc
					GameObject landPosition=GameObject.Find("Land"+kyTyCuoiViTriLand);
					GameObject aniWaterFinish= Instantiate(aniWaterWhenFinish,landPosition.transform.position,Quaternion.identity)as GameObject;
					aniWaterFinish.gameObject.name=(""+aniWaterWhenFinish.gameObject.name+""+kyTyCuoiViTriLand);

					CotNuocCarot cNuocCarrotScript=GameObject.Find("carrotFinish"+kyTyCuoiViTriLand).GetComponent<CotNuocCarot>();
					float cphu= cNuocCarrotScript.cur_helth+30f;
					if(cphu>100f){
						cphu=100f;
					}
					cNuocCarrotScript.cur_helth=cphu;
				}
			}
			ResetData();
		}
	}




	void ResetData(){
		itemName = null;
		itemPosition=new Vector3(100f,100f,100f);
		landName = null;
		landNeedItem = null;
		landPosition = new Vector3 (200f, 200f, 200f);
	}


}
