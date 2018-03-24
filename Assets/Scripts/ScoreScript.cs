using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public int score;
	private Text text;

	// Use this for initialization
	void Start () {
		score = 1;
		Debug.Log (gameObject.transform.GetChild (4).name);
		text = gameObject.transform.GetChild (4).gameObject.GetComponent<Text> ();
		Debug.Log (text.name);
	}
	
	// Update is called once per frame
	void Update () {
		score += Random.Range (1, 5);
		text.text = score.ToString();
	}

	void IncreaseScoreBy (int i) {
		score += i;
	}
}
