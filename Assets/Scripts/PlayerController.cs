using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D body;
	private float nextFire = 0.0F;
	public float speedMultiplier = 80F;
	public float horizontalMultplier = 2F;
	public float rateOfFire = .3F;
	public GameObject Projectile;
	public int health = 10;
	private bool isAlive = true;

	// Use this for initialization
	void Start () {
		body = GetComponent <Rigidbody2D> ();
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (horizontalMultplier*moveHorizontal, moveVertical);
		body.AddForce (speedMultiplier*movement);
		if (Input.GetButtonDown ("Jump") && isAlive) {
			nextFire = Time.time + rateOfFire;
			Instantiate (Projectile, transform.position, Quaternion.identity);
		}
		if (Input.GetButton ("Jump") && Time.time > nextFire && isAlive) {
			nextFire = Time.time + rateOfFire;
			Instantiate (Projectile, transform.position, Quaternion.identity);
		}
	}

	IEnumerator TakeDamage (int i) {
		health -= i;
		if (health <= 0) {
			GetComponent<SpriteRenderer> ().enabled = false;
			isAlive = false;
			yield return StartCoroutine ("waitAndReturn");
		}
	}

	IEnumerator waitAndReturn () {
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}
}
