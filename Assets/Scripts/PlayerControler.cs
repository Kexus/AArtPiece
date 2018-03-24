﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

	private Rigidbody2D body;
	public float speedMultiplyer;
	public float horizontalMultplyer;
	public GameObject Projectile;

	// Use this for initialization
	void Start () {
		body = GetComponent <Rigidbody2D> ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (horizontalMultplyer*moveHorizontal, moveVertical);
		body.AddForce (speedMultiplyer*movement);
		if (Input.GetButton ("Jump")) {
			Instantiate (Projectile, transform.position, Quaternion.identity);
		}
	}
}
