using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileControl : MonoBehaviour {

	public float projectileVelosity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (0, projectileVelosity));
	}

	void OnCollisionEnter (Collision collision) {
		if (collision.other.CompareTag("Background")) {
			Debug.Log ("Hit");
			DestroyObject (gameObject);
		}
	}
}
