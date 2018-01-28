using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	float SCORE_MULTIPLIER = 50;
	public Player player;
	float score;
	Text scoreText; 
	// Use this for initialization
	void Start () {
		score = 0;
		scoreText = GameObject.Find( "Score" ).GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if( player != null ) {
			score += Time.deltaTime * SCORE_MULTIPLIER;
			scoreText.text = string.Format( "{0:N0}", score );
		}
	}
}
