using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private const float SPEED = 5;
	private const float SLOW_DURATION = 0.25f;
	private float slowFirstTime;
	private Vector2 headDirection;
	private float sneezeTime = 1;
	private Rigidbody2D body;
	public float sneezeTimer;
	public GameObject Goober;

	void Start() {
		body = GetComponent<Rigidbody2D>();
		headDirection = Vector2.down;
		sneezeTimer = 0;
	}

	void SetSneezeTime( float sneezeTime ) {
		this.sneezeTime = sneezeTime;
	}

	void FixedUpdate() {
		// Handle player movement
		Vector2 input = new Vector2( Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") );
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

		// Handle player head movement
		Vector2 headInput = new Vector2( Input.GetAxisRaw( "HorizontalHead" ), Input.GetAxisRaw( "VerticalHead" ) );
		if ( headInput.x == 0 ^ headInput.y == 0 ) {
			headDirection = headInput;
		}
		else if( headInput == Vector2.zero ) {
			headDirection = Vector2.down;
		}

		sneezeTimer += Time.deltaTime;
		if ( sneezeTimer >= sneezeTime ) {
			GameObject newGoob = Instantiate( Goober, body.transform.position, body.transform.rotation );
			Goober goobScript = newGoob.GetComponent<Goober>();
			goobScript.SetDirection( new Vector2( headDirection.x, headDirection.y ) );
			sneezeTimer = 0;
		}
	}
}
