using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemy : MonoBehaviour {
	public int health = 2;
	public int damage = 1;

	// Use this for initialization
	void Start () {
		gameObject.transform.GetChild (0).GetChild (0).gameObject.GetComponent<Text> ().text = ((char)Random.Range (12449, 12544)).ToString();
	}

	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Object.Destroy (gameObject);
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
