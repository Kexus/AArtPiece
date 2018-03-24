using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class VaporwaveTime : MonoBehaviour {

	private GameObject cam;
	private MotionBlurModel.Settings blurSettings;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Main Camera");
		 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("VaporMode")) {
			Time.timeScale = 0.5f;
			cam.GetComponent<PostProcessingBehaviour> ().profile.bloom.enabled = true;
			blurSettings = cam.GetComponent<PostProcessingBehaviour> ().profile.motionBlur.settings;
			blurSettings.frameBlending = 0.5f;
			cam.GetComponent<PostProcessingBehaviour> ().profile.motionBlur.settings = blurSettings;
		}
		if (Input.GetButtonUp ("VaporMode")) {
			Time.timeScale = 1f;
			//cam.GetComponent<PostProcessingBehaviour> ().enabled = false;
			cam.GetComponent<PostProcessingBehaviour> ().profile.bloom.enabled = false;
			blurSettings = cam.GetComponent<PostProcessingBehaviour> ().profile.motionBlur.settings;
			blurSettings.frameBlending = 0.1f;
			cam.GetComponent<PostProcessingBehaviour> ().profile.motionBlur.settings = blurSettings;
		}
	}
}
