using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goober : MonoBehaviour {
	private static float SPEED = 8;
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

	public void SetDirection( Vector2 direction ) {
		this.direction = direction;
		body.velocity = direction * SPEED;
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