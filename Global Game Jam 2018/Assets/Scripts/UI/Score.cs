using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	float SCORE_MULTIPLIER = 50;
	Player player;
	public static float score = 0;
	float setScore;
	Text scoreText; 
	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text>();
		player = GameObject.FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if( player != null ) {
			score += Time.deltaTime * SCORE_MULTIPLIER;
		}

		if( score != setScore ) {
			scoreText.text = string.Format( "{0:N0}", score );
		}
		setScore = score;
	}
}
