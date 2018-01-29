using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public void Restart () {
		Application.LoadLevel( 2 );
		Score.score = 0;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
