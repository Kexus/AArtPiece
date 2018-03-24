using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaporwaveTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("VaporMode")) {
			Time.timeScale = 0.5f;
		}
		if (Input.GetButtonUp ("VaporMode")) {
			Time.timeScale = 1f;
		}
	}
}
