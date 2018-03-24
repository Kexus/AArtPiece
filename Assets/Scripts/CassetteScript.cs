using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassetteScript : MonoBehaviour {
	public int health = 1;
	public float bonus = 1f;
	public GameObject vwTimeObj;

	// Use this for initialization
	void Start () {
		if (vwTimeObj == null) {
			vwTimeObj = GameObject.Find ("Script Holder");
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward * Time.deltaTime * 360);
		if (health <= 0) {
			Object.Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D collision2D) {
		if (collision2D.collider.CompareTag("Background")) {
			DestroyObject (gameObject);
		}
		if (collision2D.collider.CompareTag("Player")) {
			vwTimeObj.SendMessage ("IncreaseVWTime", 1f);
			DestroyObject (gameObject);
		}
	}

	void TakeDamage(int i) {
		health -= i;
	}
}
