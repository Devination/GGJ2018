using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour {
	GameObject[] texts;

	void Start () {
		texts = new GameObject[] {
			transform.Find( "Doctor" ).gameObject,
			transform.Find( "Despicable" ).gameObject,
			transform.Find( "Mansion" ).gameObject,
			transform.Find( "Maladies" ).gameObject
		};
	}

	//This is triggered from events within the TitleScreen animation
	public void EnableText( int step ) {
		texts[step].SetActive( true );
	}
}
