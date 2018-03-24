using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
	// start = 49
	// end = -157
	// distance = 206
	// Use this for initialization
	public float offset = 0.0f;
	public float speed = 0.01f;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.SetPositionAndRotation (new Vector2 (0, 49f - offset), Quaternion.identity);
		offset = (offset + speed*Time.deltaTime/0.016f) % 206;
	}
}
