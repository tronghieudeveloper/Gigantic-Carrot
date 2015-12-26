using UnityEngine;
using System.Collections;

public class TimeAnimationDeTest : MonoBehaviour {
	public float timeAnimationDeTest;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("setTimeAnimation",0f,0.5f);
	}
	
	void setTimeAnimation(){
		GetComponent<Animator> ().speed = timeAnimationDeTest;
	}
}
