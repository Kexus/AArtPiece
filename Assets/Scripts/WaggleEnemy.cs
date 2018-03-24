using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaggleEnemy : MonoBehaviour {
	public int health = 3;
	public int damage = 1;
	public float ySpeed = .0001F;
	//private Rigidbody2D body;
	//private bool rightMov = true;
	private Vector2 movement;
	private float yLoc;

	public enum OccilationFunction {Sine, Cosine}

	// Use this for initialization
	void Start () {
		gameObject.transform.GetChild (0).GetChild (0).gameObject.GetComponent<Text> ().text = ((char)Random.Range (12449, 12544)).ToString();
		//body = GetComponent <Rigidbody2D> ();
		yLoc = transform.position.y;
		StartCoroutine (Oscillate (OccilationFunction.Sine, 5f));
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
			DestroyObject (gameObject);
			collision2D.collider.SendMessage ("TakeDamage", damage);
		}
	}

	private IEnumerator Oscillate (OccilationFunction method, float scalar) {
		while (true) {
			if (method == OccilationFunction.Sine) {
				transform.position = new Vector2 (Mathf.Sin (Time.time) * scalar, yLoc);
				yLoc -= ySpeed;
			} else if (method == OccilationFunction.Cosine) {
				transform.position = new Vector2 (Mathf.Cos (Time.time) * scalar, yLoc);
				yLoc -= ySpeed;
			}
			yield return new WaitForEndOfFrame ();
		}
	}

	void TakeDamage(int i) {
		health -= i;
	}
}
