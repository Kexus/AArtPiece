using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {
	public GameObject enemy;
	public float spawnTime;

	void SpawnEnemy() {
		Instantiate (enemy, new Vector3 (Random.Range (-4, 4.2f), 6, 0), Quaternion.identity);
	}

	// Use this for initialization
	void Start () {

		InvokeRepeating ("SpawnEnemy", spawnTime, spawnTime);

 	}
	
	// Update is called once per frame
	void Update () {

	}


}
