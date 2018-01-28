using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Animator ) )]
public class Goober : MonoBehaviour {
	private static float SPEED = 8;
	private static float DAMP_SCALAR = 0.3f;
	private Rigidbody2D body;
	private Animator animator;
	public Vector2 direction;
	[SerializeField] GameObject splatFX;

	private void Awake () {
		animator = GetComponent<Animator>();
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
		Splatter();
	}

	//animator "Splatter" trigger will trigger this.
	public void PlaySplatFX () {
		Instantiate( splatFX, transform.position, Quaternion.identity );
		Destroy( gameObject );
	}

	void Splatter () {
		animator.SetTrigger( "Splattered" );
	}

	void OnBecameInvisible () {
		Destroy( gameObject );
	}
}