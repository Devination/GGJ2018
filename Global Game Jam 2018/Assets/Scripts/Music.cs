using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AudioSource source = GetComponent<AudioSource>();
		source.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
