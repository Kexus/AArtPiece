using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {
	public GameObject enemy;

	IEnumerator SpawnEnemy() {
		Instantiate (enemy, new Vector3 (Random.Range (-7, 7), 4, 0), Quaternion.identity);
		yield return new WaitForSeconds(3);
	}

	// Use this for initialization
	void Start () {
		while (true) {
			StartCoroutine (SpawnEnemy());
		}
 	}
	
	// Update is called once per frame
	void Update () {

	}


}
