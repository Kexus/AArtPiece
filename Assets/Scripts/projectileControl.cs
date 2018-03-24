using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileControl : MonoBehaviour {

	public float projectileVelocity;
	public int damage = 1;
	private bool isLive;

	// Use this for initialization
	void Start () {
		isLive = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (0, projectileVelocity));
	}

	void OnCollisionEnter2D (Collision2D collision2D) {
		if (collision2D.collider.CompareTag("Background")) {
			DestroyObject (gameObject);
		}
		if (collision2D.collider.CompareTag("Enemy")) {
			if (isLive) {
				isLive = false;
				DestroyObject (gameObject);
				collision2D.collider.SendMessage ("TakeDamage", damage);
			}
		}
	}
}
