using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private float SPEED = 5;
	private float SLOW_DURATION = 0.25f;
	private float slowFirstTime;
	Rigidbody2D body;

	void Start () {
		body = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		Vector2 input = new Vector2( Input.GetAxis("Horizontal"), Input.GetAxisRaw("Vertical") );
		Vector2 velocity = input * SPEED;
		// Slow player movement if there is no input.
		if( input.x == 0 && input.y == 0 && body.velocity != Vector2.zero ) {
			slowFirstTime = slowFirstTime == -1 ? Time.time : slowFirstTime;
			float slowElapsedTime = Time.time - slowFirstTime;
			body.velocity = Vector2.Lerp( body.velocity, Vector2.zero, slowElapsedTime / SLOW_DURATION );
		}
		else {
			body.velocity = velocity;
			slowFirstTime = -1;
		}
	}
}
