using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed = 10;
	Rigidbody2D body;

	void Start () {
		body = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		Vector2 velocity = input * speed;
		body.velocity = velocity;
	}
}
