using UnityEngine;
using System.Collections;

public class TimeDie : MonoBehaviour {
	public float timeDie;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, timeDie);
	}
}
