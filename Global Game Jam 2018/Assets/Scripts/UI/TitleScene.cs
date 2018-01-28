using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : MonoBehaviour {
	GameObject Doctor;
	GameObject Despicable;
	GameObject Mansion;
	GameObject Maladies;
	float animationStart;
	// Use this for initialization
	void Start () {
		Doctor = transform.Find( "Doctor" ).gameObject;
		Despicable = transform.Find( "Despicable" ).gameObject;
		Mansion = transform.Find( "Mansion" ).gameObject;
		Maladies = transform.Find( "Maladies" ).gameObject;
		animationStart = Time.time;
	}

	void ExecuteAnimation () {
		Doctor.GetComponent<Animation>().Play( "FadeInText" );
	}
	
	// Update is called once per frame
	void Update () {
		float animationProgress = Time.time - animationStart;
		if( animationProgress <= 1) {
			Doctor.GetComponent<Animation>().Play( "FadeInText" );
		} else if ( animationProgress > 1 && animationProgress <= 2 ) {
			Despicable.GetComponent<Animation>().Play( "FadeInText" );
		} else if( animationProgress > 2 && animationProgress <= 3 ) {
			Mansion.GetComponent<Animation>().Play( "FadeInText" );
		} else if( animationProgress > 3 && animationProgress <= 4 ) {
			Maladies.GetComponent<Animation>().Play( "FadeInText" );
		}
	}
}
