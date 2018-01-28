﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Animator ) )]
public class Player : MonoBehaviour {
	const float SPEED = 5;
	const float SLOW_DURATION = 0.25f;
	const float HEAD_DOWN_DURATION = 0.1f;
	const float TOTAL_EMPATHY = 6;
	const float EMPATHY_STEP = 1;
	[SerializeField]
	GameObject deathFX;
	float slowStartTime;
	float noInputStartTime;
	Vector2 headDirection;
	float sneezeTime = 1;
	GameObject HealthBar;
	float empathy;
	Animator animator;
	bool dying;
	public GameObject Goober;
	private Rigidbody2D body;
	public float sneezeTimer;

	void Start() {
		animator = GetComponent<Animator>();
		body = GetComponent<Rigidbody2D>();
		headDirection = Vector2.down;
		sneezeTimer = 0;
		empathy = TOTAL_EMPATHY;
		HealthBar = GameObject.Find( "HealthBar" );
		dying = false;
	}

	void SetSneezeTime( float sneezeTime ) {
		this.sneezeTime = sneezeTime;
	}

	public void GetABitSadder() {
		empathy -= EMPATHY_STEP;
		HealthBar.GetComponent<ProgressBar>().Progress( empathy, TOTAL_EMPATHY );
		if( empathy == 0 ) {
			Die();
		}
	}

	//animator "Die" trigger will trigger this.
	public void PlayDeathFX () {
		Instantiate( deathFX, transform.position, Quaternion.identity );
		Destroy( gameObject );
	}

	void Die() {
		dying = true;
		animator.SetTrigger( "Die" );
	}

	void FixedUpdate() {
		// Handle player movement
		Vector2 input = new Vector2( Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") );
		Vector2 velocity = input * SPEED;
		// Slow player movement if there is no input.
		if( input.x == 0 && input.y == 0 && body.velocity != Vector2.zero ) {
			slowStartTime = slowStartTime == -1 ? Time.time : slowStartTime;
			float slowElapsedTime = Time.time - slowStartTime;
			body.velocity = Vector2.Lerp( body.velocity, Vector2.zero, slowElapsedTime / SLOW_DURATION );
		}
		else {
			body.velocity = velocity;
			slowStartTime = -1;
		}

		// Handle player head movement
		Vector2 headInput = new Vector2( Input.GetAxisRaw( "HorizontalHead" ), Input.GetAxisRaw( "VerticalHead" ) );
		if ( headInput.x == 0 ^ headInput.y == 0 ) {
			headDirection = headInput;
			noInputStartTime = -1;
		}
		else if( headInput.x != 0 && headInput.y != 0 ) {
			headDirection.x = 0;
			headDirection.y = headInput.y;
		}
		else if( headInput == Vector2.zero ) {
			noInputStartTime = noInputStartTime == -1 ? Time.time : noInputStartTime;
			if( HEAD_DOWN_DURATION >= Time.time - noInputStartTime ) {
				headDirection = Vector2.down;
			}
		}

		sneezeTimer += Time.deltaTime;
		if ( ( sneezeTimer >= sneezeTime ) && !dying ) {
			GameObject newGoob = Instantiate( Goober, body.transform.position, body.transform.rotation );
			Goober goobScript = newGoob.GetComponent<Goober>();
			goobScript.SetVelocity( body.velocity, new Vector2( headDirection.x, headDirection.y ) );
			sneezeTimer = 0;
		}
	}
}
