﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour {
	GameObject[] texts;
	float timer = 0;

	void Start () {
		texts = new GameObject[] {
			transform.Find( "Doctor" ).gameObject,
			transform.Find( "Despicable" ).gameObject,
			transform.Find( "Mansion" ).gameObject,
			transform.Find( "Maladies" ).gameObject,
			transform.Find( "Start" ).gameObject
		};
	}

	void Update () {
		timer += Time.deltaTime;
		if (timer > 8 && Input.anyKeyDown) {
			Application.LoadLevel( 1 );
		}
	}

	//This is triggered from events within the TitleScreen animation
	public void EnableText( int step ) {
		texts[step].SetActive( true );
	}
}
