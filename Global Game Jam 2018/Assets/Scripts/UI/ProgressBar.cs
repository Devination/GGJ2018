using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {
	Image image;
	// Use this for initialization
	void Start () {
		GameObject bar = transform.Find( "Bar" ).gameObject;
		image = bar.GetComponent<Image>();
	}

	public void Progress( float current, float total ) {
		float newFill = current / total;
		image.fillAmount = newFill;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
