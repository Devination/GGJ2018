using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goober : MonoBehaviour {
	private static float SPEED = 8;
	private static float DAMP_SCALAR = 0.3f;
	private Rigidbody2D body;
	public Vector2 direction;

	private void Awake () {
		body = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetVelocity( Vector2 playerVelocity, Vector2 directionalForce ) {
		body.velocity = ( playerVelocity * DAMP_SCALAR ) + ( directionalForce * SPEED );
	}

	void OnCollisionEnter2D ( Collision2D collision ) {
		if( collision.gameObject.CompareTag( "NPC" ) ) {
			Splatter();
		}
	}

	void Splatter() {
		//TODO: gross animation
		Destroy( gameObject );
	}

	void OnBecameInvisible () {
		Destroy( gameObject );
	}
}