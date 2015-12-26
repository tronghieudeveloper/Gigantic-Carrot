using UnityEngine;
using System.Collections;

public class AllScreen : MonoBehaviour {

	void Start () {
		float widthDefault = 854.0f;
		float heightDefault = 480.0f;
		float widthScreen = Screen.width;
		float heightScreen = Screen.height;
		float scale = (heightDefault * widthScreen) / (heightScreen * widthDefault);
		Vector3 v3 = gameObject.transform.localScale;
		gameObject.transform.localScale = new Vector3 (v3.x * scale, gameObject.transform.localScale.y, v3.z * scale);
		/****Chuan la localScale như nay:
		gameObject.transform.localScale = new Vector3 (v3.x * scale, v3.y * scale, v3.z * scale);
		*************************************/
		
		//#if UNITY_IPHONE
		//  if(Screen.width == 768 || Screen.width == 1536){
		//   gameObject.transform.localScale = new Vector3 (v3.x  scale  0.8f, v3.y  scale  0.8f, v3.z  scale  0.8f);
		//  }
		//#endif
	}
}
