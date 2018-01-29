using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScene : MonoBehaviour {
	void Start () {
	}

	void Update () {
	}

	public void BackToMain() {
		Application.LoadLevel( 0 );
	}

	public void GoToTutorialScene () {
		Application.LoadLevel( 1 );
	}

	public void GoToGame () {
		Application.LoadLevel( 2 );
	}
}
