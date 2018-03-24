using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowerEnemyScript : MonoBehaviour {
	public int health = 1;
	public int damage = 1;
	public float xSpeed = 100F;
	public float ySpeed = .5F;
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		gameObject.transform.GetChild (0).GetChild (0).gameObject.GetComponent<Text> ().text = ((char)Random.Range (12449, 12544)).ToString();
		body = GetComponent <Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Object.Destroy (gameObject);
		}
		if (transform.position.x > GameObject.FindGameObjectWithTag ("Player").transform.position.x) {
			Vector2 movement = new Vector2 (-xSpeed, -ySpeed);
			body.AddForce (movement);
		} else if (transform.position.x < GameObject.FindGameObjectWithTag ("Player").transform.position.x) {
			Vector2 movement = new Vector2 (xSpeed, -ySpeed);
			body.AddForce (movement);
		} else {
			Vector2 movement = new Vector2 (0, -ySpeed);
			body.AddForce (movement);
		}
	}

	void OnCollisionEnter2D (Collision2D collision2D) {
		if (collision2D.collider.CompareTag("Background")) {
			DestroyObject (gameObject);
		}
		if (collision2D.collider.CompareTag("Player")) {
			collision2D.collider.SendMessage ("TakeDamage", damage);
			DestroyObject (gameObject);
		}
	}

	void TakeDamage(int i) {
		health -= i;
	}
}